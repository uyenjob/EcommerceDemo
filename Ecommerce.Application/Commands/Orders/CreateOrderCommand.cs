using Ecommerce.Application.DTOs;
using MediatR;

namespace Ecommerce.Application.Commands.Orders
{
    public record CreateOrderCommand(int CustomerId, List<OrderItemDto> Items) : IRequest<int>;
}
