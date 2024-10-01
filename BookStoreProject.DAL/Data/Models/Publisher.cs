using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.DAL.Data.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int TelephoneNumber { get; set; }


        public ICollection<Book> Books { get; set; }=new HashSet<Book>();
    }
}
