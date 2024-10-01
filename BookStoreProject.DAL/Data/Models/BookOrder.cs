using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.DAL.Data.Models
{
    public class BookOrder
    {
      
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }


    }
}
