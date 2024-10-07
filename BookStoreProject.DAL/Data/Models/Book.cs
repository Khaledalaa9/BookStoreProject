using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.DAL.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public string ImgUrl { get; set; }
        public int StockQuantity { get; set; }
        public bool IsDeleted { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public int PublisherID { get; set; }
        public Publisher Publisher { get; set; }

        
        public int? CartID { get; set; }
        public Cart Cart { get; set; }



        public ICollection<Purchase> Purchases { get; set; } = new HashSet<Purchase>();
        public ICollection<Author> Author { get; set; }=new HashSet<Author>();
        public ICollection<Order> Orders { get; set; }=new HashSet<Order>();
        public ICollection<BookAuthor> BookAuthors { get; set; }=new HashSet<BookAuthor>();
        public ICollection<BookOrder> BookOrders { get; set; }=new HashSet<BookOrder>();
        public ICollection<BookPurchase> BookPurchases { get; set; }=new HashSet<BookPurchase>();
    }
}
