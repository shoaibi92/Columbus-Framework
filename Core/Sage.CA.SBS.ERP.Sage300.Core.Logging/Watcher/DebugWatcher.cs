// /* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Core.Logging.Watcher
{
    /// <summary>
    /// Debug watcher class
    /// </summary>
    public class DebugWatcher : Watcher
    {
        public DebugWatcher(string name) : base(name, new DebugOut())
        {
            
        }
    }
}
