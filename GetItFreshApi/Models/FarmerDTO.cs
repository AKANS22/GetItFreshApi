using GetItFreshApi.Entities;

namespace GetItFreshApi.Models
{
    public class FarmerDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public string ProfilePicture { get; set; }
        public string VideoUrl { get; set; }

        public bool IsApproved { get; set; }
        public DateTime DateApproved { get; set; }
        public DateTime DateRejected { get; set; }

    }
}
