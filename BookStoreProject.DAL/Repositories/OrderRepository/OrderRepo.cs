using Microsoft.EntityFrameworkCore;
using BookStoreProject.DAL.Data.Models;
using BookStoreProject.DAL.Repositories.OrderRepository;
using BookStoreProject.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.DAL.Repositories.OrderRepository
{
    public class OrderRepo : IOrderRepo
    {
        private readonly BookStoreDbContext _context;

        public OrderRepo(BookStoreDbContext context)
        {
            _context = context;
        }


    
        public IEnumerable<Order> GetAll()
        {
            var AllOrders = _context.Orders.AsSplitQuery()
                .Include(a=>a.DiscountCoupon)
                .Include(a=> a.Details)
                .Include(b=>b.Books);
            return AllOrders;
        }

        public Order GetById(int id)
        {
            var OrderById = GetAll().FirstOrDefault(a=>a.Id == id);
            return OrderById;
        }
        public void Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        //public void Update(Order order)
        //{

        //    _context.SaveChanges();
        //}
        public void Delete(Order order)
        {
            _context.Remove(order);
            _context.SaveChanges();
        }
    }
}
