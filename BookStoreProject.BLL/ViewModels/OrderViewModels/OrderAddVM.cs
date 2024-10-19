using BookStoreProject.BLL.ViewModels.BookViewModels;
using BookStoreProject.BLL.ViewModels.DiscountCouponViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.BLL.ViewModels.OrderViewModels
{
    public class OrderAddVM
    {
        public string ShippingAddress { get; set; }

        public DiscountCouponAddVM? DiscountCouponAddVM { get; set; }
        public ICollection<BookAddVM> BookAddVM { get; set; }
    }
}
