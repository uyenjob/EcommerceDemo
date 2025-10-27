using Ecommerce.Application.Events;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Commands.Customers.Handlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly IEcommerceDbContext _ecommerceDbContext;
        private readonly IMediator _mediator;

        public CreateCustomerHandler(IEcommerceDbContext ecommerceDbContext, IMediator mediator)
        {
            _ecommerceDbContext = ecommerceDbContext;
            _mediator = mediator;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Customer customer = new Customer
                {
                    Name = request.Name,
                    Email = request.Email,
                };
                _ecommerceDbContext.Customers.Add(customer);
                await _ecommerceDbContext.SaveChangesAsync(cancellationToken);
                await _mediator.Publish(new CustomerCreatedEvent(customer.Id), cancellationToken);
                return customer.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
