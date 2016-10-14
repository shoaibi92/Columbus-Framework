using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Microsoft.ApplicationServer.Caching;

namespace AzureMonitor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Log all cache items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Trace.WriteLine("Start");
            Log();
            Trace.WriteLine("End");
        }

        /// <summary>
        /// Log all cache items
        /// </summary>
        private void Log()
        {
            using (var cacheFactory = new DataCacheFactory())
            {
                var defaultCacheProvider = cacheFactory.GetDefaultCache();
                var sessionCacheProvider = cacheFactory.GetCache("session");
                
                int count = 0;

                Trace.WriteLine("Default");
                foreach (string region in defaultCacheProvider.GetSystemRegions())
                {
                    int cnt = 0;

                    foreach (var kvp in defaultCacheProvider.GetObjectsInRegion(region))
                    {
                        Trace.WriteLine(string.Format("Data item ('{0}','{1}') in region {2} of cache {3}", kvp.Key,
                            kvp.Value, region, "default"));

                        count++;
                        cnt++;
                    }

                    Trace.WriteLine(string.Format(" Default Region : ({0}) Total Count  : {1} ", region, cnt));
                }
                
                Trace.WriteLine(string.Format(" Default Total Region : Total Count  : {0} ", count));


                count = 0;

                Trace.WriteLine("Session");

                foreach (string region in sessionCacheProvider.GetSystemRegions())
                {
                    int cnt = 0;

                    foreach (var kvp in sessionCacheProvider.GetObjectsInRegion(region))
                    {
                        Trace.WriteLine(string.Format("Data item ('{0}','{1}') in region {2} of cache {3}", kvp.Key,
                            kvp.Value, region, "session"));

                        count++; cnt++;
                    }

                    Trace.WriteLine(string.Format(" System Region : ({0}) Total Count  : {1} ", region, cnt));
                }

                Trace.WriteLine(string.Format(" System Total Region : Total Count  : {0} ", count));

            }
        }

        /// <summary>
        /// Clear Cache
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearCache_Click(object sender, EventArgs e)
        {
            using (var cacheFactory = new DataCacheFactory())
            {
                var defaultCacheProvider = cacheFactory.GetDefaultCache();
                defaultCacheProvider.Clear();
                var sessionCacheProvider = cacheFactory.GetCache("session");
                sessionCacheProvider.Clear();
            }
        }

        /// <summary>
        /// clear Default Cache
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearDefaultCache_Click(object sender, EventArgs e)
        {
            using (var cacheFactory = new DataCacheFactory())
            {
                var defaultCacheProvider = cacheFactory.GetDefaultCache();
                defaultCacheProvider.Clear();
            }
        }
    }
}
