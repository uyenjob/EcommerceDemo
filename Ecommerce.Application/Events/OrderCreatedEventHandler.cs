using Ecommerce.Application.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.Events
{
    public class OrderCreatedEventHandler : INotificationHandler<OrderCreatedEvent>
    {
        private readonly ILogger<OrderCreatedEventHandler> _logger;
        private readonly IEmailSender _emailSender;

        public OrderCreatedEventHandler(ILogger<OrderCreatedEventHandler> logger, IEmailSender emailSender)
        {
            _logger = logger;
            _emailSender = emailSender;
        }

        public async Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
        {
            // Send logging information
            _logger.LogInformation($"Order created: Id = {notification.OrderId}, Customer = {notification.CustomerId}");

            // Send email to customer
            string to = "customer@example.com";
            string subject = $"Order #{notification.OrderId} Created!";
            string body = $"Your order with ID {notification.OrderId} has been successfully created.";

            await _emailSender.SendAsync(to, subject, body);
        }
    }
}
