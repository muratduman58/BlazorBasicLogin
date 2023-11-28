using UserPortal.Models.Generic;
using UserPortal.Models.Login;

namespace UserPortal.Interfaces.Api
{
    public interface IApiManager
    {
        public Task<GenericResponseModel> Login(LoginRequest LoginReq);

        public Task<GenericResponseModel> GetUserMobile(); 
        public Task<GenericResponseModel> GetListMobile();


    }
}