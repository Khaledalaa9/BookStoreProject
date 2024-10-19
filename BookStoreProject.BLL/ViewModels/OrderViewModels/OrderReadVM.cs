using BookStoreProject.BLL.ViewModels.BookViewModels;
using BookStoreProject.BLL.ViewModels.DiscountCouponViewModels;
using BookStoreProject.BLL.ViewModels.OrderDetailsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.BLL.ViewModels.OrderViewModels
{
    public class OrderReadVM
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShippingAddress { get; set; }
        public int TotalAmount { get; set; }

        

       public DiscountCouponReadVM? DiscountCouponReadVM { get; set; }
       public ICollection<BookReadVM> BookReadVMs { get; set; }
       public ICollection<OrderDetailsReadVM> OrderDetailsReadVMs { get; set; }

    }
}
