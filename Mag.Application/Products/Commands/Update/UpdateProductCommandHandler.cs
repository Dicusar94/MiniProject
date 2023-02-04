using Mag.Application.Common.Interfaces;
using Mag.Domain.Entities;
using MediatR;

namespace Mag.Application.Products.Commands.Update;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _productRepository.GetById(request.Id);

        if (product is null)
        {
            const string errorMessage = $"{nameof(Product)} not found!";
            throw new InvalidOperationException(errorMessage);
        }

        product.Update(request.Name, request.InitialPrice, request.ValidityDays);
        return Task.FromResult(product);
    }
}