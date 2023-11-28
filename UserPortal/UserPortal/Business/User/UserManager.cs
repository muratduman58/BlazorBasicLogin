using UserPortal.Interfaces.User;
using UserPortal.Models.Generic;

namespace UserPortal.Business.User
{
    public class UserManager : IUser
    {
        public async Task<GenericResponseModel> GetUser()
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponseModel> GetUserList()
        {
            throw new NotImplementedException();
        }
    }
}
