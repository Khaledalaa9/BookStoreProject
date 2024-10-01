using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.DAL.Data.Models
{
    public class Supplier
    {
        public int id {  get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int TelephoneNumber { get; set; }

        public ICollection<Purchase> Purchases { get; set; }=new HashSet<Purchase>();
    }
}
