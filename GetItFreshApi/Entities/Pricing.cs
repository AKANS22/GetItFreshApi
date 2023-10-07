using GetItFreshApi.Entities.Enums;

namespace GetItFreshApi.Entities
{
    public class Pricing : BaseClass
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public PurchaseType PurchaseType { get; set; }
    }
}
