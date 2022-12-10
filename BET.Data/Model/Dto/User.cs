using System.ComponentModel.DataAnnotations;

namespace BET.Data.Model.Dto
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        public bool IsActive { get; set; }
    }
}