namespace BankAuthenticationService.Model
{
    public class AuthResult
    {
        public string auth_token { get; set; }
        public bool IsActive { get; set; }
    }
}
