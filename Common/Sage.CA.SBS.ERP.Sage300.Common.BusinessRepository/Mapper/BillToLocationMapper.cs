// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

#region Namespace

using System;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Mapper
{
     /// <summary>
     /// Class for AdditionalCostTaxe mapping
     /// </summary>
     public class BillToLocationMapper<T> : ModelMapper<T> where T : BillToLocation, new ()
     {
          #region Constructor
          /// <summary>
          /// Constructor to set the Context
          /// </summary>
          /// <param name="context">Context</param>
         public BillToLocationMapper(Context context) 
               : base(context)
          {
          }
          #endregion

          #region IModelMapper methods
          /// <summary>
          /// Get Mapper
          /// </summary>
          /// <param name="entity">Business Entity</param>
          /// <returns>Mapped Model</returns>
          public override T Map(IBusinessEntity entity)
          {
               var model = base.Map(entity);
               model.BillToLoc = entity.GetValue<string>(BillToLocation.Fields.BillToLocation);
               model.BillToLocationDescription = entity.GetValue<string>(BillToLocation.Fields.BillToLocationDescription);
               model.BillToAddress1 = entity.GetValue<string>(BillToLocation.Fields.BillToAddress1);
               model.BillToAddress2 = entity.GetValue<string>(BillToLocation.Fields.BillToAddress2);
               model.BillToAddress3 = entity.GetValue<string>(BillToLocation.Fields.BillToAddress3);
               model.BillToAddress4 = entity.GetValue<string>(BillToLocation.Fields.BillToAddress4);
               model.BillToCity = entity.GetValue<string>(BillToLocation.Fields.BillToCity);
               model.BillToStateProvince = entity.GetValue<string>(BillToLocation.Fields.BillToStateProvince);
               model.BillToZipPostalCode = entity.GetValue<string>(BillToLocation.Fields.BillToZipPostalCode);
               model.BillToCountry = entity.GetValue<string>(BillToLocation.Fields.BillToCountry);
               model.BillToPhoneNumber = entity.GetValue<string>(BillToLocation.Fields.BillToPhoneNumber);
               model.BillToFaxNumber = entity.GetValue<string>(BillToLocation.Fields.BillToFaxNumber);
               model.BillToContact = entity.GetValue<string>(BillToLocation.Fields.BillToContact);
               model.BillToEmail = entity.GetValue<string>(BillToLocation.Fields.BillToEmail);
               model.BillToContactPhone = entity.GetValue<string>(BillToLocation.Fields.BillToContactPhone);
               model.BillToContactFax = entity.GetValue<string>(BillToLocation.Fields.BillToContactFax);
               model.BillToContactEmail = entity.GetValue<string>(BillToLocation.Fields.BillToContactEmail);

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

               entity.SetValue(BillToLocation.Fields.BillToLocationDescription, model.BillToLocationDescription);
               entity.SetValue(BillToLocation.Fields.BillToAddress1, model.BillToAddress1);
               entity.SetValue(BillToLocation.Fields.BillToAddress2, model.BillToAddress2);
               entity.SetValue(BillToLocation.Fields.BillToAddress3, model.BillToAddress3);
               entity.SetValue(BillToLocation.Fields.BillToAddress4, model.BillToAddress4);
               entity.SetValue(BillToLocation.Fields.BillToCity, model.BillToCity);
               entity.SetValue(BillToLocation.Fields.BillToStateProvince, model.BillToStateProvince);
               entity.SetValue(BillToLocation.Fields.BillToZipPostalCode, model.BillToZipPostalCode);
               entity.SetValue(BillToLocation.Fields.BillToCountry, model.BillToCountry);
               entity.SetValue(BillToLocation.Fields.BillToPhoneNumber, model.BillToPhoneNumber);
               entity.SetValue(BillToLocation.Fields.BillToFaxNumber, model.BillToFaxNumber);
               entity.SetValue(BillToLocation.Fields.BillToContact, model.BillToContact);
               entity.SetValue(BillToLocation.Fields.BillToEmail, model.BillToEmail);
               entity.SetValue(BillToLocation.Fields.BillToContactPhone, model.BillToContactPhone);
               entity.SetValue(BillToLocation.Fields.BillToContactFax, model.BillToContactFax);
               entity.SetValue(BillToLocation.Fields.BillToContactEmail, model.BillToContactEmail);
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
