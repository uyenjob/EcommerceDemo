using AutoMapper;
using Ecommerce.Application.DTOs;
using Ecommerce.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Application.Queries.Products.Handlers;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly IEcommerceDbContext _ecommerceDbContext;
    private readonly IMapper _mapper;

    public GetProductByIdHandler(IEcommerceDbContext ecommerceDbContext, IMapper mapper)
    {
        _ecommerceDbContext = ecommerceDbContext;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _ecommerceDbContext.Products.AsNoTracking()
                                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        return product == null ? throw new KeyNotFoundException($"Order with Id {request.Id} not found") : _mapper.Map<ProductDto>(product);

    }
}
