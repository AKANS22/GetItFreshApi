using GetItFreshApi.Entities.Enums;

namespace GetItFreshApi.Models
{
    public class PricingDTO
    {
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PurchaseType { get; set; }
    }
}
