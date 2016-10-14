using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.DropShipment;
using Sage.CA.SBS.ERP.Sage300.Common.Models.PODropShipment;

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Mapper
{
    /// <summary>
    /// DropShipAddressMapper
    /// </summary>
    public class DropShipAddressMapper<T> : ModelMapper<T> where T : DropShipAddress, new()
    {
        /// <summary>
        /// Constructor to set the Context
        /// </summary>
        /// <param name="context">Context</param>
        public DropShipAddressMapper(Context context)
            : base(context)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="entity"></param>
        public override void Map(T model, Common.Interfaces.Entity.IBusinessEntity entity)
        {
            if (model == null)
            {
                model = new T();
            }
            
            entity.SetValue(DropShipAddress.Fields.DropShipmentType, model.DropShipmentType);
            entity.SetValue(DropShipAddress.Fields.DropShipLocation, model.DropShipLocation);
            entity.SetValue(DropShipAddress.Fields.DropShipCustomer, model.DropShipCustomer);
            entity.SetValue(DropShipAddress.Fields.CustomerShipToAddress, model.CustomerShipToAddress);
            entity.SetValue(DropShipAddress.Fields.DropShipDescription, model.DropShipDescription);
            entity.SetValue(DropShipAddress.Fields.DropShipAddress1, model.DropShipAddress1);
            entity.SetValue(DropShipAddress.Fields.DropShipAddress2, model.DropShipAddress2);
            entity.SetValue(DropShipAddress.Fields.DropShipAddress3, model.DropShipAddress3);
            entity.SetValue(DropShipAddress.Fields.DropShipAddress4, model.DropShipAddress4);
            entity.SetValue(DropShipAddress.Fields.DropShipCity, model.DropShipCity);
            entity.SetValue(DropShipAddress.Fields.DropShipStateProvince, model.DropShipStateProvince);
            entity.SetValue(DropShipAddress.Fields.DropShipZipPostalCode, model.DropShipZipPostalCode);
            entity.SetValue(DropShipAddress.Fields.DropShipCountry, model.DropShipCountry);
            entity.SetValue(DropShipAddress.Fields.DropShipPhoneNumber, model.DropShipPhoneNumber);
            entity.SetValue(DropShipAddress.Fields.DropShipFaxNumber, model.DropShipFaxNumber);
            entity.SetValue(DropShipAddress.Fields.DropShipContact, model.DropShipContact);
            entity.SetValue(DropShipAddress.Fields.DropShipEmail, model.DropShipEmail);
            entity.SetValue(DropShipAddress.Fields.DropShipContactPhone, model.DropShipContactPhone);
            entity.SetValue(DropShipAddress.Fields.DropShipContactFax, model.DropShipContactFax);
            entity.SetValue(DropShipAddress.Fields.DropShipContactEmail, model.DropShipContactEmail);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public new T Map(Common.Interfaces.Entity.IBusinessEntity entity)
        {
            var model = new T
            {
                DropShipmentType = (DropShipmentType)entity.GetValue<int>(DropShipAddress.Fields.DropShipmentType),
                DropShipLocation = entity.GetValue<string>(DropShipAddress.Fields.DropShipLocation),
                DropShipCustomer = entity.GetValue<string>(DropShipAddress.Fields.DropShipCustomer),
                CustomerShipToAddress = entity.GetValue<string>(DropShipAddress.Fields.CustomerShipToAddress),
                DropShipDescription = entity.GetValue<string>(DropShipAddress.Fields.DropShipDescription),
                DropShipAddress1 = entity.GetValue<string>(DropShipAddress.Fields.DropShipAddress1),
                DropShipAddress2 = entity.GetValue<string>(DropShipAddress.Fields.DropShipAddress2),
                DropShipAddress3 = entity.GetValue<string>(DropShipAddress.Fields.DropShipAddress3),
                DropShipAddress4 = entity.GetValue<string>(DropShipAddress.Fields.DropShipAddress4),
                DropShipCity = entity.GetValue<string>(DropShipAddress.Fields.DropShipCity),
                DropShipStateProvince = entity.GetValue<string>(DropShipAddress.Fields.DropShipStateProvince),
                DropShipZipPostalCode = entity.GetValue<string>(DropShipAddress.Fields.DropShipZipPostalCode),
                DropShipCountry = entity.GetValue<string>(DropShipAddress.Fields.DropShipCountry),
                DropShipPhoneNumber = entity.GetValue<string>(DropShipAddress.Fields.DropShipPhoneNumber),
                DropShipFaxNumber = entity.GetValue<string>(DropShipAddress.Fields.DropShipFaxNumber),
                DropShipContact = entity.GetValue<string>(DropShipAddress.Fields.DropShipContact),
                DropShipEmail = entity.GetValue<string>(DropShipAddress.Fields.DropShipEmail),
                DropShipContactPhone = entity.GetValue<string>(DropShipAddress.Fields.DropShipContactPhone),
                DropShipContactFax = entity.GetValue<string>(DropShipAddress.Fields.DropShipContactFax),
                DropShipContactEmail = entity.GetValue<string>(DropShipAddress.Fields.DropShipContactEmail)
            };

            return model;
        }

        /// <summary>
        /// Map Key
        /// </summary>
        /// <param name="model"></param>
        /// <param name="entity"></param>
        public override void MapKey(T model, Common.Interfaces.Entity.IBusinessEntity entity)
        {

        }
    }
}
