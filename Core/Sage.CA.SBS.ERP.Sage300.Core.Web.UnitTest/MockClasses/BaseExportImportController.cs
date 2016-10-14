﻿using System.Collections.Generic;
using System.Web.Mvc;
 using Moq;
﻿using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Controller;
﻿using Sage.CA.SBS.ERP.Sage300.Common.Models;
﻿using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Process;
﻿using Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport;

namespace Sage.CA.SBS.ERP.Sage300.Core.Web.UnitTest.MockClasses
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseExportImportControllerInternal
    {
        /// <summary>
        /// Mocks the Export Item
        /// </summary>
        /// <param name="mock">The mock.</param>
        /// <returns>Mock&lt;IExportImportController&lt;&gt;&gt;.</returns>
        public Mock<IExportImportController> MockExportItems(Mock<IExportImportController> mock)
        {
            mock.Setup(x => x.ExportItems(It.IsAny<ExportRequest>())).Returns(FakeExportRequest());
            return mock;
        }


        /// <summary>
        /// Mocks the Export Import Options Item
        /// </summary>
        /// <param name="mock">The mock.</param>
        /// <returns>Mock of IExportImportController</returns>
        public Mock<IExportImportController> MockExportImportOptions(Mock<IExportImportController> mock)
        {
            mock.Setup(x => x.Options()).Returns(FakeSelectItemList());
            return mock;
        }


        /// <summary>
        /// Mocks the Export
        /// </summary>
        /// <param name="mock">The mock.</param>
        /// <returns>Mock of IExportImportController</returns>
        public Mock<IExportImportController> MockExport(Mock<IExportImportController> mock)
        {
            mock.Setup(x => x.Export(It.IsAny<ExportRequest>())).Returns(FakeExportResponse());
            return mock;
        }



        /// <summary>
        /// Mocks the Import
        /// </summary>
        /// <param name="mock">The mock.</param>
        /// <returns>Mock of IExportImportController</returns>
        public Mock<IExportImportController> MockImport(Mock<IExportImportController> mock)
        {
            mock.Setup(x => x.Import(It.IsAny<ImportRequest>())).Returns(FakeImportResponse());
            return mock;
        }



        /// <summary>
        /// Mocks the Export Status
        /// </summary>
        /// <param name="mock">The mock.</param>
        /// <returns>Mock of IExportImportController</returns>
        public Mock<IExportImportController> MockExportStatus(Mock<IExportImportController> mock)
        {
            mock.Setup(x => x.ExportStatus(It.IsAny<ExportResponse>())).Returns(FakeExportResponse);
            return mock;
        }



        /// <summary>
        /// Mocks the Import Status
        /// </summary>
        /// <param name="mock">The mock.</param>
        /// <returns>Mock of IExportImportController</returns>
        public Mock<IExportImportController> MockImportStatus(Mock<IExportImportController> mock)
        {
            mock.Setup(x => x.ImportStatus(It.IsAny<ImportResponse>())).Returns(FakeImportResponse);
            return mock;
        }


        /// <summary>
        /// Fake ExportRequest
        /// </summary>
        /// <returns>ExportRequest</returns>
        private ExportRequest FakeExportRequest()

        {

            return new ExportRequest
            {
                Name = "sourcecode",
                DataMigrationList =
                    new List<DataMigration>
                    {
                        new DataMigration
                        {
                            Items =
                                new List<BusinessEntityField>
                                {
                                    new BusinessEntityField
                                    {
                                        title = "Description",
                                        field = "Description",
                                        columnName = "Description"
                                    },
                                },
                        }
                    }
            };

        }

        /// <summary>
        /// Fake ExportRequest
        /// </summary>
        /// <returns>ExportRequest</returns>
        private ImportResponse FakeImportResponse()
        {
            return new ImportResponse {Status = ProcessStatus.Completed,};
        }



        /// <summary>
        /// Fake ExportRequest
        /// </summary>
        /// <returns>ExportRequest</returns>
        private IEnumerable<SelectListItem> FakeSelectItemList()
        {
            return new List<SelectListItem> {new SelectListItem {Text = "Description", Value = "Description"}};
        }



        /// <summary>
        /// Fake ExportRequest
        /// </summary>
        /// <returns>ExportRequest</returns>
        private ExportResponse FakeExportResponse()
        {
            return new ExportResponse
            {
                FileName = "SourceCodeFile",
                Name = "SourceCode",
                Status = ProcessStatus.Completed
            };

        }

    }

}