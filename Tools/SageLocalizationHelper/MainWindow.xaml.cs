using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Xml.Linq;
using System.Xml.XPath;

namespace SageLocalizationHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow: Window
    {
        private string _projectsFolderPath = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.ShowDialog();
            txtProjectsPath.Text = dialog.SelectedPath;
        }

        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            //const string projectsFolderPath = @"C:\Sage\SC\Columbus-NA\ERP\SourceCode\Projects\";

            richTextLog.Document.Blocks.Clear();

            if (string.IsNullOrEmpty(txtProjectsPath.Text))
            {
                LogAction("Projects directory is required");
                return;
            }

            _projectsFolderPath = txtProjectsPath.Text;
            string projectsFolderPath = _projectsFolderPath;
            const string culture = "fr-FR";

            var creator = new ResourceCreator(projectsFolderPath, culture, ResouceFileList.All);
            creator.CreateLocalizedFile(LogAction);

        }

        private void LogAction(string logInfo)
        {
            if (richTextLog.Dispatcher.CheckAccess())
            {
                richTextLog.AppendText(logInfo);
                richTextLog.AppendText("\n");

            }
            else
            {
                richTextLog.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
                {
                    richTextLog.AppendText(logInfo);
                    richTextLog.AppendText("\n");
                }));
            }

            Debug.WriteLine(logInfo);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

    public class ResouceFileList
    {
        public static List<string> All = new List<string>
        {
            @"AS\Sage.CA.SBS.ERP.Sage300.AS.Resources\Forms\SecurityGroupsResx.resx",
            @"AS\Sage.CA.SBS.ERP.Sage300.AS.Resources\Forms\UserAuthorizationsResx.resx",
            @"AS\Sage.CA.SBS.ERP.Sage300.AS.Resources\ASCommonResx.resx",
            @"AS\Sage.CA.SBS.ERP.Sage300.AS.Resources\EnumerationsResx.resx",
            @"Common\Sage.CA.SBS.ERP.Sage300.Common.Resources\Utilities\ExpressionsResx.resx",
            @"Common\Sage.CA.SBS.ERP.Sage300.Common.Resources\Utilities\OperatorsResx.resx",
            @"Common\Sage.CA.SBS.ERP.Sage300.Common.Resources\Utilities\WorkerResx.resx",
            @"Common\Sage.CA.SBS.ERP.Sage300.Common.Resources\AnnotationsResx.resx",
            @"Common\Sage.CA.SBS.ERP.Sage300.Common.Resources\CommonResx.resx",
            @"Common\Sage.CA.SBS.ERP.Sage300.Common.Resources\EnumerationsResx.resx",
            @"Core\Sage.CA.SBS.ERP.Sage300.Core.Resources\StorageResx.resx",
            @"CS\Sage.CA.SBS.ERP.Sage300.CS.Resources\Forms\CurrencyCodesResx.resx",
            @"CS\Sage.CA.SBS.ERP.Sage300.CS.Resources\Forms\CurrencyRatesResx.resx",
            @"CS\Sage.CA.SBS.ERP.Sage300.CS.Resources\Forms\CurrencyRateTypesResx.resx",
            @"CS\Sage.CA.SBS.ERP.Sage300.CS.Resources\Forms\OptionalFieldsResx.resx",
            @"CS\Sage.CA.SBS.ERP.Sage300.CS.Resources\Forms\SchedulesResx.resx",
            @"CS\Sage.CA.SBS.ERP.Sage300.CS.Resources\CSCommonResx.resx",
            @"CS\Sage.CA.SBS.ERP.Sage300.CS.Resources\EnumerationsResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\Forms\AccountGroupsResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\Forms\AccountsResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\Forms\AccountStructuresResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\Forms\BatchListResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\Forms\JournalEntryResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\Forms\OptionalFieldsResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\Forms\OptionsResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\Forms\PostBatchesResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\Forms\RecurringEntriesResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\Forms\RevaluationCodesResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\Forms\ScheduleCodesResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\Forms\SegmentCodesResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\Forms\SourceCodesResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\Forms\SourceJournalProfilesResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\Process\CreateNewYearResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\Process\CreateRecurringEntriesBatchResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\Process\PeriodEndMaintenanceResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\Reports\AccountGroupsReportResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\Reports\BatchListingReportResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\Reports\BatchStatusReportResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\Reports\ChartOfAccountsReportResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\Reports\OptionalFieldsReportResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\Reports\OptionsReportResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\Reports\PostingJournalsResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\Reports\RecurringEntriesReportResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\Reports\SegmentCodesReportResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\Reports\SourceJournalProfilesReportResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\Reports\TransactionDetailsOptionalFieldsReportResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\Reports\TransactionsListingResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\Reports\TrialBalanceReportResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\EnumerationsResx.resx",
            @"GL\Sage.CA.SBS.ERP.Sage300.GL.Resources\GLCommonResx.resx"
        };
    }

    public class ResourceCreator
    {
        private readonly string _projectsFolderPath = string.Empty;
        private readonly string _culture = string.Empty;
        private readonly List<string> _fileList;


        public ResourceCreator(string projectsFolderPath, string culture, List<string> filelList)
        {
            _projectsFolderPath = projectsFolderPath;
            _culture = culture;
            _fileList = filelList;
        }

        public void CreateLocalizedFile(Action<string> logAction)
        {
            Parallel.ForEach(_fileList, currentFile =>
            {
                try
                {
                string fullPath = System.IO.Path.Combine(_projectsFolderPath, currentFile);
                XDocument doc = XDocument.Load(fullPath);

                IEnumerable<XElement> valueElements = doc.XPathSelectElements("root/data/value");
                foreach (var elem in valueElements)
                {
                    elem.Value = string.Format("[{0}]-{1}", _culture, elem.Value);
                }

                string newFilePath = fullPath.Replace(".resx", string.Format(".{0}.resx", _culture));

                doc.Save(newFilePath);

                if (logAction != null)
                    logAction(string.Format("File processed: {0}", newFilePath));
                }
                catch (Exception ex)
                {
                    if (logAction != null)
                        logAction(string.Format("Exception occurred: {0}", ex.Message));
                }
            });

            //if (logAction != null)
            //    logAction("Task completed");
        }
    }
}
