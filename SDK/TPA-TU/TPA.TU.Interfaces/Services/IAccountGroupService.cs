using TPA.TU.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;

namespace TPA.TU.Interfaces.Services
{
     /// <summary>
    /// Interface IAccountGroupService
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAccountGroupService<T> : IEntityService<T>, ISecurityService where T : AccountGroup, new()
    {
        /// <summary>
        /// update account set status
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        T UpdateStatus(T model);

      
    }
}
