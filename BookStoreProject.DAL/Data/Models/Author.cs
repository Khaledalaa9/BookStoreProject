using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.DAL.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }

        public ICollection<Book> Books { get; set; }=new HashSet<Book>();
        public ICollection<BookAuthor> BookAuthors { get; set; }=new HashSet<BookAuthor>();
    }
}
