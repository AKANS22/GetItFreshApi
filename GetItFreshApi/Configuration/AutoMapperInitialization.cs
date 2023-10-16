using AutoMapper;
using GetItFreshApi.Entities;
using GetItFreshApi.Models;

namespace GetItFreshApi.Configuration
{
    public class AutoMapperInitialization : Profile
    {
        public AutoMapperInitialization() 
        { 
            CreateMap<Farmer, FarmerDTO>().ReverseMap();
            CreateMap<Merchant, MerchantDTO>().ReverseMap();
            CreateMap<Pricing, PricingDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Transaction, TransactionDTO>().ReverseMap();
        }
    }
}
