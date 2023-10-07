using GetItFreshApi.DatabaseManagement;
using GetItFreshApi.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GetItFreshApi.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly AppDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext dbContext, DbSet<T> dbSet)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public async Task Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities)
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            var GetCheck = await _dbSet.FindAsync(expression);
            if (GetCheck != null)
            {
                IQueryable<T> query = _dbSet;
                if(includes != null)
                {
                    foreach (var includeProperty in includes)
                    {
                        query = query.Include(includeProperty);
                    }
                }
            }
            
        }

        public Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(T entity)
        {
            await _dbSet.AddAsync(entity);

        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
           _dbSet.Attach(entity);
           _dbContext.Entry(entity).State = EntityState.Modified;
    
        }
    }
}
