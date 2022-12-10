namespace BET.Data.Model.Dto
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int ProductId { get; set; }
    }
}
