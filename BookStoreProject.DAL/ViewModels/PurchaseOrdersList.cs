using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.DAL.ViewModels
{
    public class PurchaseOrdersList
    {
        public string ?SupplierName { get; set; }
        public string ?BookName { get; set; }

        [DataType(DataType.Date)]
        public DateTime purchaseDate { get; set; }
        public int Q { get; set; }

    }
}
