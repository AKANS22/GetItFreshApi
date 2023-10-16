using GetItFreshApi.Entities;

namespace GetItFreshApi.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Farmer> Farmer { get; }
        IGenericRepository<Product> Product { get;  }
        IGenericRepository<Merchant> Merchant { get; } 
        IGenericRepository<Pricing> Pricing { get;}
        IGenericRepository<Transaction> Transaction { get; }
        IGenericRepository<User> User { get; }

        Task Save();
    }
}
