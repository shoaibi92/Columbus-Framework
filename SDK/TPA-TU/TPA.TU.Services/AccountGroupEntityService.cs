using System;
using TPA.TU.Interfaces.BusinessRepository;
using TPA.TU.Interfaces.Services;
using TPA.TU.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Services.Base;

namespace TPA.TU.Services
{
    /// <summary>
    /// Class AccountGroupEntityService.
    /// </summary>
    /// <typeparam name="T">PaymentCodes</typeparam>
    public class AccountGroupEntityService<T> : FlatService<T, IAccountGroupEntity<T>>, IAccountGroupService<T> where T : AccountGroup, new()
    {

        /// <summary>
        /// To set Request Context
        /// </summary>
        /// <param name="context">Request Context</param>    
        public AccountGroupEntityService(Context context)
            : base(context)
        {

        }


        /// <summary>
        /// Update the account set status
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual T UpdateStatus(T model)
        {
            using (var repository = Resolve<IAccountGroupEntity<T>>())
            {
                return repository.UpdateStatus(model);
            }
        }
    }
}
