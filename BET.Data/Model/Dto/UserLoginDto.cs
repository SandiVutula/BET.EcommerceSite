using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BET.Data.Model.Dto
{
    public class UserLoginDto
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Your password must atleast be 6 characters long")]
        public string Password { get; set; }
    }
}
