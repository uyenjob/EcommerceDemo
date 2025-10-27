using MediatR;

namespace Ecommerce.Application.Commands.Products
{
    public record CreateProductCommand(string Name, decimal Price, int Stock) : IRequest<int>;
}
