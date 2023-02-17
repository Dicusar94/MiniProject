using ErrorOr;
using Mag.Application.Common.Interfaces.Persistence;
using Mag.Application.Products.Common;
using Mag.Domain.Common.Errors;
using MapsterMapper;
using MediatR;

namespace Mag.Application.Products.Queries.GetById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ErrorOr<ProductResult>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<ProductResult>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var product = _productRepository.GetById(request.Id);

        if (product is null)
            return Errors.Product.NotFound;

        var result = _mapper.Map<ProductResult>(product);

        return result;
    }
}