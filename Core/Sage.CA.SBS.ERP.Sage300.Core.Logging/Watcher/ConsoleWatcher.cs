// /* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Core.Logging.Watcher
{
    /// <summary>
    /// Console watcher class
    /// </summary>
    public class ConsoleWatcher : Watcher
    {
        /// <summary>
        /// Constructs the console outout
        /// </summary>
        /// <param name="name">Name of the watcher</param>
        public ConsoleWatcher(string name)
            : base(name, new ConsoleOut())
        {

        }
    }
}
