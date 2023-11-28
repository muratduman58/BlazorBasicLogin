namespace UserPortal.Interfaces.Cache
{
    public interface ICache
    {
        public Task SetValue(string key, object value,DateTime expireTime);

        public Task<object> GetValue(string key);
        public Task SetBrowserSesionCache(string key,string value);
        public Task SetBrowserLocalCache(string key,string value);
        public Task<string> GetBrowserLocalCache(string key);
        public Task<string> GetBrowserSesionCache(string key);
    }
}
