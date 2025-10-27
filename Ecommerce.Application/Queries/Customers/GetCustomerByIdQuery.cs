using Ecommerce.Application.DTOs;
using MediatR;

namespace Ecommerce.Application.Queries.Customers
{
    public record GetCustomerByIdQuery(int Id) : IRequest<CustomerDto>;
}
