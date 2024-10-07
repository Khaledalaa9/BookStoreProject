using BookStoreProject.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace BookStoreProject.DAL.ViewModels
{
    

    public class PurchaseBookVM
    {
          public Purchase Purchase { get; set; }
       //  public int BookId { get; set; }
        public  IEnumerable<Book> ?Books { get; set; }

       // public int SupplierId { get; set; }
        public  IEnumerable<Supplier> ?Suppliers { get; set; }

    }
}
