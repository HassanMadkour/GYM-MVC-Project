using System;
using System.Collections.Generic;
using System.Linq;
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
        public Task Update(T entity);
        public Task Delete(int id);
    }
}
