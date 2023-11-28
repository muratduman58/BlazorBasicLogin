using UserPortal.Interfaces.Api;
using UserPortal.Models.Generic;
using UserPortal.Models.Login;
using UserPortal.Models.User;
using RestSharp;

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

                var res = await client.GetAsync<UserListResponseModel>(req);

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

        public async Task<GenericResponseModel> GetUserMobile()
        {
            GenericResponseModel resModel = new GenericResponseModel();
            try
            {
                RestClient client = new RestClient(ApiUrl);

                RestRequest req = new RestRequest("/Account/GetUserMobile", Method.Get);

                var res = await client.GetAsync<UserResponseModel>(req);

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
