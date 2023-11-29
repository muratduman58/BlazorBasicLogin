using UserPortal.Models.Generic;

namespace UserPortal.Interfaces.User
{
    public interface IUser
    {
    
        public Task<GenericResponseModel> GetUserList();
    }
}
