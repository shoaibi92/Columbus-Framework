/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Models;
using Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest
{
    /// <summary>
    /// Class ExpressionHelperTest.
    /// </summary>
    [TestClass]
    public class ExpressionHelperTest
    {
        #region Null Expression Check Test Method

        /// <summary>
        /// The batch identifier
        /// </summary>
        private const int BatchId = 25;

        /// <summary>
        /// The vendor number
        /// </summary>
        private const string VendorNumber = "1200";

        /// <summary>
        /// The vendor status
        /// </summary>
        private const int VendorStatus = 1;

        /// <summary>
        /// Test null expression
        /// </summary>
        [TestMethod]
        public void TestNullExpression()
        {
            //Arrange
            var expectedExpression = string.Empty;

            //Actual
            var actualExpression = ExpressionHelper.Translate((Expression<Func<InvoiceBatch, Boolean>>) null);

            //Assert
            Assert.AreEqual(expectedExpression, actualExpression);
        }

        #endregion

        #region Relational Operator(=,>,<,>=,<=,LIKE,!=) Test Methods

        /// <summary>
        /// Test equal expression
        /// </summary>
        [TestMethod]
        public void TestEqualExpression()
        {
            //Arrange
            Expression<Func<InvoiceBatch, Boolean>> filterLamdaExpression = batch => batch.BatchNumber.Value == BatchId;
            var expectedExpression = string.Format("CNTBTCH = {0}", BatchId);

            //Act
            var actualExpression = ExpressionHelper.Translate(filterLamdaExpression);

            //Assert
            Assert.AreEqual(expectedExpression, actualExpression);
        }

        /// <summary>
        /// Test greater than expression
        /// </summary>
        [TestMethod]
        public void TestGreaterThanExpression()
        {
            //Arrange
            Expression<Func<InvoiceBatch, Boolean>> filterLamdaExpression = batch => batch.BatchNumber.Value > BatchId;
            var expectedExpression = string.Format("CNTBTCH > {0}", BatchId);

            //Actual
            var actualExpression = ExpressionHelper.Translate(filterLamdaExpression);

            //Assert
            Assert.AreEqual(expectedExpression, actualExpression);
        }

        /// <summary>
        /// Test greater than or equal to expression
        /// </summary>
        [TestMethod]
        public void TestGreaterThanOrEqualToExpression()
        {
            //Arrange
            Expression<Func<InvoiceBatch, Boolean>> filterLamdaExpression = batch => batch.BatchNumber.Value >= BatchId;
            var expectedExpression = string.Format("CNTBTCH >= {0}", BatchId);

            //Actual
            var actualExpression = ExpressionHelper.Translate(filterLamdaExpression);

            //Assert
            Assert.AreEqual(expectedExpression, actualExpression);
        }

        /// <summary>
        /// Test less than expression
        /// </summary>
        [TestMethod]
        public void TestLessThanExpression()
        {
            //Arrange
            Expression<Func<InvoiceBatch, Boolean>> filterLamdaExpression = batch => batch.BatchNumber.Value < BatchId;
            var expectedExpression = string.Format("CNTBTCH < {0}", BatchId);

            //Actual
            var actualExpression = ExpressionHelper.Translate(filterLamdaExpression);

            //Assert
            Assert.AreEqual(expectedExpression, actualExpression);
        }

        /// <summary>
        /// Test less than or equal to expression
        /// </summary>
        [TestMethod]
        public void TestLessThanOrEqualToExpression()
        {
            //Arrange
            Expression<Func<InvoiceBatch, Boolean>> filterLamdaExpression = batch => batch.BatchNumber.Value <= BatchId;
            var expectedExpression = string.Format("CNTBTCH <= {0}", BatchId);

            //Actual
            var actualExpression = ExpressionHelper.Translate(filterLamdaExpression);

            //Assert
            Assert.AreEqual(expectedExpression, actualExpression);
        }

        /// <summary>
        /// Test not equal to expression
        /// </summary>
        [TestMethod]
        public void TestNotEqualToExpression()
        {
            //Arrange
            Expression<Func<InvoiceBatch, Boolean>> filterLamdaExpression = batch => batch.BatchNumber.Value != BatchId;
            var expectedExpression = string.Format("CNTBTCH != {0}", BatchId);

            //Actual
            var actualExpression = ExpressionHelper.Translate(filterLamdaExpression);

            //Assert
            Assert.AreEqual(expectedExpression, actualExpression);
        }

        /// <summary>
        /// Test contains expression
        /// </summary>
        [TestMethod]
        public void TestContainsExpression()
        {
            //Arrange
            Expression<Func<Vendor, Boolean>> filterLamdaExpression =
                vendor => vendor.VendorNumber.Contains(VendorNumber);
            var expectedExpression = string.Format(@"( VENDORID LIKE ""{0}%"" OR VENDORID LIKE ""%{0}"" OR VENDORID LIKE ""%{0}%"" )", VendorNumber);

            //Actual
            var actualExpression = ExpressionHelper.Translate(filterLamdaExpression);

            //Assert
            Assert.AreEqual(expectedExpression, actualExpression);
        }

        /// <summary>
        /// Test starts with expression
        /// </summary>
        [TestMethod]
        public void TestStartsWithExpression()
        {
            //Arrange
            Expression<Func<Vendor, Boolean>> filterLamdaExpression =
                vendor => vendor.VendorNumber.StartsWith(VendorNumber);
            var expectedExpression = string.Format(@"VENDORID LIKE ""{0}%""", VendorNumber);

            //Actual
            var actualExpression = ExpressionHelper.Translate(filterLamdaExpression);

            //Assert
            Assert.AreEqual(expectedExpression, actualExpression);
        }

        /// <summary>
        /// Test ends with expression
        /// </summary>
        [TestMethod]
        public void TestEndsWithExpression()
        {
            //Arrange
            Expression<Func<Vendor, Boolean>> filterLamdaExpression =
                vendor => vendor.VendorNumber.EndsWith(VendorNumber);
            var expectedExpression = string.Format(@"VENDORID LIKE ""%{0}""", VendorNumber);

            //Actual
            var actualExpression = ExpressionHelper.Translate(filterLamdaExpression);

            //Assert
            Assert.AreEqual(expectedExpression, actualExpression);
        }

        /// <summary>
        /// Test Boolean Field Expression
        /// </summary>
        [TestMethod]
        public void TestBooleanFieldExpression()
        {
            //Arrange
            Expression<Func<AccountSet, Boolean>> filterLamdaExpression = account => account.Status == Status.Active;

            var expectedExpression = string.Format(@"SWACTV = {0}", 1);

            //Actual
            var actualExpression = ExpressionHelper.Translate(filterLamdaExpression);

            //Assert
            Assert.AreEqual(expectedExpression, actualExpression);
        }

        /// <summary>
        /// Test null value to field Expression
        /// </summary>
        [TestMethod]
        public void TestNullValueFieldExpression()
        {
            //Arrange
            Expression<Func<Vendor, Boolean>> filterLamdaExpression = vendor => vendor.VendorNumber != null;

            var expectedExpression = string.Format(@"VENDORID != ""{0}""", "");

            //Actual
            var actualExpression = ExpressionHelper.Translate(filterLamdaExpression);

            //Assert
            Assert.AreEqual(expectedExpression, actualExpression);
        }

        #endregion

        #region Boolean Operator(AND,OR) Test Methods

        /// <summary>
        /// Test boolean AND operator expression
        /// </summary>
        [TestMethod]
        public void TestBooleanAndExpression()
        {
            //Arrange
            Expression<Func<Vendor, Boolean>> filterLamdaExpression =
                vendor => vendor.VendorNumber == VendorNumber & vendor.IsActive;

            var expectedExpression = string.Format(@" ( VENDORID = ""{0}"" )  AND  ( SWACTV = {1} ) ", VendorNumber,
                VendorStatus);

            //Actual
            var actualExpression = ExpressionHelper.Translate(filterLamdaExpression);

            //Assert
            Assert.AreEqual(expectedExpression, actualExpression);
        }

        /// <summary>
        /// Test boolean OR operator expression
        /// </summary>
        [TestMethod]
        public void TestBooleanOrExpression()
        {
            //Arrange
            Expression<Func<Vendor, Boolean>> filterLamdaExpression =
                vendor => vendor.VendorNumber == VendorNumber || vendor.IsActive;

            var expectedExpression = string.Format(@" ( VENDORID = ""{0}"" )  OR  ( SWACTV = {1} ) ", VendorNumber,
                VendorStatus);

            //Actual
            var actualExpression = ExpressionHelper.Translate(filterLamdaExpression);

            //Assert
            Assert.AreEqual(expectedExpression, actualExpression);
        }

        /// <summary>
        /// Test boolean AND operator expression
        /// </summary>
        [TestMethod]
        public void TestBooleanAndOrGroupExpression()
        {
            //Arrange
            const int batchNumber = 25;
            const string batchStatus = "1";
            const decimal batchAmount = 100;
            Expression<Func<InvoiceBatch, Boolean>> filterLamdaExpression =
                batch =>
                    (batch.BatchNumber.Value == batchNumber & batch.Status == BatchStatus.Open) ||
                    batch.AmountTotal == batchAmount;

            var expectedExpression =
                string.Format(@" (  ( CNTBTCH = {0} )  AND  ( BTCHSTTS = {1} )  )  OR  ( AMTENTR = {2} ) ", batchNumber,
                    batchStatus, batchAmount);

            //Actual
            var actualExpression = ExpressionHelper.Translate(filterLamdaExpression);

            //Assert
            Assert.AreEqual(expectedExpression, actualExpression);
        }

        /// <summary>
        /// Test ToString expression
        /// </summary>
        [TestMethod]
        public void TestToStringExpression()
        {
            //Arrange
            object vendorNumber = "25";

            //Arrange
            Expression<Func<Vendor, Boolean>> filterLamdaExpression =
                vendor => vendor.VendorNumber == vendorNumber.ToString();

            var expectedExpression = string.Format(@"VENDORID = ""{0}""", vendorNumber);

            //Actual
            var actualExpression = ExpressionHelper.Translate(filterLamdaExpression);

            //Assert
            Assert.AreEqual(expectedExpression, actualExpression);
        }

        /// <summary>
        /// Test Parameter expression
        /// </summary>
        [TestMethod]
        public void TestOperandParameterExpression()
        {
            var vendorToTest = new Vendor {VendorNumber = "100"};

            //Arrange
            Expression<Func<Vendor, Boolean>> filterLamdaExpression =
                vendor => vendor.VendorNumber == vendorToTest.VendorNumber;

            var expectedExpression = string.Format(@"VENDORID = ""{0}""", vendorToTest.VendorNumber);

            //Actual
            var actualExpression = ExpressionHelper.Translate(filterLamdaExpression);

            //Assert
            Assert.AreEqual(expectedExpression, actualExpression);
        }

        /// <summary>
        /// Test Constant expression
        /// </summary>
        [TestMethod]
        public void TestOperandConstantExpression()
        {
            var vendorToTest = new Vendor {Address = new Address {AddressLine1 = "address1"}};

            //Arrange
            Expression<Func<Vendor, Boolean>> filterLamdaExpression =
                vendor => vendor.VendorNumber == vendorToTest.Address.AddressLine1;

            var expectedExpression = string.Format(@"VENDORID = ""{0}""", vendorToTest.Address.AddressLine1);

            //Actual
            var actualExpression = ExpressionHelper.Translate(filterLamdaExpression);

            //Assert
            Assert.AreEqual(expectedExpression, actualExpression);
        }

        /// <summary>
        /// Test Nested expression
        /// </summary>
        [TestMethod]
        public void TestNestedToStringExpression()
        {
            var vendorToTest = new Vendor
            {
                Activity = new VendorActivity {LargestInvoiceVendCurr = new ActivityDetail {Amount = 100}}
            };

            //Arrange
            Expression<Func<Vendor, Boolean>> filterLamdaExpression =
                vendor => vendor.VendorNumber == vendorToTest.Activity.LargestInvoiceVendCurr.Amount.ToString();

            var expectedExpression = string.Format(@"VENDORID = ""{0}""",
                vendorToTest.Activity.LargestInvoiceVendCurr.Amount);

            //Actual
            var actualExpression = ExpressionHelper.Translate(filterLamdaExpression);

            //Assert
            Assert.AreEqual(expectedExpression, actualExpression);
        }

        /// <summary>
        /// Test Array expression
        /// </summary>
        [TestMethod]
        public void TestArrayExpression()
        {
            var vendorToTest = new Vendor
            {
                Statistics = new VendorStatistics {StatisticsListItems = new List<StatisticsItem>()}
            };
            var item = new StatisticsItem {Amount = 100, TransactionType = TransactionType.Adjustments};
            vendorToTest.Statistics.StatisticsListItems.Add(item);

            //Arrange
            Expression<Func<Vendor, Boolean>> filterLamdaExpression =
                vendor => vendor.VendorNumber == vendorToTest.Statistics.StatisticsListItems[0].TransactionTypeString;

            var expectedExpression = string.Format(@"VENDORID = ""{0}""",
                vendorToTest.Statistics.StatisticsListItems[0].TransactionTypeString);

            //Actual
            var actualExpression = ExpressionHelper.Translate(filterLamdaExpression);

            //Assert
            Assert.AreEqual(expectedExpression, actualExpression);
        }

        /// <summary>
        /// Test Column expression
        /// </summary>
        [TestMethod]
        public void TestColumnExpression()
        {
            //Arrange
            Expression<Func<Vendor, Boolean>> filterLamdaExpression =
                vendor => vendor.Address.AddressLine1 == vendor.VendorNumber;

            //Actual
            var actualExpression = ExpressionHelper.Translate(filterLamdaExpression);

            //Assert
            Assert.AreEqual("TEXTSTRE1 = VENDORID", actualExpression);
        }

        /// <summary>
        /// Test Nested expression
        /// </summary>
        [TestMethod]
        public void TestLamdaExpression()
        {
            var vendorToTest = new Vendor {VendorNumber = "100"};
            //Arrange
            Expression<Func<Vendor, Boolean>> filterLamdaExpression =
                vendor => vendor.IsActive == (vendorToTest.VendorNumber == "100");

            //Actual
            var actualExpression = ExpressionHelper.Translate(filterLamdaExpression);

            //Assert
            Assert.AreEqual("SWACTV = 1", actualExpression);
        }

        /// <summary>
        /// Test Nested expression
        /// </summary>
        [TestMethod]
        public void TestNestedLambdaExpression()
        {
            var vendorToTest = new Vendor {VendorNumber = "100"};
            //Arrange
            Expression<Func<Vendor, Boolean>> filterLamdaExpression =
                vendor => vendor.IsActive == (vendorToTest.VendorNumber == "100" || vendorToTest.VendorNumber == "200");

            //Actual
            var actualExpression = ExpressionHelper.Translate(filterLamdaExpression);

            //Assert
            Assert.AreEqual("SWACTV = 1", actualExpression);
        }

        /// <summary>
        /// Test Nested expression
        /// </summary>
        [TestMethod]
        public void TestNestedLambdaExpression2()
        {
            var vendorToTest = new Vendor {VendorNumber = "100"};
            //Arrange
            Expression<Func<Vendor, Boolean>> filterLamdaExpression =
                vendor => (vendorToTest.VendorNumber == "100") && (vendor.IsActive && vendor.IsActive);

            //Actual
            var actualExpression = ExpressionHelper.Translate(filterLamdaExpression);

            //Assert
            Assert.AreEqual(" ( \"100\" = \"100\" )  AND  (  ( SWACTV = 1 )  AND  ( SWACTV = 1 )  ) ", actualExpression);
        }

        /// <summary>
        /// Test Boolean expression
        /// </summary>
        [TestMethod]
        public void TestBooleanExpression3()
        {
            //Arrange
            Expression<Func<Vendor, Boolean>> filterLamdaExpression =
                vendor => vendor.IsActive == Convert.ToBoolean("True");

            //Actual
            var actualExpression = ExpressionHelper.Translate(filterLamdaExpression);

            //Assert
            Assert.AreEqual("SWACTV = 1", actualExpression);
        }

        /// <summary>
        /// Test Boolean expression
        /// </summary>
        [TestMethod]
        public void TestBooleanExpression()
        {
            var vendorToTest = new Vendor();

            //Arrange
            Expression<Func<Vendor, Boolean>> filterLamdaExpression =
                vendor => vendor.IsActive == !vendorToTest.IsActive;

            //Actual
            var actualExpression = ExpressionHelper.Translate(filterLamdaExpression);

            //Assert
            Assert.AreEqual("SWACTV = 1", actualExpression);
        }

        /// <summary>
        /// Test Boolean expression
        /// </summary>
        [TestMethod]
        public void TestBooleanExpression2()
        {
            //Arrange
            Expression<Func<Vendor, Boolean>> filterLamdaExpression = vendor => !vendor.IsActive;

            //Actual
            var actualExpression = ExpressionHelper.Translate(filterLamdaExpression);

            //Assert
            Assert.AreEqual("SWACTV != 1", actualExpression);
        }

        /// <summary>
        /// Test Covert To Int expression
        /// </summary>
        [TestMethod]
        public void TestConvertExpression()
        {
            object id = 100;
            //Arrange
            Expression<Func<InvoiceBatch, Boolean>> filterLamdaExpression =
                batch => batch.BatchNumber.Value == Convert.ToInt16(id);

            //Actual
            var actualExpression = ExpressionHelper.Translate(filterLamdaExpression);

            //Assert
            Assert.AreEqual("CNTBTCH = 100", actualExpression);
        }

        /// <summary>
        /// Test String Comparison
        /// </summary>
        [TestMethod]
        public void TestStringComparisonExpression()
        {
            //Arrange
            Expression<Func<InvoiceBatch, Boolean>> filterLamdaExpression =
                batch => batch.BatchDescription.LessThanOrEqual("0");

            //Actual
            var actualExpression = ExpressionHelper.Translate(filterLamdaExpression);

            //Assert
            Assert.AreEqual(@"BTCHDESC <= ""0""", actualExpression);
        }

        #endregion
    }
}