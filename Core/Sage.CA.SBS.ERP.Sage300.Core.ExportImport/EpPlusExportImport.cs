/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using OfficeOpenXml;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.ExportImport;
using System;
using System.Data;
using System.IO;

namespace Sage.CA.SBS.ERP.Sage300.Core.ExportImport
{
    /// <summary>
    /// EPPlus implementation of export/import
    /// </summary>
    public class EpPlusExportImport : IExportImport
    {
        private const string DateFormat = "yyyy-MM-dd";

        /// <summary>
        /// Export - returns byte array
        /// </summary>
        /// <param name="dataSet">data set</param>
        /// <returns>byte array</returns>
        public byte[] Export(DataSet dataSet)
        {
            using (var p = new ExcelPackage())
            {
                //Here setting some document properties
                p.Workbook.Properties.Author = "Sage ERP";
                p.Workbook.Properties.Title = "Sage 30 ERP";

                foreach (DataTable table in dataSet.Tables)
                {
                    var dt = table;

                    //Create a sheet
                    p.Workbook.Worksheets.Add(dt.TableName);
                    var ws = p.Workbook.Worksheets[dt.TableName];
                    ws.Name = dt.TableName; //Setting Sheet's name
                    ws.Cells.Style.Font.Size = 10;
                    ws.Cells.Style.Font.Name = "MS Sans Serif";
                    var colIndex = 1;
                    var rowIndex = 1;

                    foreach (DataColumn dc in dt.Columns) //Creating Headings
                    {
                        var cell = ws.Cells[rowIndex, colIndex];
                        cell.Value = dc.ColumnName;
                        colIndex++;
                    }

                    for (rowIndex = 0; rowIndex < dt.Rows.Count; rowIndex++) // Adding Data into rows
                    {
                        var dr = dt.Rows[rowIndex];
                        colIndex = 1;
                        foreach (DataColumn dc in dt.Columns)
                        {
                            var cell = ws.Cells[rowIndex + 2, colIndex];
                            //Setting Value in cell
                            var value = dr[dc.ColumnName];
                            if (!string.IsNullOrEmpty(value.ToString()))
                            {
                                var cellValue = value.ToString();
                                DateTime result;
                                if (dc.DataType == typeof(DateTime) && DateTime.TryParse(cellValue, out result))
                                {
                                    cellValue = result.ToString(DateFormat);
                                }
                                cell.Value = cellValue;
                            }
                            colIndex++;
                        }
                    }
                }
                return p.GetAsByteArray();
            }
        }

        /// <summary>
        /// Transform byte array (which is in a excel format) into dataset
        /// </summary>
        /// <param name="bytes">bytes</param>
        /// <returns>Dataset</returns>
        public DataSet Import(Stream bytes)
        {
            var dataSet = new DataSet();
            using (var xlPackage = new ExcelPackage(bytes))
            {
                if (xlPackage.Workbook.Worksheets == null || xlPackage.Workbook.Worksheets.Count == 0)
                {
                    throw new Exception("There is no any work sheet in the excel.");
                }

                // get the first/next worksheet in the workbook
                foreach (var worksheet in xlPackage.Workbook.Worksheets)
                {
                    var dt = new DataTable { TableName = worksheet.Name };

                    if (worksheet.Dimension != null)
                    {
                        // Fetch the WorkSheet size
                        var startCell = worksheet.Dimension.Start;
                        var endCell = worksheet.Dimension.End;

                        // create all the needed DataColumn
                        for (var col = startCell.Column; col <= endCell.Column; col++)
                        {
                            var value = worksheet.Cells[startCell.Row, col].Value;
                            if (value == null) continue;
                            dt.Columns.Add(value.ToString());
                        }

                        // place all the data into DataTable
                        for (var row = startCell.Row + 1; row <= endCell.Row; row++)
                        {
                            var dr = dt.NewRow();
                            var x = 0;
                            for (var col = startCell.Column; col <= endCell.Column; col++)
                            {
                                var value = worksheet.Cells[startCell.Row, col].Value;
                                if (value == null) continue;
                                dr[x++] = worksheet.Cells[row, col].Value;
                            }
                            dt.Rows.Add(dr);
                        }
                        dataSet.Tables.Add(dt);
                    }
                }
            }
            return dataSet;
        }
    }
}
