using UserPortal.Interfaces.Api;
using UserPortal.Interfaces.User;
using UserPortal.Models.Generic;
using UserPortal.Models.User;

namespace UserPortal.Business.User
{
    public class UserManager : IUser
    {
        private readonly IApiManager _api;
        public UserManager(IApiManager api) 
        { 
            _api = api;
        }
       
        public async Task<GenericResponseModel> GetUserList()
        {
            GenericResponseModel responseModel;
            try
            {
             responseModel = await _api.GetListMobile();
            }
            catch (Exception ex)
            {

                throw;
            }
            return responseModel;
        }
    }
}
