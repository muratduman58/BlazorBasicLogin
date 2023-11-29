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

namespace UserPortal.Business.Api
{
    public class ApiManager : IApiManager
    {
        private readonly IConfiguration _config;
        public string ApiUrl;
        public string ServiceLevel;

        public ApiManager(IConfiguration configuration)
        {
            _config = configuration;
            ServiceLevel = _config["ServiceLevel"].ToString();
            ApiUrl = _config["ApiUrls:" + ServiceLevel + ":ApiUrl"].ToString();
        }

        public async Task<GenericResponseModel> GetListMobile()
        {
            GenericResponseModel resModel = new GenericResponseModel();
            try
            {
                RestClient client = new RestClient(ApiUrl);

                RestRequest req = new RestRequest("/Card/GetListMobile", Method.Get);

                req.AddHeader("Cookie", ".AspNet.ApplicationCookie=oLqMRPjVK8gNIuv0t-BRzD91Gj7VkYX_T86I9jX7I76NFNi0BAGejgGmgUlW-pocQfgmHw-FPWgkWNK7hvUwDp_-3Zt1i221kaxIEmM6UDLodHj6R6Qdwc0Wtiy3ZXkc5dZpxD3KdtD2tCSkUQnVCVQtU7Nmn83U9xMUkXkJVQ_jS9OLMUGnneVCJ0ZqBU_CeBgv7AIaTPaygUCCkIG7CbdVzIzO0IiSH6vlWaFU-zIjQCjQCqusON86EYQMyiScPvCy4uJr2NgtJiyD2c-eP0NO59k4jpLg9xvy9FOJTPdzDxdB; ASP.NET_SessionId=d2j2omtakr2di0azrbghag0e; language=tr-TR");
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
                req.AddHeader("Cookie", ".AspNet.ApplicationCookie=oLqMRPjVK8gNIuv0t-BRzD91Gj7VkYX_T86I9jX7I76NFNi0BAGejgGmgUlW-pocQfgmHw-FPWgkWNK7hvUwDp_-3Zt1i221kaxIEmM6UDLodHj6R6Qdwc0Wtiy3ZXkc5dZpxD3KdtD2tCSkUQnVCVQtU7Nmn83U9xMUkXkJVQ_jS9OLMUGnneVCJ0ZqBU_CeBgv7AIaTPaygUCCkIG7CbdVzIzO0IiSH6vlWaFU-zIjQCjQCqusON86EYQMyiScPvCy4uJr2NgtJiyD2c-eP0NO59k4jpLg9xvy9FOJTPdzDxdB; ASP.NET_SessionId=d2j2omtakr2di0azrbghag0e; language=tr-TR");
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

                var res = await client.PostAsync<LoginResponse>(req);
                if (res != null && res.success == true)
                {
                    resModel.isOk = true;
                    resModel.Model = res;
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
