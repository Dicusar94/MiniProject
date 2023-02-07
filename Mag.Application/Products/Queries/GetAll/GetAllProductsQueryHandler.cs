using Mag.Application.Common.Interfaces.Persistence;
using Mag.Application.Products.Common;
using Mag.Domain.ProductAggregate.Entities;
using MapsterMapper;
using MediatR;

namespace Mag.Application.Products.Queries.GetAll;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductResult>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public Task<IEnumerable<ProductResult>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = _productRepository.GetAll()
            .Where(FilterName(request.Name))
            .Where(FilterDiscountPercent(request.DiscountFrom, request.DiscountTo))
            .Where(FilterIsOneMonthReaming(request.IsOneMonthTillExpiration));

        var result = products.Select(_mapper.Map<ProductResult>);

        return Task.FromResult(result);
    }

    private static Func<Product, bool> FilterName(string? name)
    {
        return x => string.IsNullOrEmpty(name) || x.Name == name;
    }

    private static Func<Product, bool> FilterDiscountPercent(double? from, double? to)
    {
        return x =>
        {
            from ??= 0; to ??= 101;
            return x.Discount.Percent >= from && x.Discount.Percent < to;
        };
    }

    private static Func<Product, bool> FilterIsOneMonthReaming(bool? isOneMonthRemaining)
    {
        if (!(isOneMonthRemaining ?? false)) return _ => true;

        return x =>
        {
            var afterOneMonthDate = DateTime.UtcNow.AddMonths(1).Date;
            return afterOneMonthDate <= x.Availability.ExpirationDate;
        };
    }
}