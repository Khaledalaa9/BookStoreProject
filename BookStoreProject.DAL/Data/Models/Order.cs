using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.DAL.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShippingAddress { get; set; }
        public int TotalAmount { get; set; }


        //public int? DiscountCouponID { get; set; }
        public DiscountCoupon DiscountCoupon { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }

        public ICollection<OrderDetails> Details { get; set; } = new HashSet<OrderDetails>();
        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
        public ICollection<BookOrder> BookOrders { get; set; } = new HashSet<BookOrder>();
    }
}
