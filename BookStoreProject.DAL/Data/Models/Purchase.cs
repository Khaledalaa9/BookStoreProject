using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BookStoreProject.DAL.Data.Models
{
      public class Purchase
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }

    
        public int SupplerID { get; set; }
        public virtual Supplier ?Suppler { get; set; }

        [NotMapped]
        public int BookId { get; set; }
        public virtual IEnumerable<Book>? Book { get; set; }


        //[NotMapped]
        //public ICollection<Book> Books { get; set; } = new HashSet<Book>();
        //[NotMapped]
        //public ICollection<BookPurchase> BookPurchases { get; set; } = new HashSet<BookPurchase>();


    }
}
