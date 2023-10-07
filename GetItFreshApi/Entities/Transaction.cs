using GetItFreshApi.Entities.Enums;

namespace GetItFreshApi.Entities
{
    public class Transaction : BaseClass
    {
        public string MerchantId { get; set; }
        public Merchant Merchant { get; set; }
        public decimal AmountPaid { get; set; }
        public PurchaseStatus PurchaseStatus { get; set; }
        public DateTime DateCompleted { get; set; } 
    }
}
