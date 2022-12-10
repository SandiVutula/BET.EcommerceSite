namespace BET.Data.Model.Dto
{
    public class CartItem
    {
        public CartItem()
        {
            Product = new Product();
        }
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
        public int Total { get; set; }
        public virtual Product Product { get; set; }
    }
}
