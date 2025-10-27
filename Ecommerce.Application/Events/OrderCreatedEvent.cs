using MediatR;

namespace Ecommerce.Application.Events
{
    public record OrderCreatedEvent(int OrderId, int CustomerId) : INotification;
}
