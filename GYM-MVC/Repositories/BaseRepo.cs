using GYM.Domain.Entities;
using GYM_MVC.Core.IRepositories;
using GYM_MVC.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace GYM_MVC.Repositories
{
    public class BaseRepo<T> : IBaseRepo<T> where T : BaseEntity
    {
        protected GYMContext context;
        protected DbSet<T> dbSet;
        public BaseRepo(GYMContext _context)
        {
            context = _context;
            dbSet = context.Set<T>();
        }
        public IQueryable<T> GetAll() =>  dbSet.Where(entity => !entity.IsDeleted);
        public async Task<T> GetById(int id) => await dbSet.SingleOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
        public Task Add(T entity) { throw new Exception(); }
        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

      


    }
}
