/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Models;

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest
{
    /// <summary>
    /// Unit Test for Helper methods
    /// </summary>
    [TestClass]
    public class HelperTest
    {
        /// <summary>
        /// Test - Compare method
        /// </summary>
        [TestMethod]
        public void TestCompare()
        {
            #region Compare premitive properties

            var oldVendor = new Vendor();
            var vendor1 = new Vendor
            {
                VendorNumber = "1001",
                IsActive = true,
                Address = new Address {AddressLine1 = "Line1"}
            };
            var list = Helper.Compare(typeof (Vendor), oldVendor, vendor1);
            Assert.AreEqual(3, list.Count, "Comparison failed");

            #endregion

            #region Compare IEnumeration property, where value is null in one of the model
            var vendor2 = new Vendor
            {
                VendorNumber = "1001",
                IsActive = true,
                Address = new Address {AddressLine1 = "Line1"},
                Addresses = new List<Address> {new Address {AddressLine1 = "Line1"}}
            };
            list = Helper.Compare(typeof(Vendor), vendor1, vendor2);
            Assert.AreEqual(1, list.Count, "Comparison failed");
            Assert.AreEqual("Addresses[0]", list.ToList()[0].Key, "Key Mismatch");

            #endregion

            #region Compare IEnumeration property, where internal peoperty of the first/second object changed

            var vendor3 = new Vendor
            {
                VendorNumber = "1001",
                IsActive = true,
                Address = new Address {AddressLine1 = "Line1"},
                Addresses = new List<Address> {new Address {AddressLine1 = "Line2"}}
            };
            list = Helper.Compare(typeof(Vendor), vendor2, vendor3);
            Assert.AreEqual(1, list.Count, "Comparison failed");
            Assert.AreEqual("Addresses[0].AddressLine1", list.ToList()[0].Key, "Key Mismatch");

            #endregion

            #region Test Merge Method, in case first enumeration item is null

            var model = Helper.Merge(list, vendor2);
            list = Helper.Compare(typeof(Vendor), vendor3, model);
            Assert.AreEqual(0, list.Count, "Merge Successful");

            #endregion
        }

        /// <summary>
        /// Test - Merge method, when there is a new item added in Enumerable response object (which is empty in begining)
        /// </summary>
        [TestMethod]
        public void TestMerge()
        {
            #region Compare primitive properties

            var oldModel = new Vendor();
            var newModel = new Vendor();

            var addresses = new List<Address>
            {
                new Address {AddressLine1 = "Line1"}
            };
            newModel.AddressesAsEnumerableResponse.Items = addresses;

            var differences = Helper.Compare(typeof(Vendor), oldModel, newModel);
            Assert.AreEqual(1, differences.Count, "Failed to find the extra address");

            var model = Helper.Merge(differences, oldModel);
            differences = Helper.Compare(typeof(Vendor), newModel, model);
            Assert.AreEqual(0, differences.Count, "Failed to merge the extra address");

            var addresses1 = new List<Address>
            {
                new Address {AddressLine1 = "Line1"},
                new Address {AddressLine1 = "Line2"}
            };
            newModel.AddressesAsEnumerableResponse.Items = addresses1;
            oldModel.AddressesAsEnumerableResponse.Items = addresses;
            differences = Helper.Compare(typeof(Vendor), oldModel, newModel);
            Assert.AreEqual(1, differences.Count, "Failed to find the second address");

            model = Helper.Merge(differences, oldModel);
            differences = Helper.Compare(typeof(Vendor), newModel, model);
            Assert.AreEqual(0, differences.Count, "Failed to merge the second address");

            //TODO: Test the case where newModel has less addresses than the oldModel

            #endregion
        }

        /// <summary>
        /// Test - Merge method, when there is a new item added in Enumerable response object(which already have some item in begining)
        /// </summary>
        [TestMethod]
        public void TestMerge1()
        {
            #region Compare premitive properties

            var oldModel = new Vendor();
           

            var addresses = new List<Address>
            {
                new Address {AddressLine1 = "Line1"}
            };
            oldModel.AddressesAsEnumerableResponse.Items = addresses;

            var newModel = new Vendor();
            var addresses1 = new List<Address>
            {
                new Address {AddressLine1 = "Line1"},
                new Address {AddressLine1 = "Line2"}
            };
            newModel.AddressesAsEnumerableResponse.Items = addresses1;
            var list = Helper.Compare(typeof(Vendor), oldModel, newModel);
            var model = Helper.Merge(list, oldModel);
            list = Helper.Compare(typeof(Vendor), newModel, model);
            Assert.AreEqual(0, list.Count, "Merge Successful");

            #endregion
        }

        /// <summary>
        /// Test - Merge method, when there is an item deleted in Enumerable response object(isdeleted = true)
        /// </summary>
        [TestMethod]
        public void TestMerge2()
        {
            #region Compare premitive properties

            var oldModel = new Vendor();


            var addresses = new List<Address>
            {
                new Address {AddressLine1 = "Line1"},
                new Address {AddressLine1 = "Line2"}
            };
            oldModel.AddressesAsEnumerableResponse.Items = addresses;

            var newModel = new Vendor();
            var addresses1 = new List<Address>
            {
                new Address {AddressLine1 = "Line1"},
                new Address {AddressLine1 = "Line2", IsDeleted = true}
            };
            newModel.AddressesAsEnumerableResponse.Items = addresses1;
            var list = Helper.Compare(typeof(Vendor), oldModel, newModel);
            var model = Helper.Merge(list, oldModel);
            list = Helper.Compare(typeof(Vendor), newModel, model);
            Assert.AreEqual(0, list.Count, "Merge Successful");

            #endregion
        }
    }
}
