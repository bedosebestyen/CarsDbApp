using DYRQO6_HFT_2022231.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYRQO6_HFT_2022231.Repository
{
    public class CarsDbContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CarShop> Carshop { get; set; }
        public DbSet<Cars> Cars { get; set; }
        public CarsDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn =
                        @"";
                builder
                   .UseInMemoryDatabase("cars")
                   .UseLazyLoadingProxies();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cars>()
                .HasOne(c => c.Customer)
                .WithMany(c => c.Cars)
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cars>()
                .HasOne(r => r.Shop)
                .WithMany(r => r.Cars)
                .HasForeignKey(c => c.ShopId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CarShop>()
                .HasMany(r => r.Customers)
                .WithMany(c => c.Shop);

            modelBuilder.Entity<Cars>().HasData(new Cars[]
            {
                new Cars("1#Audi#white#1#1#2019*04*15"),
                new Cars("2#Skoda#king blue#2#2#2009*04*15"),
                new Cars("3#Volkswagen#black#3#3#2022*01*30"),
                new Cars("4#Fiat#red#4#3#2000*09*19"),
                new Cars("5#BMW#black#4#1#2020*02*22"),
                new Cars("6#Peugeot#white#1#1#2014*06*08")
            });
            modelBuilder.Entity<Customer>().HasData(new Customer[]
            {
                new Customer("1#20#Winton Dickinson#695 Willison Street"),
                new Customer("2#40#Osmond Chambers#2111 Sand Fork Road"),
                new Customer("3#31#Talia Cooke#2390 Carriage Court"),
                new Customer("4#50#Isaiah Motley#217 Emeral Dreams Drive")
            });
            modelBuilder.Entity<CarShop>().HasData(new CarShop[]
            {
                new CarShop("1#Best cars#5#3300 Fittro Street"),
                new CarShop("2#Awesome machines#4#1714 Mulberry Lane"),
                new CarShop("3#Carscarscars#10#3799 Marie Street")
            });
        }
    }
   
}
