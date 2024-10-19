using BookStoreProject.BLL.ViewModels.BookViewModels;
using BookStoreProject.BLL.ViewModels.DiscountCouponViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.BLL.ViewModels.OrderViewModels
{
    public class OrderUpdateVM
    {
        public int Id { get; set; }
        public string ShippingAddress { get; set; }

        public DiscountCouponUpdateVM? DiscountCouponUpdateVM { get; set; }
        public ICollection<BookUpdateVM> BookUpdateVM { get; set; }
    }
}
