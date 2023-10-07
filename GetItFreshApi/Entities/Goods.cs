namespace GetItFreshApi.Entities
{
    public class Product:BaseClass
    {
        public string ProductName { get; set; }
        public string Discription { get; set; }
        public Pricing Price { get; set; }

    }
}
