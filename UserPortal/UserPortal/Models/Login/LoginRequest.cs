namespace UserPortal.Models.Login
{
    public class LoginRequest
    {
        public string username { get; set; }
        public string password { get; set; }

        public string verificationCode { get; set; }
    }
}
