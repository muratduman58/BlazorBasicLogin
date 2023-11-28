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


        public CacheManager(IMemoryCache memoryCache, ILocalStorageService local, ISessionStorageService sesion)
        {
            _memoryCache = memoryCache;
            _sesion = sesion;
            _local = local;
        }

        public async Task<string> GetBrowserLocalCache(string key)
        {
            try
            {
                var data = await _local.GetItemAsync<string>(key);
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<string> GetBrowserSesionCache(string key)
        {
            try
            {
                var data = await _sesion.GetItemAsync<string>(key);
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

        public async Task SetBrowserLocalCache(string key, string value)
        {
            try
            {
                await _local.SetItemAsync<string>(key, value);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task SetBrowserSesionCache(string key, string value)
        {
            try
            {
                await _sesion.SetItemAsync<string>(key, value);
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
