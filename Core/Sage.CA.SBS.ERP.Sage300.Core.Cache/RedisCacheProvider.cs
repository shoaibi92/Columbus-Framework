using System;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Caching;
using StackExchange.Redis;
using P = Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;

namespace Sage.CA.SBS.ERP.Sage300.Core.Cache
{
    /// <summary>
    /// Redis Cache Provider
    /// </summary>
    internal sealed class RedisCacheProvider : ICacheProvider, IDisposable
    {

        /// <summary>
        /// The _connection multiplexer
        /// </summary>
        private ConnectionMultiplexer _connectionMultiplexer;

        /// <summary>
        /// The _disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="RedisCacheProvider"/> class.
        /// </summary>
        public RedisCacheProvider()
        {
            var connectionString = string.Format("{0},ssl={1},password={2}", ConfigurationHelper.RedisHost,
                ConfigurationHelper.RedisIsSecured, ConfigurationHelper.RedisAccountKey);

            // Get & initalizae the Redis Connection String.
            _connectionMultiplexer = ConnectionMultiplexer.Connect(connectionString);
        }

        /// <summary>
        /// Sets the specified key and data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="data">The data.</param>
        public void Set<T>(string key, T data)
        {
            var retryStrategy = new P.Incremental(5, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2));
            P.RetryPolicy retryPolicy = new P.RetryPolicy<P.StorageTransientErrorDetectionStrategy>(retryStrategy);
            retryPolicy.ExecuteAction(() =>
            {
                var database = _connectionMultiplexer.GetDatabase();
                database.StringSet(key, JsonSerializer.Serialize(data), ConfigurationHelper.SessionPoolTimeOut);
            });
            
        }

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            T cachedData = default(T);
            var retryStrategy = new P.Incremental(5, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2));
            P.RetryPolicy retryPolicy = new P.RetryPolicy<P.StorageTransientErrorDetectionStrategy>(retryStrategy);
            retryPolicy.ExecuteAction(() =>
            {
                var database = _connectionMultiplexer.GetDatabase();
                var data = database.StringGet(key);
                if (data.HasValue)
                {
                    cachedData = (JsonSerializer.Deserialize<T>(database.StringGet(key)));
                }
            });

            return cachedData;
        }

        /// <summary>
        /// Removes cached data based on key.
        /// </summary>
        /// <param name="key">Key</param>
        public void Remove(string key)
        {
            var retryStrategy = new P.Incremental(5, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2));
            P.RetryPolicy retryPolicy = new P.RetryPolicy<P.StorageTransientErrorDetectionStrategy>(retryStrategy);
            retryPolicy.ExecuteAction(() =>
            {
                var database = _connectionMultiplexer.GetDatabase();
                database.KeyDelete(key);
            });
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Setting dispose
        /// </summary>
        /// <param name="disposing">Disposing value</param>
        private void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                if (_connectionMultiplexer != null)
                {
                    _connectionMultiplexer.Dispose();
                    _connectionMultiplexer = null;
                    _disposed = true;
                }
            }
        }

        /// <summary>
        /// We want the RedisCacheProvider object to be disposed only once the static object instance loses scope.
        /// </summary>
        ~RedisCacheProvider()
        {
            Dispose(true);
        }
    }
}
