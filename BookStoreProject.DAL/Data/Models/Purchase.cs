using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.DAL.Data.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }

        public int SupplerID { get; set; }
        public Supplier Suppler { get; set; }

      
        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
        public ICollection<BookPurchase> BookPurchases { get; set; } = new HashSet<BookPurchase>();


    }
}
