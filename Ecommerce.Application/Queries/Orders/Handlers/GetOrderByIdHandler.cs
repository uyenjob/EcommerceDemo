using AutoMapper;
using Ecommerce.Application.DTOs;
using Ecommerce.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Ecommerce.Application.Queries.Orders.Handlers
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IEcommerceDbContext _ecommerceDbContext;
        private readonly IMapper _mapper;

        public GetOrderByIdHandler(IEcommerceDbContext ecommerceDbContext, IMapper mapper)
        {
            _ecommerceDbContext = ecommerceDbContext;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _ecommerceDbContext.Orders.Include(o => o.Items).AsNoTracking().FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);
            return order == null ? throw new KeyNotFoundException($"Order with Id {request.Id} not found") : _mapper.Map<OrderDto>(order);
        }
    }
}
