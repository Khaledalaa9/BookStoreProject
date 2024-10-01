using BookStoreProject.BLL;
using BookStoreProject.BLL.Managers;
using BookStoreProject.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using BookStoreProject.DAL.Data;

namespace BookStoreProject.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<BookStoreDbContext>(options => options.UseSqlServer(
                  builder.Configuration.GetConnectionString("DefaultConnection"),
                  b => b.MigrationsAssembly(typeof(BookStoreDbContext).Assembly.FullName)));

            builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(Repository<>));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
