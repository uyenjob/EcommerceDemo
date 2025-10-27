using Ecommerce.Application.Events;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Commands.Products.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IEcommerceDbContext _ecommerceDbContext;
        private readonly IMediator _mediator;

        public CreateProductHandler(IEcommerceDbContext ecommerceDbContext, IMediator mediator)
        {
            _ecommerceDbContext = ecommerceDbContext;
            _mediator = mediator;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock
            };

            _ecommerceDbContext.Products.Add(product);
            await _ecommerceDbContext.SaveChangesAsync(cancellationToken);
            await _mediator.Publish(new OrderCreatedEvent(product.Id, product.Id), cancellationToken);

            return product.Id;
        }
    }
}