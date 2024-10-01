using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.DAL.Data.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public int OrderID { get; set; }
        public Order Order { get; set; }

    }
}
