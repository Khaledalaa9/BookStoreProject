using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.DAL.Data.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int Quantity { get; set; }


        public int UserID { get; set; }
        public User User { get; set; }

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();


    }
}
