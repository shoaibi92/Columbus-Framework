using System.Collections.Generic;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sage.CA.SBS.ERP.Sage300.Common.Exceptions;
using Sage.CA.SBS.ERP.Sage300.Common.DataSeeding.Interfaces;
using Moq;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.DataSeeding.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using System;

namespace Sage.CA.SBS.ERP.Sage300.Common.DataSeeding.UnitTest
{
    [TestClass]
    public class EntityDataSeederTestFixture
    {
        [TestMethod]
        public void Seed_Fails_IfCurrencyTableNameIsInvalid()
        {
            //Arrange
            var currencyField = new CurrencyFieldInfo {TableName = "WrongTable", FieldName = "Field"};
            var data = new DataSet();
            data.Tables.Add(new DataTable("Table"));

            var provider = new Mock<IEntityDataProvider>();
            provider.Setup(p => p.GetData()).Returns(data);
            var importer = new Mock<IEntityDataImporter>();
            var seeder = new EntityDataSeeder("Test-Entity", provider.Object, importer.Object, currencyField);

            //Act 
            var response = seeder.Seed("CAD");

            //Assert
            Assert.IsTrue(response.Errors.Count == 1);
            Assert.IsTrue(response.Errors[0] == string.Format(DataSeedingResx.InvalidTableName, currencyField.TableName));
        }

        [TestMethod]
        public void Seed_Fails_IfCurrencyFieldNameIsInvalid()
        {
            //Arrange
            var currencyField = new CurrencyFieldInfo { TableName = "Table", FieldName = "WrongField" };
            var data = new DataSet();
            data.Tables.Add(new DataTable("Table"));

            var provider = new Mock<IEntityDataProvider>();
            provider.Setup(p => p.GetData()).Returns(data);
            var importer = new Mock<IEntityDataImporter>();
            var seeder = new EntityDataSeeder("Test-Entity", provider.Object, importer.Object, currencyField);

            //Act 
            var response = seeder.Seed("CAD");

            //Assert
            Assert.IsTrue(response.Errors.Count == 1);
            Assert.IsTrue(response.Errors[0] == string.Format(DataSeedingResx.InvalidFieldName, currencyField.FieldName));
        }

        [TestMethod]
        public void Seed_UpdateCurrencyFields()
        {
            //Arrange
            var currencyField1 = new CurrencyFieldInfo { TableName = "Table", FieldName = "CurrencyField1" };
            var currencyField2 = new CurrencyFieldInfo { TableName = "Table", FieldName = "CurrencyField2" };
            var data = new DataSet();
            var dt = new DataTable("Table");
            dt.Columns.Add(new DataColumn("CurrencyField1", typeof(string)));
            dt.Columns.Add(new DataColumn("CurrencyField2", typeof(string)));
            data.Tables.Add(dt);
            for (var i = 0; i < 10; i++)
            {
                var dr = dt.NewRow();
                dr["CurrencyField1"] = "XXX";
                dr["CurrencyField2"] = "XXX";
                dt.Rows.Add(dr);
            }

            var provider = new Mock<IEntityDataProvider>();
            provider.Setup(p => p.GetData()).Returns(data);
            var importer = new Mock<IEntityDataImporter>();
            importer.Setup(p => p.Import(It.IsAny<DataSet>())).Returns(new ImportResponse());
            var seeder = new EntityDataSeeder("Test-Entity", provider.Object, importer.Object, currencyField1, currencyField2);

            //Act 
            var response = seeder.Seed("CAD");

            //Assert
            Assert.IsTrue(response.Errors.Count == 0);
            foreach (DataRow row in dt.Rows)
            {
                Assert.IsTrue(Convert.ToString(row["CurrencyField1"]) == "CAD");
                Assert.IsTrue(Convert.ToString(row["CurrencyField2"]) == "CAD");
            }
        }

        [TestMethod]
        public void Seed_HandlesBusinessExceptions()
        {
            //Arrange
            var data = new DataSet();
            data.Tables.Add(new DataTable("Table"));

            var provider = new Mock<IEntityDataProvider>();
            provider.Setup(p => p.GetData())
                .Throws(new BusinessException(string.Empty,
                    new List<EntityError> {new EntityError {Priority = Priority.Error, Message = "Exception Message"}}));

            var importer = new Mock<IEntityDataImporter>();
            var seeder = new EntityDataSeeder("Test-Entity", provider.Object, importer.Object);

            //Act 
            var response = seeder.Seed("CAD");

            //Assert
            Assert.IsTrue(response.Errors.Count == 1);
            Assert.IsTrue(response.Errors[0] == "Exception Message"); 
        }

        [TestMethod]
        public void Seed_GetsDataFromDataProvider()
        {
            //Arrange
            var provider = new Mock<IEntityDataProvider>();
            provider.Setup(x => x.GetData()).Returns(It.IsAny<DataSet>);
            var importer = new Mock<IEntityDataImporter>();
            importer.Setup(x => x.Import(It.IsAny<DataSet>())).Returns(new ImportResponse());
            var seeder = new EntityDataSeeder("Test-Entity", provider.Object, importer.Object);

            //Act 
            seeder.Seed("CAD");

            //Assert
            provider.Verify(x => x.GetData(), Times.Once);
        }

        [TestMethod]
        public void Seed_ImportsDataUsingDataImporter()
        {
            //Arrange
            var provider = new Mock<IEntityDataProvider>();
            provider.Setup(x => x.GetData()).Returns(It.IsAny<DataSet>);
            var importer = new Mock<IEntityDataImporter>();
            importer.Setup(x => x.Import(It.IsAny<DataSet>())).Returns(new ImportResponse());
            var seeder = new EntityDataSeeder("Test-Entity", provider.Object, importer.Object);

            //Act 
            seeder.Seed("CAD");

            //Assert
            importer.Verify(x => x.Import(It.IsAny<DataSet>()), Times.Once);
        }

    }
}
