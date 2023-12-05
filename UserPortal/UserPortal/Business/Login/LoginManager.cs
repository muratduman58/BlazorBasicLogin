using System.ComponentModel.Design;
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
                    await _cache.SetBrowserSesionCache("LoggedInUser", username);
                    var usr = await _api.GetUserMobile();
                    UserResponseModel.User user = (UserResponseModel.User)usr.Model;
                  

                    if (usr != null && usr.isOk)
                    {

                        await _cache.SetValue(username, user.data, DateTime.Now.AddDays(5));
                    }
                    else
                    {
                        res.isOk = false;
                        res.Model = (LoginResponse)res.Model;
                    }


                }
                else
                {
                    res.isOk = false;
                    res.Model = (LoginResponse)res.Model;
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
