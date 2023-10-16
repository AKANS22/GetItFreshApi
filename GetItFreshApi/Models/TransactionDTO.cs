using GetItFreshApi.Entities.Enums;
using GetItFreshApi.Entities;

namespace GetItFreshApi.Models
{
    public class TransactionDTO
    {
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string MerchantId { get; set; }
        public Merchant Merchant { get; set; }
        public decimal AmountPaid { get; set; }
        public PurchaseStatus PurchaseStatus { get; set; }
        public DateTime DateCompleted { get; set; }
    }
}
