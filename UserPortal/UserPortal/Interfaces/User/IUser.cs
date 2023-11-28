using UserPortal.Models.Generic;

namespace UserPortal.Interfaces.User
{
    public interface IUser
    {
        public Task<GenericResponseModel> GetUser();
        public Task<GenericResponseModel> GetUserList();
    }
}
