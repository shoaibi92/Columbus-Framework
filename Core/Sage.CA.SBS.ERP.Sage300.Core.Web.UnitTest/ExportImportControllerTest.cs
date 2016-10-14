
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Controller;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport;
using Sage.CA.SBS.ERP.Sage300.Core.Web.UnitTest.MockClasses;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Blob;
using Sage.CA.SBS.ERP.Sage300.Core.Web.Controllers;
using Sage.CA.SBS.ERP.Sage300.Core.Web.Models;
using System;
using System.Collections.Generic;


namespace Sage.CA.SBS.ERP.Sage300.Core.Web.UnitTest
{

    /// <summary>
    /// Export Import Controller Test
    /// </summary>
    [TestClass]
    public class ExportImportTest
    {
        
        #region Private Variables
        /// <summary>
        /// Base Context that will be used
        /// </summary>
        private Context Context;



        /// <summary>
        /// Mock instance of the controller called by the controller
        /// </summary>
        private Mock<IExportImportController> _mock;



        /// <summary>
        /// Mock instance of the blob called by the controller
        /// </summary>
        private Mock<IBlobContainerFactory> _blobMock;
        
        private BaseExportImportControllerInternal _baseController;

        #endregion



        #region Private Methods
        /// <summary>
        /// Creates a context and assigns to Context
        /// </summary>
        private void CreateContext()
        {
            Context = new Context
            {
                SessionId = "dmpg2qrxq2zvuequ22jtmyh2",
                ContextToken = Guid.NewGuid(),
                Container = new UnityContainer(),
                ScreenContext = new ScreenContext()
            };

        }

        /// <summary>
        /// Creates a context and assigns to Context
        /// </summary>
        private void Register()
        {
            _mock = new Mock<IExportImportController>();
            Context.Container.RegisterInstance("sourcecode", _mock.Object);
            _blobMock = new Mock<IBlobContainerFactory>();
            Context.Container.RegisterInstance(_blobMock.Object);
        }

        
        /// <summary>
        /// Fake ExportRequest
        /// </summary>
        /// <returns>ExportRequest</returns>
        private ExportRequest GetExportRequest()
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
                    },
            };
        }



        private ExportImportViewModel FakeViewModel()
        {
            return new ExportImportViewModel {Name = "sourcecode", ExportRequest = GetExportRequest()};
        }

        #endregion



        #region Test Cases

        /// <summary>
        /// Export Index Test
        /// </summary>
        [TestMethod]
        public void ExportIndexTest()
        {
            CreateContext();
            Register();
            var viewModel = FakeViewModel();
            var controller = new ExportImportController(Context.Container)
            {
                ControllerInternal = new ExportImportControllerInternal(Context)
            };
            _baseController = new BaseExportImportControllerInternal();
            _mock = _baseController.MockExportItems(_mock);
            var data = controller.ExportIndex(viewModel);
            Assert.IsNotNull(((ExportImportViewModel) (data.Model)).ExportRequest, "This cannot be empty");
        }



        /// <summary>
        /// Export Import Options Test
        /// </summary>
        [TestMethod]
        public void ExportImportOptions()
        {
            CreateContext();
            Register();
            var viewModel = FakeViewModel();
            var controller = new ExportImportController(Context.Container)
            {
                ControllerInternal = new ExportImportControllerInternal(Context)
            };
            _baseController = new BaseExportImportControllerInternal();
            _mock = _baseController.MockExportImportOptions(_mock);
            var data = controller.ExportImportOptions(viewModel);
            Assert.IsNotNull(((ExportImportViewModel) (data.Model)).Options, "This cannot be empty");

        }


        /// <summary>
        ///  Export Test
        /// </summary>
        [TestMethod]
        public void Export()
        {

            CreateContext();
            Register();
            var viewModel = FakeViewModel();
            var controller = new ExportImportController(Context.Container)
            {
                ControllerInternal = new ExportImportControllerInternal(Context)
            };
            _baseController = new BaseExportImportControllerInternal();
            _mock = _baseController.MockExport(_mock);
            var data = controller.Export(viewModel);
            Assert.IsNotNull(data, "This cannot be empty");
        }


        /// <summary>
        /// Import Index Test
        /// </summary>
        [TestMethod]
        public void ImportIndex()
        {
            CreateContext();
            Register();
            var viewModel = FakeViewModel();
            var controller = new ExportImportController(Context.Container)
            {
                ControllerInternal = new ExportImportControllerInternal(Context)
            };
            var data = controller.ImportIndex(viewModel);
            Assert.AreEqual((data).ViewName, "Import", "Actual and Expected result are not matching");
        }





        /// <summary>
        /// Import Test
        /// </summary>
        [TestMethod]
        public void Import()
        {

            CreateContext();
            Register();
            var viewModel = FakeViewModel();
            var controller = new ExportImportController(Context.Container)
            {
                ControllerInternal = new ExportImportControllerInternal(Context)
            };
            _baseController = new BaseExportImportControllerInternal();
            _mock = _baseController.MockImport(_mock);
            var data = controller.Import(viewModel);
            Assert.IsNotNull(data, "This cannot be empty");
        }



        /// <summary>
        /// Progress Test
        /// </summary>
        [TestMethod]
        public void Progress()
        {
           CreateContext();
            Register();
            var viewModel = FakeViewModel();
            var controller = new ExportImportController(Context.Container)
            {
                ControllerInternal = new ExportImportControllerInternal(Context)
            };
            _baseController = new BaseExportImportControllerInternal();
            _mock = _baseController.MockExportStatus(_mock);
            var data = controller.Progress(viewModel);
            Assert.IsNotNull(data, "This cannot be empty");
        }



        /// <summary>
        /// Import Progress Test
        /// </summary>
        [TestMethod]
        public void ImportProgress()
        {
            CreateContext();
            Register();
            var viewModel = FakeViewModel();
            var controller = new ExportImportController(Context.Container)
            {
                ControllerInternal = new ExportImportControllerInternal(Context)
            };
            _baseController = new BaseExportImportControllerInternal();
            _mock = _baseController.MockImportStatus(_mock);
            var data = controller.ImportProgress(viewModel);
            Assert.IsNotNull(data, "This cannot be empty");
        }



        /// <summary>
        /// Save Scripts Test
        /// </summary>
        [TestMethod]
        public void SaveScripts()
        {
            CreateContext();
            Register();
            var viewModel = FakeViewModel();
            var controller = new ExportImportController(Context.Container)
            {
                ControllerInternal = new ExportImportControllerInternal(Context)
            };
            var data = controller.SaveScripts(viewModel);
            Assert.IsNotNull(data, "This cannot be empty");

        }



        ///// <summary>
        ///// Get Blob Reference Test
        ///// </summary>
        //[TestMethod]
        //public void GetBlobReference()
        //{
        //    CreateContext();
        //    Register();
        //    var controller = new ExportImportController(Context.Container)
        //    {
        //        ControllerInternal = new ExportImportControllerInternal(Context)
        //    };
        //    var data = controller.GetBlobReference("SourceCode", "Export");
        //    Assert.IsNotNull(data, "This cannot be empty");

        //}



        ///// <summary>
        ///// Upload File To Blob Test
        ///// </summary>
        //[TestMethod]
        //public void UploadFileToBlob()
        //{
        //    CreateContext();
        //    Register();
        //    var controller = new ExportImportController(Context.Container)
        //    {
        //        ControllerInternal = new ExportImportControllerInternal(Context)
        //    };
        //    var data = controller.UploadFileToBlob();
        //    Assert.IsNotNull(data, "This cannot be empty");
        //}

        #endregion



    }

}