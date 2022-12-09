using BET.Model.Dto;
using Microsoft.EntityFrameworkCore;

namespace BET.Model.Data
{
    public class EntiyFrameworkDbContext : DbContext 
    {
        public EntiyFrameworkDbContext(DbContextOptions<EntiyFrameworkDbContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
    }
}
