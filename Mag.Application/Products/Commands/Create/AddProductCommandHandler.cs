using ErrorOr;
using Mag.Application.Common.Interfaces.Persistence;
using Mag.Application.Products.Common;
using Mag.Domain.ProductAggregate.Entities;
using MapsterMapper;
using MediatR;

namespace Mag.Application.Products.Commands.Create;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand, ErrorOr<ProductResult>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public AddProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<ProductResult>> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = request.ProductionDate is null
            ? Product.Create(
                request.Name,
                request.StockPrice,
                request.DaysOfValidity)
            : Product.Create(
                request.Name,
                request.StockPrice,
                request.DaysOfValidity,
                request.ProductionDate.Value);

        if (product.IsError) return product.Errors;

        await _productRepository.AddAsync(product.Value);
        _productRepository.SaveChanges();

        var result = _mapper.Map<ProductResult>(product.Value);

        return result;
    }
}