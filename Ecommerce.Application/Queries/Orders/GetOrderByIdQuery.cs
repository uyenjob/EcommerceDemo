using Ecommerce.Application.DTOs;
using MediatR;

namespace Ecommerce.Application.Queries.Orders
{
    public record GetOrderByIdQuery(int Id) : IRequest<OrderDto>;
}
