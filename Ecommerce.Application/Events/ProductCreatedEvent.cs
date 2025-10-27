using MediatR;

namespace Ecommerce.Application.Events
{
    public record ProductCreatedEvent(int ProductId) : INotification;
}
