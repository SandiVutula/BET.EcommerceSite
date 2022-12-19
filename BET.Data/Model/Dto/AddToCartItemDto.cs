using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BET.Data.Model.Dto
{
    public class AddToCartItemDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        [Required()]
        public string ProductName{ get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Maximum allowed Quantity 5")]
        public int Quantity { get; set; } 
    }
}

