using MediatR;

namespace Ecommerce.Application.Events
{
    public record CustomerCreatedEvent(int CustomerId) : INotification;
}
