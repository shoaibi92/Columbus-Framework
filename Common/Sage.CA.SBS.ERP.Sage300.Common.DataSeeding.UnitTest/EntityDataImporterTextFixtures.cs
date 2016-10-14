using System;
using System.Data;
using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport;
using Microsoft.Practices.Unity;

namespace Sage.CA.SBS.ERP.Sage300.Common.DataSeeding.UnitTest
{
    [TestClass]
    public class EntityDataImporterTextFixtures
    {
        [TestMethod]
        public void Import_ImportsDataUsingRepository()
        {
            //Arrange
            var context = new Context { Container = new SageUnityContainer() };
            var repository = new Mock<IExportImportRepository>();
            context.Container.RegisterInstance("testselector", repository.Object);
            var importer = new EntityDataImporter(context, new ImportRequest {Name = "testselector"});

            //Act
            importer.Import(It.IsAny<DataSet>());

            //Assert
            repository.Verify(c => c.Import(It.IsAny<DataSet>(), It.IsAny<ImportRequest>()), Times.Once());
        }
    }
}
