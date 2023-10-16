using GetItFreshApi.Entities;

namespace GetItFreshApi.Models
{
    public class ProductDTO
    {
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string ProductName { get; set; }
        public string Discription { get; set; }
        public Pricing Price { get; set; }
    }
}
