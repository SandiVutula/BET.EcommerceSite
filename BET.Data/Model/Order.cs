using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace BET.Data.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string Items { get; set; }
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
