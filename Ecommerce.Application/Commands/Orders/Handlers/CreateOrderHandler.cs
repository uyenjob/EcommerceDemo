using Ecommerce.Application.Events;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Commands.Orders.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IEcommerceDbContext _ecommerceDbContext;
        private readonly IMediator _mediator;

        public CreateOrderHandler(IEcommerceDbContext ecommerceDbContext, IMediator mediator)
        {
            _ecommerceDbContext = ecommerceDbContext;
            _mediator = mediator;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                CustomerId = request.CustomerId,
                CreatedAt = DateTime.UtcNow,
            };

            foreach (var item in request.Items)
            {
                // Check if product exists
                var product = await _ecommerceDbContext.Products.FindAsync([item.ProductId], cancellationToken);
                if (product == null)
                {
                    throw new Exception($"Product with ID {item.ProductId} not found.");
                }

                // Check if enough stock is available
                if (product.Stock < item.Quantity)
                {
                    throw new Exception($"Insufficient stock for product ID {item.ProductId}. Requested: {item.Quantity}, Available: {product.Stock}");
                }

                // Reduce product stock
                product.Stock -= item.Quantity;

                // Create order item
                order.Items.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = product.Price,
                });

                // total will be calculated in CalculateTotal method
                order.CalculateTotal();
            }

            _ecommerceDbContext.Orders.Add(order);
            await _ecommerceDbContext.SaveChangesAsync(cancellationToken);
            await _mediator.Publish(new OrderCreatedEvent(order.Id, order.CustomerId), cancellationToken);
            return order.Id;
        }
    }
}
