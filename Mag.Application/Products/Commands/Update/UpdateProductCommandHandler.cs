using Mag.Application.Common.Interfaces.Persistence;
using Mag.Application.Products.Common;
using Mag.Domain.ProductAggregate.Entities;
using MapsterMapper;
using MediatR;

namespace Mag.Application.Products.Commands.Update;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public Task<ProductResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _productRepository.GetById(request.Id);

        if (product is null)
            throw new InvalidOperationException($"{nameof(Product)} not found!");

        product.Update(
            request.Name,
            request.StockPrice,
            request.DaysOfValidity,
            request.ProductionDate);

        _productRepository.Update(product);
        _productRepository.SaveChanges();

        var result = _mapper.Map<ProductResult>(product);

        return Task.FromResult(result);
    }
}