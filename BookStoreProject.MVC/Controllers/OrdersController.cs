using BookStoreProject.BLL.Managers.OrderManager;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreProject.MVC.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderManager _orderManager;

        public OrdersController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        //Orders/GetAll
        public IActionResult GetAll()
        {
            var AllOrders=_orderManager.GetAll();
            return View(AllOrders);
        }
        public IActionResult GetById(int id)
        {
            var OrderById = _orderManager.GetById(id);
            if (OrderById == null)
            { 
                return NotFound();
            }

            return View(OrderById);
        }
        public IActionResult Delete(int id)
        {
            var OrderById= _orderManager.GetById(id);
            if (OrderById != null)
            {
                _orderManager.DeleteOrder(id);
                return RedirectToAction("GetAll");
            }
            return RedirectToAction("GetAll");
        }
    }
}
