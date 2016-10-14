// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

#region Namespace

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.POVendorInformation;
using System;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Mapper
{
    /// <summary>
    /// POVendorInformationMapper
    /// </summary>
    public class POVendorInformationMapper<T> : ModelMapper<T> where T : VendorBase, new()
    {
        /// <summary>
        /// Constructor to set the Context
        /// </summary>
        /// <param name="context">Context</param>
        public POVendorInformationMapper(Context context)
            : base(context)
        {

        }

        #region IModelMapper methods
        /// <summary>
        /// Get Mapper
        /// </summary>
        /// <param name="entity">Business Entity</param>
        /// <returns>Mapped Model</returns>
        public override T Map(IBusinessEntity entity)
        {
            var model = new T
            {
                Vendor = entity.GetValue<string>(VendorBase.Fields.Vendor),
                Name = entity.GetValue<string>(VendorBase.Fields.Name),
                Address1 = entity.GetValue<string>(VendorBase.Fields.Address1),
                Address2 = entity.GetValue<string>(VendorBase.Fields.Address2),
                Address3 = entity.GetValue<string>(VendorBase.Fields.Address3),
                Address4 = entity.GetValue<string>(VendorBase.Fields.Address4),
                City = entity.GetValue<string>(VendorBase.Fields.City),
                StateProvince = entity.GetValue<string>(VendorBase.Fields.StateProvince),
                ZipPostalCode = entity.GetValue<string>(VendorBase.Fields.ZipPostalCode),
                Country = entity.GetValue<string>(VendorBase.Fields.Country),
                PhoneNumber = entity.GetValue<string>(VendorBase.Fields.PhoneNumber),
                FaxNumber = entity.GetValue<string>(VendorBase.Fields.FaxNumber),
                Contact = entity.GetValue<string>(VendorBase.Fields.Contact),
                Email = entity.GetValue<string>(VendorBase.Fields.Email),
                ContactPhone = entity.GetValue<string>(VendorBase.Fields.ContactPhone),
                ContactFax = entity.GetValue<string>(VendorBase.Fields.ContactFax),
                ContactEmail = entity.GetValue<string>(VendorBase.Fields.ContactEmail)
            };

            return model;
        }

        /// <summary>
        /// SetValue Mapper
        /// </summary>
        /// <param name="model">Model</param>
        /// <param name="entity">Business Entity</param>
        public override void Map(T model, IBusinessEntity entity)
        {
            if (model == null)
            {
                return;
            }

            entity.SetValue(VendorBase.Fields.Vendor, model.Vendor);
            entity.SetValue(VendorBase.Fields.Name, model.Name);
            entity.SetValue(VendorBase.Fields.Address1, model.Address1);
            entity.SetValue(VendorBase.Fields.Address2, model.Address2);
            entity.SetValue(VendorBase.Fields.Address3, model.Address3);
            entity.SetValue(VendorBase.Fields.Address4, model.Address4);
            entity.SetValue(VendorBase.Fields.City, model.City);
            entity.SetValue(VendorBase.Fields.StateProvince, model.StateProvince);
            entity.SetValue(VendorBase.Fields.ZipPostalCode, model.ZipPostalCode);
            entity.SetValue(VendorBase.Fields.Country, model.Country);
            entity.SetValue(VendorBase.Fields.PhoneNumber, model.PhoneNumber);
            entity.SetValue(VendorBase.Fields.FaxNumber, model.FaxNumber);
            entity.SetValue(VendorBase.Fields.Contact, model.Contact);
            entity.SetValue(VendorBase.Fields.Email, model.Email);
            entity.SetValue(VendorBase.Fields.ContactPhone, model.ContactPhone);
            entity.SetValue(VendorBase.Fields.ContactFax, model.ContactFax);
            entity.SetValue(VendorBase.Fields.ContactEmail, model.ContactEmail);
        }

        /// <summary>
        /// Map Key
        /// </summary>
        /// <param name="model">Model</param>
        /// <param name="entity">Business Entity</param>
        /// <exception cref="NotImplementedException"></exception>
        public override void MapKey(T model, IBusinessEntity entity)
        {

        }
        #endregion
    }
}
