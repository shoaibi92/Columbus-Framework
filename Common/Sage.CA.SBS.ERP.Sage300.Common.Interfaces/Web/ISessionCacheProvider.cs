
namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Web
{
    /// <summary>
    /// Interface for Session Provider
    /// </summary>
    public interface ISessionCacheProvider
    {
        /// <summary>
        /// Sets data
        /// </summary>
        /// <typeparam name="T">Base type</typeparam>
        /// <param name="key">Key</param>
        /// <param name="data">Data</param>
        void Set<T>(string key, T data);

        /// <summary>
        /// Gets data based on key
        /// </summary>
        /// <typeparam name="T">Base type</typeparam>
        /// <param name="key">Key</param>
        /// <returns></returns>
        T Get<T>(string key);

        /// <summary>
        /// Removes based on key
        /// </summary>
        /// <param name="key">Key</param>
        void Remove(string key);

        /// <summary>
        /// Removes based on key
        /// </summary>
        /// <param name="keyValueToMatch">Key</param>
        void RemoveAllByMatchingKey(string keyValueToMatch);
    }
}
