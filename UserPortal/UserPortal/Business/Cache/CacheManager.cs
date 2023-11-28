using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.Extensions.Caching.Memory;
using UserPortal.Interfaces.Cache;

namespace UserPortal.Business.Cache
{
    public class CacheManager : ICache
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILocalStorageService _local;
        private readonly ISessionStorageService _sesion;


        public CacheManager(IMemoryCache memoryCache, ILocalStorageService local)
        {
            _memoryCache = memoryCache;
            _local = local;
        }

        public async Task<object> GetBrowserLocalCache(string key)
        {
            try
            {
                var data = await _local.GetItemAsync<object>(key);
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }

        public async Task<object> GetBrowserSesionCache(string key)
        {
            try
            {
                var data = await _sesion.GetItemAsync<object>(key);
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<object> GetValue(string key)
        {
            try
            {
                var aa = _memoryCache.TryGetValue(key, out object value);
                return value;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task SetBrowserLocalCache(string key, object value)
        {
            try
            {
                await _local.SetItemAsync<object>(key, value);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task SetBrowserSesionCache(string key, object value)
        {
            try
            {
                await _sesion.SetItemAsync<object>(key, value);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task SetValue(string key, object value, DateTime expireTime)
        {
            try
            {
                _memoryCache.Set<object>(key, value, expireTime);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
