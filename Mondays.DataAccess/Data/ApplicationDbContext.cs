using System;
using System.Collections.Generic;
using System.Text;
using Mondays.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mondays.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CoverType> CoverTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Sweetness> Sweetness { get; set; } 
        public DbSet<CustomerPreferences> CustomerPreferences { get; set; }
        public DbSet<Sweeteners> Sweeteners { get; set; }
        public DbSet<MilkType> MilkTypes { get; set; } 
        public DbSet<Topping> Toppings { get; set; }  
        public DbSet<IceCube> IceCubes { get; set; } 
        public DbSet<Origin> Origins { get; set; }  
    }
}


