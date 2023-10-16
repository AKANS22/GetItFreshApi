namespace GetItFreshApi.Models
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
        public string RefreshTokenKey { get; set; }
        public DateTime RefreshTokenExpirationTime { get; set; }
        public DateTime LastLogin { get; }
    }
}
