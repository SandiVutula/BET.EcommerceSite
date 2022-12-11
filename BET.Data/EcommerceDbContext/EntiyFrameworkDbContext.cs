using BET.Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BET.Data.EcommerceDbContext
{
    public class EntiyFrameworkDbContext : IdentityDbContext  
    {
        public EntiyFrameworkDbContext(DbContextOptions<EntiyFrameworkDbContext> options)
           : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }

    }
}
