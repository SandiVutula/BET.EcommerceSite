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
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }


    }
}
