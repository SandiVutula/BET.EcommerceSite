namespace BET.Model.Dto
{
    public class User
    {
        public int UserId { get; set; }
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set;}
        public bool IsActive { get; set;} 
    }
}