using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

 namespace BookStoreProject.BLL.Managers
{
    public interface IBaseRepository<T> where T : class
    {
        T GetByID(int id);
        Task<T> GetByIDAsync(int id);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T Find(Expression<Func<T, bool>> match);
        Task<T> Add(T entity);
        T Update(T entity);
        public IQueryable Update(Expression<Func<T, bool>> match);
        void Delete(T entity);

        public IQueryable<T> GetAllQ();

    }
}
