using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BET.Data.Model
{
    public class Cart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Total { get; set; }
    }
}
