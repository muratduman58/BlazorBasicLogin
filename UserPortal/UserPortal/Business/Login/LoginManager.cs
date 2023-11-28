using UserPortal.Interfaces.Api;
using UserPortal.Interfaces.Cache;
using UserPortal.Interfaces.Login;
using UserPortal.Models.Generic;
using UserPortal.Models.Login;
using UserPortal.Models.User;

namespace UserPortal.Business.Login
{
    public class LoginManager : ILogin
    {

        private readonly IApiManager _api;
        private readonly ICache _cache;

        public LoginManager(IApiManager api, ICache cache)
        {
            _api = api;
            _cache = cache;
        }
        public async Task<GenericResponseModel> UserLogin(string username, string password, string verificationCode)
        {
            GenericResponseModel res;
            try
            {
                LoginRequest lgnReq = new LoginRequest();
                lgnReq.username = username;
                lgnReq.password = password;
                lgnReq.verificationCode = verificationCode;
                res = await _api.Login(lgnReq);
                if (res.isOk)
                {
                    res.isOk = true;
                    _cache.SetValue(username, username, DateTime.Now.AddMinutes(10));
                    var usr = await _api.GetUserMobile();
                    if (usr != null && usr.isOk)
                    {
                        UserResponseModel.User user = (UserResponseModel.User)usr.Model;
                        await _cache.SetBrowserSesionCache("LoggedInUser", user.data);
                    }


                }
                else
                {
                    res.isOk = false;
                    res.Message = "Kullanıcı Adı veya Şifre yanlış.";
                }


            }
            catch (Exception ex)
            {

                throw;
            }
            return res;
        }
    }
}
