using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.DAL.Data.Models
{
    public enum UserType
    {
        SuperAdmin,Admin,Customer
    }
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public int ContactNumber { get; set; }
        public UserType UserType { get; set; }

        public ICollection<Order> Orders { get; set; }= new HashSet<Order>();
        public ICollection<Cart> Carts { get; set; } = new HashSet<Cart>();

    }
}
