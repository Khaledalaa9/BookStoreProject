using Microsoft.EntityFrameworkCore;
using BookStoreProject.DAL.Data.Models;

namespace BookStoreProject.DAL.Data
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options): base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>().HasKey(e => new {e.BookId ,e.AuthorId});
            modelBuilder.Entity<BookOrder>().HasKey(e => new {e.BookId ,e.OrderId});
            modelBuilder.Entity<BookPurchase>().HasKey(e => new {e.BookId ,e.PurchaseId});

            modelBuilder.Entity<Order>()
                .HasOne(o => o.DiscountCoupon)
                .WithOne(dc => dc.Order)
                .HasForeignKey<DiscountCoupon>(dc => dc.OrderID);

            modelBuilder.Entity<User>().HasData(
         new User
         {
             Id = 1,
             UserName = "superadmin",
             Email = "superadmin@example.com",
             Password = "SuperAdmin123",  // استخدم تقنية تشفير كلمات المرور المناسبة هنا
             Address = "HQ Address",
             ContactNumber = 123456789,
             UserType = UserType.SuperAdmin
         },
         new User
         {
             Id = 2,
             UserName = "adminuser",
             Email = "admin@example.com",
             Password = "AdminUser123",  // استخدم تقنية تشفير كلمات المرور المناسبة هنا
             Address = "Admin Office",
             ContactNumber = 987654321,
             UserType = UserType.Admin
         },
         new User
         {
             Id = 3,
             UserName = "customer1",
             Email = "customer1@example.com",
             Password = "Customer123",  // استخدم تقنية تشفير كلمات المرور المناسبة هنا
             Address = "123 Customer Street",
             ContactNumber = 456789123,
             UserType = UserType.Customer
         }
     );

   
            






            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DiscountCoupon> DiscountCoupons { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<BookOrder> BookOrders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<BookPurchase> BookPurchases { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
