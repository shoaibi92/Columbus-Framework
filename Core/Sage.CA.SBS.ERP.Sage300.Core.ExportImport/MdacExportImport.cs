/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Data;
using System.Data.OleDb;
using System.IO;

using Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.ExportImport;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Core.ExportImport
{
    /// <summary>
    /// Class MdacExportImport.
    /// </summary>
    public class MdacExportImport : IExportImport
    {
        //connection string - source has to be replaced by actual file (physical path)
        /// <summary>
        /// The connection string
        /// </summary>
        private const string ConnectionString =
            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=YES;\"";

        /// <summary>
        /// Export method
        /// </summary>
        /// <param name="dataSet">Dataset</param>
        /// <returns>Response</returns>
        private ExportResponse ExportResponse(DataSet dataSet)
        {
            var currentDirectory = ConfigurationHelper.LocalFolder;
            var newDir = currentDirectory + "\\" + Guid.NewGuid();
            Directory.CreateDirectory(newDir);
            string filePath = Path.Combine(newDir, "Report.xls");

            var response = new ExportResponse {FilePath = filePath};
            using (var xlsConnection = new OleDbConnection(String.Format(ConnectionString, filePath)))
            {
                using (var xlsCommand = new OleDbCommand())
                {
                    xlsCommand.Connection = xlsConnection;
                    xlsConnection.Open();
                    foreach (DataTable table in dataSet.Tables)
                    {
                        string tableName = table.TableName;
                        string sqlString = "Create Table " + tableName + " (";
                        int i;
                        for (i = 0; i < table.Columns.Count; i++)
                        {
                            sqlString = sqlString + "[" + table.Columns[i].ColumnName + "] memo,";
                        }
                        sqlString = sqlString.Substring(0, sqlString.Length - 1);
                        sqlString = sqlString + ")";
                        xlsCommand.CommandText = sqlString;
                        xlsCommand.ExecuteNonQuery();

                        //construct and Insert all the rows
                        for (i = 0; i < table.Rows.Count; i++)
                        {
                            sqlString = "Insert into " + tableName + " values(";
                            for (int j = 0; j < table.Columns.Count; j++)
                            {
                                string value = table.Rows[i][j].ToString();
                                if (!string.IsNullOrEmpty(value))
                                {
                                    value = value.Replace("'", "''");

                                    //In case the value is a datetimefield, export only datetimeshort string value
                                    if (table.Columns[j].DataType == typeof (DateTime))
                                    {
                                        value = DateUtil.GetShortDate(value, string.Empty);
                                    }
                                }
                                sqlString = sqlString + "'" + value + "'" + ",";
                            }
                            sqlString = sqlString.Substring(0, sqlString.Length - 1);
                            sqlString = sqlString + ")";
                            xlsCommand.CommandText = sqlString;
                            xlsCommand.ExecuteNonQuery();
                        }
                        response.StatusText.Add(tableName + " Item Exported Successfully - Total : " + i);
                    }
                    xlsConnection.Close();
                }
            }
            return response;
        }

        /// <summary>
        /// Export method
        /// </summary>
        /// <param name="dataSet">Dataset</param>
        /// <returns>byte array</returns>
        public byte[] Export(DataSet dataSet)
        {
            var response = ExportResponse(dataSet);

            //get the directory
            var directory = Path.GetDirectoryName(response.FilePath);

            //store the byte array
            var result = File.ReadAllBytes(response.FilePath);

            //delete the file
            File.Delete(response.FilePath);

            //delete the directory
            if (directory != null) Directory.Delete(directory, true);

            return result;
        }

        /// <summary>
        /// Import method - Under COnstruction
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>DataSet.</returns>
        public DataSet Import(string filePath)
        {
            var result = new DataSet();
            using (var xlsConnection = new OleDbConnection(String.Format(ConnectionString, filePath)))
            {
                xlsConnection.Open();
                DataTable tableInfo = xlsConnection.GetSchema("Tables");
                foreach (DataRow row in tableInfo.Rows)
                {
                    var table = new DataTable {TableName = row["TABLE_NAME"].ToString()};
                    var commandText = "SELECT * FROM [" + row["TABLE_NAME"] + "]";
                    using (var adapter = new OleDbDataAdapter(commandText, xlsConnection))
                    {
                        adapter.Fill(table);
                    }
                    result.Tables.Add(table);
                    xlsConnection.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// Transform byte array (which is in a excel format) into dataset
        /// </summary>
        /// <param name="bytes">bytes</param>
        /// <returns>Dataset</returns>
        public DataSet Import(Stream bytes)
        {
            throw new NotImplementedException();
        }
    }
}