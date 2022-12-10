namespace BET.Data.Model.Dto
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Photo { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;    
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
