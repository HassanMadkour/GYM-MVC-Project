using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GYM.Domain.Entities;

namespace GYM_MVC.Core.IRepositories
{
    public interface IBaseRepo<T> 
    {
        public IQueryable<T> GetAll();
        public Task<T> GetById(int id);
        public Task Add(T entity);
        Task AddRange(IEnumerable<T> model);
        public void Update(T entity);
        public void Delete(int id);
        void DeleteRange(IEnumerable<T> model);
        Task<bool> Contains(T model);
        Task<bool> Contains(Expression<Func<T, bool>> crieteria);
        Task<int> Count();
        Task<int> Count(Expression<Func<T, bool>> crieteria);
        Task<bool> Any();

    }
}
