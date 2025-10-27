using AutoMapper;
using Ecommerce.Application.DTOs;
using Ecommerce.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Application.Queries.Customers.Handlers
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
    {

        private readonly IEcommerceDbContext _ecommerceDbContext;
        private readonly IMapper _mapper;

        public GetCustomerByIdHandler(IEcommerceDbContext ecommerceDbContext, IMapper mapper)
        {
            _ecommerceDbContext = ecommerceDbContext;
            _mapper = mapper;
        }

        public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _ecommerceDbContext.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.Id == request.Id);
            return customer == null ? throw new KeyNotFoundException($"Customer with Id {request.Id} not found") : _mapper.Map<CustomerDto>(customer);
        }

    }
}
