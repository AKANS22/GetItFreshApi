namespace GetItFreshApi.Entities
{
    public class Farmer : BaseType
    {
        public User User { get; set; }
        public string ProfilePicture { get; set; }
        public string VideoUrl { get; set; }

        public bool IsApproved { get; set; }
        public DateTime DateApproved { get; set; }
        public DateTime DateRejected { get; set; }
        public IList<Product> Products { get; set; }
        public IList<Transaction> Transactions { get; set; }
        public IList <Pricing> Pricing { get; set; }

    }
}
