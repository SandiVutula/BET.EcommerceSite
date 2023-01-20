using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BET.Data.Model.Dto
{
    public class CartDto
    {
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public Product Product { get; set; }
    }
}
