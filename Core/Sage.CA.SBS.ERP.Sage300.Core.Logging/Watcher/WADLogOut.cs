namespace Sage.CA.SBS.ERP.Sage300.Core.Logging.Watcher
{
    public class WADLogOut : IOutput
    {
        /// <summary>
        /// Write line
        /// </summary>
        /// <param name="formatText"></param>
        /// <param name="args"></param>
        public void WriteLine(string formatText, params object[] args)
        {
           Logger.Verbose(string.Format(formatText, args),"Watcher");
        }
    }
}
