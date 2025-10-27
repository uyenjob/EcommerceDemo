namespace Ecommerce.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public Customer? Customer { get; set; }
        public int CustomerId { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
        public void CalculateTotal()
        {
            Total = Items?.Sum(i => i.Price * i.Quantity) ?? 0;
        }
    }
}
