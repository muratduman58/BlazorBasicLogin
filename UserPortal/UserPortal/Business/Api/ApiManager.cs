using UserPortal.Interfaces.Api;
using UserPortal.Models.Generic;
using UserPortal.Models.Login;
using UserPortal.Models.User;
using RestSharp;
using System.Security.Principal;
using static UserPortal.Models.User.UserResponseModel;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Runtime.ConstrainedExecution;
using UserPortal.Interfaces.Cache;
using System.Net;

namespace UserPortal.Business.Api
{
    public class ApiManager : IApiManager
    {
        private readonly IConfiguration _config;
        private readonly ICache _cache;
        public string ApiUrl;
        public string ServiceLevel;

        public ApiManager(IConfiguration configuration, ICache cache)
        {
            _cache = cache;
            _config = configuration;
            ServiceLevel = _config["ServiceLevel"].ToString();
            ApiUrl = _config["ApiUrls:" + ServiceLevel + ":ApiUrl"].ToString();
        }

        public async Task<string> GetCookie()
        {
            var lgnusr = await _cache.GetBrowserSesionCache("LoggedInUser");
            CookieCollection cke = (CookieCollection)await _cache.GetValue(lgnusr + "Cookie");
            var cookieList = new List<string>();

            foreach (Cookie cookie in cke)
            {
                cookieList.Add($"{cookie.Name}={cookie.Value}");
            }

            return string.Join("; ", cookieList);
        }
        public async Task<GenericResponseModel> GetListMobile()
        {
            GenericResponseModel resModel = new GenericResponseModel();
            try
            {
                RestClient client = new RestClient(ApiUrl);

                RestRequest req = new RestRequest("/Card/GetListMobile", Method.Get);

               
                req.AddHeader("Cookie", await GetCookie());
                var res = await client.ExecuteAsync(req);
                var usrlst = JsonConvert.DeserializeObject<UserListResponseModel>(res.Content);
                if (res != null)
                {
                    resModel.isOk = true;
                    resModel.Model = usrlst.data;
                }
                else
                {
                    resModel.isOk = false;
                    resModel.Model = res;
                }
                return resModel;
            }
            catch (Exception ex)
            {

                resModel.isOk = false;
                resModel.Message = ex.Message;
                return resModel;
            }
        }

        public async Task<GenericResponseModel> GetUserMobile()
        {
            GenericResponseModel resModel = new GenericResponseModel();
            try
            {

            
                RestClient client = new RestClient(ApiUrl);

                RestRequest req = new RestRequest("/Account/GetUserMobile", Method.Get);
                req.AddHeader("Content-Type", "application/json");
                req.AddHeader("Cookie", await GetCookie());
                var res = await client.ExecuteAsync(req);
                var usr = JsonConvert.DeserializeObject<UserResponseModel.User>(res.Content);

                if (res != null && usr.success)
                {
                    resModel.isOk = true;
                    resModel.Model = usr;
                }
                else
                {
                    resModel.isOk = false;
                    resModel.Model = res;
                }
                return resModel;
            }
            catch (Exception ex)
            {

                resModel.isOk = false;
                resModel.Message = ex.Message;
                return resModel;
            }

        }

        public async Task<GenericResponseModel> Login(LoginRequest LoginReq)
        {
            GenericResponseModel resModel = new GenericResponseModel();
            try
            {


                RestClient client = new RestClient(ApiUrl);

                RestRequest req = new RestRequest("/Account/Login", Method.Post);
                req.AddJsonBody(LoginReq);


                var res = await client.ExecuteAsync(req);


                if (res != null && res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var cookie = res.Cookies;
                    await _cache.SetValue(LoginReq.username + "Cookie", cookie, DateTime.Now.AddDays(5));
                    LoginResponse resmdl = JsonConvert.DeserializeObject<LoginResponse>(res.Content);
                    resModel.isOk = true;
                    resModel.Model = resmdl;
                }
                else
                {
                    resModel.isOk = false;
                    resModel.Model = res;
                }
                return resModel;
            }
            catch (Exception ex)
            {
                resModel.isOk = false;
                resModel.Message = ex.Message;
                return resModel;

            }

        }
    }
}
