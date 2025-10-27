using Ecommerce.Application.DTOs;
using MediatR;

namespace Ecommerce.Application.Queries.Products
{
    public record GetProductByIdQuery(int Id) : IRequest<ProductDto>;
}
