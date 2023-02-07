using Mag.Application.Common.Interfaces.Persistence;
using Mag.Application.Products.Common;
using Mag.Domain.ProductAggregate.Entities;
using MapsterMapper;
using MediatR;

namespace Mag.Application.Products.Commands.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ProductIdResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public Task<ProductIdResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = _productRepository.GetById(request.Id);

        if (product is null)
            throw new InvalidOperationException($"{nameof(Product)} not found!");

        _productRepository.Delete(product);
        var result = _mapper.Map<ProductIdResult>(product.Id);

        return Task.FromResult(result);
    }
}