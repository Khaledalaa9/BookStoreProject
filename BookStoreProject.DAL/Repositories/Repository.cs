using BookStoreProject.BLL.Managers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using BookStoreProject.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.DAL.Repositories
{
    public class Repository<T> : IBaseRepository<T> where T : class
    {
        protected BookStoreDbContext _context;

        public Repository(BookStoreDbContext context)
        {
            _context = context;
        }
        //------------------------------------ Add--------------------------
        public async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            _context.SaveChanges();
            return entity;
        }

        //------------------------------------ Delete--------------------------
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();

        }
        //------------------------------------ Search--------------------------
        public T Find(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().SingleOrDefault(match);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        //------------------------------------ GetList--------------------------
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        //------------------------------------ Search By ID--------------------------
        public T GetByID(int id)
        {
            return _context.Set<T>().Find(id);
        }
        //------------------------------------ Search By ID ASync--------------------------
        public async Task<T> GetByIDAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        //------------------------------------ Update--------------------------
        public T Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}
