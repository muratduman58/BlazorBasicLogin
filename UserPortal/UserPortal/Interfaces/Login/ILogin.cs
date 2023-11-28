using UserPortal.Models.Generic;

namespace UserPortal.Interfaces.Login
{
    public interface ILogin
    {
        public Task<GenericResponseModel> UserLogin(string username, string password, string verificationCode);
    }
}
