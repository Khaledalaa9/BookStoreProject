using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.BLL.ViewModels.OrderDetailsViewModels
{
    public class OrderDetailsReadVM
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

    }
}
