/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using Sage.CA.SBS.ERP.Sage300.Core.Logging;
using Sage.CA.SBS.ERP.Sage300.Workflow.Interfaces;

namespace Sage.CA.SBS.ERP.Sage300.Worker
{
    /// <summary>
    /// Dispatcher for the worker VM.
    /// Responsible for all work scheduling and dispatching
    /// </summary>
    public class WorkerDispatcher
    {
        /// <summary>
        /// Constructor...
        /// </summary>
        /// <param name="worker">Required IWorker to be dispatched.</param>
        public WorkerDispatcher(IWorker worker)
        {
            if (worker == null)
                throw new ArgumentNullException("worker");

            _worker = worker;
        }

        #region Windows Service

        /// <summary>
        /// Start the worker dispatcher. This call does not return.
        /// </summary>
        /// <param name="cancellationToken">CancellationToken</param>
        public void Start(CancellationToken cancellationToken)
        {
            StartIWorkerDispatcher(_worker, cancellationToken);
        }

        /// <summary>
        /// Request and dispatch work.
        /// </summary>
        /// <param name="worker"></param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <remarks>
        /// No exceptions allowed other then critical ones that will cause VM to restart.
        /// We currently count on the GC to cleanup our tasks. Not ideal but avoids race conditions.
        /// </remarks>
        private static void StartIWorkerDispatcher(IWorker worker, CancellationToken cancellationToken)
        {
            const int workflowQueueTimerInMiliseconds = 5000;
            int maxHostThreads = ConfigurationHelper.MaximumThreadCount;

            //default capacity is about 31, concurrency level 4*Processor count
            var tasks = new ConcurrentDictionary<int, Task>();

            while (true)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    Logger.Info("Cancellation Requested", LoggingConstants.ModuleWorkerRole);
                    Task.WaitAll(tasks.Values.ToArray());

                    // no more new tasks
                    break;
                }

                //Check to see if we should take more work, if so try to get more work and start it.
                //Repeat until we should not take more work
                //then sleep until it is time to check for more work   

                //take more work if there is work and it would not exceed our max concurrent work.
                var timeToSleep = true;
                if (tasks.Count < maxHostThreads)
                {
                    Action work = worker.GetNextAction();
                    if (work != null)
                    {
                        CreateTaskAndStart(tasks, work);

                        //started a task so do not sleep yet, see if we should get more tasks
                        timeToSleep = false;
                    }
                }

                //figure out if we should wait for tasks to finish or just sleep
                if (!timeToSleep) continue;

                if (tasks.Count == 0)
                {
                    //no tasks so sleep and wait for more.
                    Thread.Sleep(workflowQueueTimerInMiliseconds);
                }
                else
                {
                    //tasks were full or we had at least one task and no more tasks to get.
                    WaitForATaskToFinish(tasks.Values);
                }
            }
        }

        #endregion

        #region Worker role
        /// <summary>
        /// Start the worker dispatcher. This call does not return.
        /// </summary>
        public void Start()
        {
            StartIWorkerDispatcher(_worker);
        }
        /// <summary>
        /// Request and dispatch work.
        /// </summary>
        /// <param name="worker"></param>
        /// <remarks>
        /// No exceptions allowed other then critical ones that will cause VM to restart.
        /// We currently count on the GC to cleanup our tasks. Not ideal but avoids race conditions.
        /// </remarks>
        private static void StartIWorkerDispatcher(IWorker worker)
        {
            const int workflowQueueTimerInMiliseconds = 5000;
            int maxHostThreads = ConfigurationHelper.MaximumThreadCount;

            //default capacity is about 31, concurrency level 4*Processor count
            var tasks = new ConcurrentDictionary<int, Task>();

            while (true)
            {
                //Check to see if we should take more work, if so try to get more work and start it.
                //Repeat until we should not take more work
                //then sleep until it is time to check for more work   

                //take more work if there is work and it would not exceed our max concurrent work.
                var timeToSleep = true;
                if (tasks.Count < maxHostThreads)
                {
                    Action work = worker.GetNextAction();
                    if (work != null)
                    {
                        CreateTaskAndStart(tasks, work);

                        //started a task so do not sleep yet, see if we should get more tasks
                        timeToSleep = false;
                    }
                }

                //figure out if we should wait for tasks to finish or just sleep
                if (!timeToSleep) continue;
                
                if (tasks.Count == 0)
                {
                    //no tasks so sleep and wait for more.
                    Thread.Sleep(workflowQueueTimerInMiliseconds);
                }
                else
                {
                    //tasks were full or we had at least one task and no more tasks to get.
                    WaitForATaskToFinish(tasks.Values);
                }
            }
        }

        #endregion
        /// <summary>
        /// Create the task to process the work and start it and register the cleanup work to do on task completion.
        /// </summary>
        /// <param name="tasks"></param>
        /// <param name="work"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Waiting on finalize explicitly")]
        private static void CreateTaskAndStart(ConcurrentDictionary<int, Task> tasks, Action work)
        {
            //if we are not encountering long running tasks TaskCreationOptions.PreferFairness is our best choice and will schedule in a way to ensure
            //that every task makes progress, and give best results for a number of shorter runs. Threads will be re used for best throughput.
            //However with some of our tasks running very long (hour+)  TaskCreationOptions.LongRunning maybe a better choice. With the
            //default scheduler this will give a tread to each task. However this will result in more thread management overheads.
            //consider allowing information to flow up to categorize need for fair vs. long running
            var task = new Task(work, TaskCreationOptions.PreferFairness);
            //Task task = new Task(work, TaskCreationOptions.LongRunning);
            
            Action<Task> cleanup = CreateCleanupAction(tasks);
            task.ContinueWith(cleanup);

            bool taskAdded;
            do
            {
                taskAdded = tasks.TryAdd(task.Id, task);
                //thought about adding a Thread.Sleep(0) here. Based on how this is used it has the potential 
                //to hurt more then help.
            } while (!taskAdded);

            task.Start();
        }

        /// <summary>
        /// Create cleanup action for a task, clean up will remove the task from the tasks collection.
        /// </summary>
        /// <param name="tasks"></param>
        /// <returns></returns>
        private static Action<Task> CreateCleanupAction(ConcurrentDictionary<int, Task> tasks)
        {
            Action<Task> retval = task =>
            {
                bool removedTask;
                do
                {
                    Task taskFromCollection;
                    removedTask = tasks.TryRemove(task.Id, out taskFromCollection);

                    if (taskFromCollection != null)
                    {
                        //check result - should not be needed in theory
                        //normal exceptions are already consumed in task.
                        //but just in case log and mark as handled.
                        var ae = taskFromCollection.Exception;
                        if (ae != null)
                        {
                            ae.Handle(ex =>
                            {
                                Logger.Error("Error in CreateCleanupAction", LoggingConstants.ModuleWorkerRole, null, ex);
                                return true;
                            });
                        }
                    }
                    //thought about adding a Thread.Sleep(0) here for failures. Based on how this is used it has the 
                    //potential to hurt more then help.
                } while (!removedTask);
                //Do not dispose here. This will create issue for the WaitAny code.
                //All dispose is currently doing is closing the ManualResetEventSlim object per Richter
                //who suggests this is not a big deal.
            };
            return retval;
        }

        /// <summary>
        /// Wait for at least one of the tasks in the enumeration to finish.
        /// </summary>
        /// <param name="tasks"></param>
        private static void WaitForATaskToFinish(IEnumerable<Task> tasks)
        {
            //**Need to make a copy so that clean up does not remove a task when we are not expecting it.**
            //Get a copy of the task list. Using the straight task collection results in a race condition that can 
            //result in a null entries in the collection.
            //Some of the tasks may come over as null if they cleaned up. That is ok here.
            //The collection type was explicitly chosen as it supports null as a valid value.
            var tasksCollection = new Collection<Task>();
            foreach (var task in tasks)
                tasksCollection.Add(task);

            //now have our own copy of the tasks. They may transition to done but that is ok
            //Remove any null values from tasks that cleaned up and removed themselves from the collection while we were copying etc.
            for (int i = tasksCollection.Count - 1; i >= 0; i--)
            {
                if (tasksCollection[i] == null)
                    tasksCollection.RemoveAt(i);
            }

            //if we have any tasks left wait on them
            var waitForTasks = (tasksCollection.Count > 0);
            if (waitForTasks)
            {
                var tasksToWaitOn = tasksCollection.ToArray();
                Task.WaitAny(tasksToWaitOn);
            }
        }
        private readonly IWorker _worker;
    }
}
