using MediatR;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.Events
{
    public class CustomerCreatedEventHandler : INotificationHandler<CustomerCreatedEvent>
    {
        private readonly ILogger<OrderCreatedEventHandler> _logger;

        public CustomerCreatedEventHandler(ILogger<OrderCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Customer created: Id = {notification.CustomerId}");
            return Task.CompletedTask;
        }
    }
}
