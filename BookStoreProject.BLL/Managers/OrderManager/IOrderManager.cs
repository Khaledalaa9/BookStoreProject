using BookStoreProject.BLL.ViewModels.OrderViewModels;
using BookStoreProject.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.BLL.Managers.OrderManager
{
    public interface IOrderManager
    {
        IEnumerable<OrderReadVM> GetAll();
        OrderReadVM GetById(int id);
        void AddOrder(OrderAddVM orderAddVM);
       // void UpdateOrder(OrderUpdateVM orderUpdateVM);
        void DeleteOrder(int id);
    }
}
