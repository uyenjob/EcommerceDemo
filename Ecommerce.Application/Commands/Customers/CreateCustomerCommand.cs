using MediatR;

namespace Ecommerce.Application.Commands.Customers
{
    public record CreateCustomerCommand(string Name, string Email) : IRequest<int>;
}
