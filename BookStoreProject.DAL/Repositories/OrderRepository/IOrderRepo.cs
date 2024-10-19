using BookStoreProject.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.DAL.Repositories.OrderRepository
{
    public interface IOrderRepo
    {
        IEnumerable<Order> GetAll();
        Order GetById(int id);
        void Add(Order order);
       // void Update(Order order);
        void Delete(Order order);

    }
}
