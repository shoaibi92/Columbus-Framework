
namespace Sage.CA.SBS.ERP.Sage300.Core.Logging.Watcher
{
    public class WADLogWatcher : Watcher
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the watch, used for log</param>
        public WADLogWatcher(string name) : base(name, new WADLogOut())
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the watch, used for log</param>
        /// <param name="logOnlyIfRequired">Only log if time taken is more than 100ms</param>
        public WADLogWatcher(string name, bool logOnlyIfRequired)
            : base(name, new WADLogOut(), logOnlyIfRequired)
        {
        }
    }
}
