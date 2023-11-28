namespace UserPortal.Interfaces.Cache
{
    public interface ICache
    {
        public Task SetValue(string key, object value,DateTime expireTime);

        public Task<object> GetValue(string key);
        public Task SetBrowserSesionCache(string key,object value);
        public Task SetBrowserLocalCache(string key,object value);
        public Task<object> GetBrowserLocalCache(string key);
        public Task<object> GetBrowserSesionCache(string key);
    }
}
