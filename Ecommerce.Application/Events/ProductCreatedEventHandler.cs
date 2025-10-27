using MediatR;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.Events
{
    public class ProductCreatedEventHandler : INotificationHandler<ProductCreatedEvent>
    {
        private readonly ILogger<ProductCreatedEventHandler> _logger;

        public ProductCreatedEventHandler(ILogger<ProductCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("ProductCreatedEvent triggered for ProductId: {ProductId}", notification.ProductId);

            return Task.CompletedTask;
        }
    }
}
