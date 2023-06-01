namespace BankAuthenticationService.Model
{
    public class User
    {
        public string UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        [System.Text.Json.Serialization.JsonIgnore]
        public UserRole UserRole { get; set; } = UserRole.Customer;
        public long AccountNumber { get; set; }
        public string MobileNumber { get; set; } = string.Empty;

        [System.Text.Json.Serialization.JsonIgnore]
        public bool IsActive { get; set; } = false;
    }

    public enum UserRole
    {
        Admin = 0,
        Customer = 1,
    }
}
