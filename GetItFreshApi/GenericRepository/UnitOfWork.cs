using GetItFreshApi.DatabaseManagement;
using GetItFreshApi.Entities;
using GetItFreshApi.IRepository;

namespace GetItFreshApi.GenericRepository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;
        private IGenericRepository<Farmer> _Farmers;
        private IGenericRepository<Product> _Products;
        private IGenericRepository<Merchant> _Merchants;
        private IGenericRepository<Pricing> _Pricings;
        private IGenericRepository<Transaction> _Transactions;
        private IGenericRepository<User> _Users;
        public UnitOfWork( AppDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Farmer> Farmer => _Farmers ??= new GenericRepository<Farmer> (_context); 
        public IGenericRepository<Product> Product => _Products ??= new GenericRepository<Product>(_context); 
        
       public IGenericRepository<Merchant> Merchant => _Merchants ??= new GenericRepository<Merchant>(_context); 
        public IGenericRepository<Pricing> Pricing => _Pricings ??= new GenericRepository<Pricing>(_context);
        public IGenericRepository<Transaction> Transaction => _Transactions ??= new GenericRepository<Transaction>(_context);
        public IGenericRepository<User> User => _Users ??= new GenericRepository<User>(_context);


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async  Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
