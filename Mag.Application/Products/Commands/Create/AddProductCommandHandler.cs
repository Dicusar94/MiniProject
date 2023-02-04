using Mag.Application.Common.Interfaces;
using MediatR;

namespace Mag.Application.Products.Commands.Create;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Unit>
{
    private readonly IProductRepository _productRepository;

    public AddProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = Domain.Entities.Product.Create(request.Name, request.InitialPrice, request.DaysOfValidity);
        _productRepository.Add(product);
        return Task.FromResult(Unit.Value);
    }
}