/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Web.Utilities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Web
{
    /// <summary>
    /// ExpressionBuilder Test class for implementing unit test methods
    /// </summary>
    [TestClass]
    public class ExpressionBuilderTest
    {
        /// <summary>
        /// Test method for "&lt;=" operator expression
        /// </summary>
        [TestMethod]
        public void TestString_LessThanOrEqualOperator()
        {
            IList<Filter> columnFilters1 = new List<Filter>();
            var field = new GridField { field = "Name", dataType = "string" };
            Filter filter = SetFilter(field, Operator.LessThanOrEqual, "Test");
            columnFilters1.Add(filter);
            IList<IList<Filter>> rowFilters = new List<IList<Filter>>();
            rowFilters.Add(columnFilters1);

            var actual = ExpressionBuilder<Person>.CreateExpression(rowFilters);
            Expression<Func<Person, Boolean>> expected = model => (model.Name.LessThanOrEqual("Test"));
            var expectedFilter = ExpressionHelper.Translate(expected);
            var actualFilter = ExpressionHelper.Translate(actual);
            Assert.AreEqual(expectedFilter, actualFilter);
        }

        /// <summary>
        /// Test method for "&lt;=" operator expression
        /// </summary>
        [TestMethod]
        public void TestEmptyString()
        {
            IList<Filter> columnFilters1 = new List<Filter>();
            var field = new GridField { field = "Name", dataType = "string" };
            Filter filter = SetFilter(field, Operator.Equal, null);
            filter.ApplyFilterIfNull = true;
            columnFilters1.Add(filter);
            IList<IList<Filter>> rowFilters = new List<IList<Filter>>();
            rowFilters.Add(columnFilters1);

            var actual = ExpressionBuilder<Person>.CreateExpression(rowFilters);
            Expression<Func<Person, Boolean>> expected = model => (model.Name == "");
            var expectedFilter = ExpressionHelper.Translate(expected);
            var actualFilter = ExpressionHelper.Translate(actual);
            Assert.AreEqual(expectedFilter, actualFilter);
        }

        /// <summary>
        /// Test method for "=" operator expression
        /// </summary>
        [TestMethod]
        public void TestEqualOperator()
        {
            IList<Filter> columnFilters1 = new List<Filter>();
            IList<Filter> columnFilters2 = new List<Filter>();
            var field = new GridField { field = "Name", dataType = "string" };
            Filter filter = SetFilter(field, Operator.Equal, "Test");
            columnFilters1.Add(filter);
            field = new GridField { field = "Age", dataType = "int" };
            filter = SetFilter(field, Operator.Equal, "10");
            columnFilters1.Add(filter);
            filter = new Filter { Field = new GridField { field = "BirthDate", dataType = "date" } };
            DateTime dt = Convert.ToDateTime("12/12/2013");
            filter.Value = "12/12/2013";
            filter.Operator = Operator.Equal;
            columnFilters2.Add(filter);
            IList<IList<Filter>> rowFilters = new List<IList<Filter>>();
            rowFilters.Add(columnFilters1);
            rowFilters.Add(columnFilters2);

            var actual = ExpressionBuilder<Person>.CreateExpression(rowFilters);
            Expression<Func<Person, Boolean>> expected = model => ((model.Name == "Test" & model.Age == 10) | (model.BirthDate == dt));
            var expectedFilter = ExpressionHelper.Translate(expected);
            var actualFilter = ExpressionHelper.Translate(actual);
            Assert.AreEqual(expectedFilter, actualFilter);
        }

        /// <summary>
        /// Test method for ">,=" operator expression
        /// </summary>
        [TestMethod]
        public void TestGreaterThanExpression()
        {
            IList<Filter> columnFilters1 = new List<Filter>();
            var field = new GridField { field = "Name", dataType = "string" };
            Filter filter = SetFilter(field, Operator.Equal, "testing");
            columnFilters1.Add(filter);
            field = new GridField { field = "Age", dataType = "int" };
            filter = SetFilter(field, Operator.GreaterThan, "20");
            columnFilters1.Add(filter);
            IList<IList<Filter>> rowFilters = new List<IList<Filter>>();
            rowFilters.Add(columnFilters1);
            var actual = ExpressionBuilder<Person>.CreateExpression(rowFilters);

            Expression<Func<Person, Boolean>> expected = model => ((model.Name == "testing" & model.Age > 20));
            var expectedFilter = ExpressionHelper.Translate(expected);
            var actualFilter = ExpressionHelper.Translate(actual);
            Assert.AreEqual(expectedFilter, actualFilter);
        }

        /// <summary>
        /// Test method for ">,&gt;=" operatorExpression
        /// </summary>
        [TestMethod]
        public void TestLessThanGreaterThan()
        {
            IList<Filter> columnFilters1 = new List<Filter>();
            IList<Filter> columnFilters2 = new List<Filter>();
            var field = new GridField { field = "Age", dataType = "int" };
            Filter filter = SetFilter(field, Operator.LessThan, "11");
            columnFilters1.Add(filter);
            field = new GridField { field = "Name", dataType = "string" };
            filter = SetFilter(field, Operator.Equal, "TEST");
            columnFilters1.Add(filter);
            field = new GridField { field = "Age", dataType = "int" };
            filter = SetFilter(field, Operator.GreaterThan, "12");
            columnFilters2.Add(filter);
            IList<IList<Filter>> rowFilters = new List<IList<Filter>>();
            rowFilters.Add(columnFilters1);
            rowFilters.Add(columnFilters2);

            var actual = ExpressionBuilder<Person>.CreateExpression(rowFilters);
            Expression<Func<Person, Boolean>> expected = model => ((model.Age < 11 & model.Name == "TEST") | (model.Age > 12));
            var expectedFilter = ExpressionHelper.Translate(expected);
            var actualFilter = ExpressionHelper.Translate(actual);
            Assert.AreEqual(expectedFilter, actualFilter);
        }

        /// <summary>
        /// Test method for "LIKE" operator
        /// </summary>
        [TestMethod]
        public void TestLikeOperator()
        {
            IList<Filter> columnFilters1 = new List<Filter>();
            var field = new GridField { field = "Name", dataType = "string" };
            Filter filter = SetFilter(field, Operator.Like, "Abc");
            columnFilters1.Add(filter);
            field = new GridField { field = "Name", dataType = "string" };
            filter = SetFilter(field, Operator.Like, "Test");
            columnFilters1.Add(filter);
            IList<IList<Filter>> rowFilters = new List<IList<Filter>>();
            rowFilters.Add(columnFilters1);

            var actual = ExpressionBuilder<Person>.CreateExpression(rowFilters);
            Expression<Func<Person, Boolean>> expected = model => (model.Name.Contains("Abc") & model.Name.Contains("Test"));
            var expectedFilter = ExpressionHelper.Translate(expected);
            var actualFilter = ExpressionHelper.Translate(actual);
            Assert.AreEqual(expectedFilter, actualFilter);
        }

        /// <summary>
        /// Test method for "&lt;,&gt;=,!,&lt;=" operator expression
        /// </summary>
        [TestMethod]
        public void TestRelationalOperators()
        {
            IList<Filter> columnFilters1 = new List<Filter>();
            IList<Filter> columnFilters2 = new List<Filter>();
            var field = new GridField { field = "Age", dataType = "int" };
            Filter filter = SetFilter(field, Operator.LessThanOrEqual, "11");
            columnFilters1.Add(filter);
            field = new GridField { field = "Age", dataType = "int" };
            filter = SetFilter(field, Operator.NotEqual, "22");
            columnFilters1.Add(filter);
            field = new GridField { field = "Age", dataType = "int" };
            filter = SetFilter(field, Operator.GreaterThan, "222");
            columnFilters2.Add(filter);
            field = new GridField { field = "Age", dataType = "int" };
            filter = SetFilter(field, Operator.LessThan, "0");
            columnFilters2.Add(filter);
            IList<IList<Filter>> rowFilters = new List<IList<Filter>>();
            rowFilters.Add(columnFilters1);
            rowFilters.Add(columnFilters2);

            var actual = ExpressionBuilder<Person>.CreateExpression(rowFilters);
            Expression<Func<Person, Boolean>> expected = model => ((model.Age <= 11 & model.Age != 22) | (model.Age > 222 & model.Age < 0));
            var expectedFilter = ExpressionHelper.Translate(expected);
            var actualFilter = ExpressionHelper.Translate(actual);
            Assert.AreEqual(expectedFilter, actualFilter);
        }

        /// <summary>
        /// Test method for "&lt;=,>=,!=" operatorExpression
        /// </summary>
        [TestMethod]
        public void TestAllOperators()
        {
            IList<Filter> columnFilters1 = new List<Filter>();
            IList<Filter> columnFilters2 = new List<Filter>();
            IList<Filter> columnFilters3 = new List<Filter>();
            var field = new GridField { field = "Age", dataType = "int" };
            Filter filter = SetFilter(field, Operator.NotEqual, "1");
            columnFilters1.Add(filter);
            field = new GridField { field = "Age", dataType = "int" };
            filter = SetFilter(field, Operator.LessThanOrEqual, "2");
            columnFilters1.Add(filter);
            field = new GridField { field = "Name", dataType = "string" };
            filter = SetFilter(field, Operator.Equal, "Test1");
            columnFilters2.Add(filter);
            field = new GridField { field = "Age", dataType = "int" };
            filter = SetFilter(field, Operator.LessThan, "4");
            columnFilters2.Add(filter);
            field = new GridField { field = "Age", dataType = "int" };
            filter = SetFilter(field, Operator.GreaterThanOrEqual, "5");
            columnFilters3.Add(filter);
            field = new GridField { field = "Name", dataType = "string" };
            filter = SetFilter(field, Operator.Equal, "Test2");
            columnFilters3.Add(filter);
            IList<IList<Filter>> rowFilters = new List<IList<Filter>>();
            rowFilters.Add(columnFilters1);
            rowFilters.Add(columnFilters2);
            rowFilters.Add(columnFilters3);

            var actual = ExpressionBuilder<Person>.CreateExpression(rowFilters);
            Expression<Func<Person, Boolean>> expected = model => ((model.Age != 1 & model.Age <= 2) | (model.Name == "Test1" & model.Age < 4) | (model.Age >= 5 & model.Name == "Test2"));
            var expectedFilter = ExpressionHelper.Translate(expected);
            var actualFilter = ExpressionHelper.Translate(actual);
            Assert.AreEqual(expectedFilter, actualFilter);
        }

        /// <summary>
        /// Test method for "Startswith" operatorExpression
        /// </summary>
        [TestMethod]
        public void TestStartsWith()
        {
            IList<Filter> columnFilters1 = new List<Filter>();
            var field = new GridField { field = "Name", dataType = "string" };
            Filter filter = SetFilter(field, Operator.StartsWith, "ABC");
            columnFilters1.Add(filter);
            field = new GridField { field = "Name", dataType = "string" };
            filter = SetFilter(field, Operator.StartsWith, "AB");
            columnFilters1.Add(filter);
            IList<IList<Filter>> rowFilters = new List<IList<Filter>>();
            rowFilters.Add(columnFilters1);
            var actual = ExpressionBuilder<Person>.CreateExpression(rowFilters);

            Expression<Func<Person, Boolean>> expected = model => (model.Name.StartsWith("ABC") & model.Name.StartsWith("AB"));
            var expectedFilter = ExpressionHelper.Translate(expected);
            var actualFilter = ExpressionHelper.Translate(actual);
            Assert.AreEqual(expectedFilter, actualFilter);
        }

        /// <summary>
        /// Test method for "Contains" operatorExpression
        /// </summary>
        [TestMethod]
        public void TestContains()
        {
            IList<Filter> columnFilters1 = new List<Filter>();
            var field = new GridField { field = "Name", dataType = "string" };
            Filter filter = SetFilter(field, Operator.Contains, "Testing");
            columnFilters1.Add(filter);
            field = new GridField { field = "Name", dataType = "string" };
            filter = SetFilter(field, Operator.Contains, "Test");
            columnFilters1.Add(filter);
            IList<IList<Filter>> rowFilters = new List<IList<Filter>>();
            rowFilters.Add(columnFilters1);
            var actual = ExpressionBuilder<Person>.CreateExpression(rowFilters);

            Expression<Func<Person, Boolean>> expected = model => (model.Name.Contains("Testing") & model.Name.Contains("Test"));
            var expectedFilter = ExpressionHelper.Translate(expected);
            var actualFilter = ExpressionHelper.Translate(actual);
            Assert.AreEqual(expectedFilter, actualFilter);
        }

        /// <summary>
        /// Sets Filter
        /// </summary>
        /// <param name="field">GridField</param>
        /// <param name="oper">Operator</param>
        /// <param name="value">Value</param>
        /// <returns>Filter</returns>
        private Filter SetFilter(GridField field, Operator oper, string value)
        {
            var filter = new Filter { Field = field, Operator = oper, Value = value };
            return filter;
        }

    }
}