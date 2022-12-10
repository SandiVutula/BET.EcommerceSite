using BET.Data.Model.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BET.Data.EcommerceDbContext
{
    public class EntiyFrameworkDbContext : DbContext 
    {
        public EntiyFrameworkDbContext(DbContextOptions<EntiyFrameworkDbContext> options)
           : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
    }
}
