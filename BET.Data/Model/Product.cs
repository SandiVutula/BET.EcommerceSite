using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BET.Data.Model
{
    public class Product
    {
        public int Id { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Product()
        {
            Photos = new Collection<Photo>();
        }
    }
}
