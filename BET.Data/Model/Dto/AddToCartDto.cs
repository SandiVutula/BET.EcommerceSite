using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BET.Data.Model.Dto
{
    public class AddToCartDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string ProductName{ get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }

    }
}

