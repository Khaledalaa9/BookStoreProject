using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.DAL.Data.Models
{
    public class DiscountCoupon
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        
        public int OrderID { get; set; }
        public Order Order { get; set; }
    }
}
