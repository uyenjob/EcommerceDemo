namespace Ecommerce.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
