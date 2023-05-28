using Microsoft.EntityFrameworkCore;
using TelegramBot_BuyYourStyle.models;

namespace TelegramBot_BuyYourStyle.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Item> Items => Set<Item>();
   //     public ApplicationContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
            _ = optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlite($"Data Source={path}{Path.DirectorySeparatorChar}BuyYourStyle.db");
        }
    }
}