using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.BLL.ViewModels.BookViewModels
{
    public class BookReadVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }

        public int CategoryID { get; set; }


    }
}
