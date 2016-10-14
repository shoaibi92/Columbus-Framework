// /* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;
using System.Diagnostics;

namespace Sage.CA.SBS.ERP.Sage300.Core.Logging.Watcher
{
    /// <summary>
    /// Stopwatch helper
    /// Usage:
    /// using (new Watcher("Mywatch")
    /// {
    ///     // Your code
    /// }
    /// Output:
    /// Time spent for Mywatch = 2001ms
    /// </summary>
    public class Watcher : IDisposable
    {
        private const string FINAL_OUTPUT_STRING = "Time spent for {0} = {1}ms";
        private const string STAGE_OUTPUT_STRING = "Time spent for {0} in stage {1} = {2}ms";
        private Stopwatch _watch = new Stopwatch();

        private IOutput _outputWriter;

        private string _watchName;

        private readonly bool _logOnlyIfRequired;

        public long ElapsedTime { get { return _watch.ElapsedMilliseconds; }  }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the watch, used for log</param>
        public Watcher(string name)
            : this(name, new DebugOut())
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="logOnlyIfRequired">Only log if time taken is more than 100ms</param>
        public Watcher(string name, bool logOnlyIfRequired)
            : this(name, new DebugOut(), logOnlyIfRequired)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="outputWriter"></param>
        public Watcher(string name, IOutput outputWriter)
            : this(name, outputWriter, false)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="outputWriter"></param>
        /// <param name="logOnlyIfRequired">Only log if time taken is more than 100ms</param>
        public Watcher(string name, IOutput outputWriter, bool logOnlyIfRequired)
        {
            _logOnlyIfRequired = logOnlyIfRequired;
            _outputWriter = outputWriter;
            _watchName = name;
            _watch.Start();
        }

        /// <summary>
        /// Prints the current elapsed time
        /// </summary>
        /// <param name="stage"></param>
        public void Print(string stage)
        {
            _watch.Stop();

            if (!_logOnlyIfRequired || _watch.ElapsedMilliseconds > 100)
            {
                _outputWriter.WriteLine(STAGE_OUTPUT_STRING, _watchName, stage, _watch.ElapsedMilliseconds);
            }
            _watch.Start();
        }


        /// <summary>
        /// Dispose the watch and logs the time
        /// </summary>
        public void Dispose()
        {
            _watch.Stop();

            if (!_logOnlyIfRequired || _watch.ElapsedMilliseconds > 100)
             {
                 _outputWriter.WriteLine(FINAL_OUTPUT_STRING, _watchName, _watch.ElapsedMilliseconds);
             }
            _watch = null;
        }
    }
}
