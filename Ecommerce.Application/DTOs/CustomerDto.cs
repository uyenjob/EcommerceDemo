namespace Ecommerce.Application.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public List<OrderDto> Orders { get; set; } = new();
    }
}
