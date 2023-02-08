using Mag.Application.Common.Interfaces.Persistence;
using Mag.Application.Products.Common;
using Mag.Domain.ProductAggregate.Entities;
using MapsterMapper;
using MediatR;

namespace Mag.Application.Products.Queries.GetById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public Task<ProductResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = _productRepository.GetById(request.Id);

        if (product is null)
            throw new InvalidOperationException($"{nameof(Product)} not found!");

        var result = _mapper.Map<ProductResult>(product);

        return Task.FromResult(result);
    }
}