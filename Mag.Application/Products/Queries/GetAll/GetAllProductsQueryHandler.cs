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
            .AsEnumerable()
            .Where(FilterName(request.Name))
            .Where(FilterDiscountPercent(request.DiscountFrom, request.DiscountTo))
            .Where(FilterIsOneMonthReaming(request.IsOneMonthTillExpiration))
            .Where(FilterIsExpired(request.IsExpired));

        var result = products.Select(_mapper.Map<ProductResult>);

        return Task.FromResult(result);
    }

    private static Func<Product, bool> FilterIsExpired(bool? isExpired)
    {
        if (isExpired is null) return _ => true;

        if (isExpired.Value)
            return x => x.Availability.ExpirationDate < DateTime.UtcNow.Date;

        if (!isExpired.Value)
            return x => x.Availability.ExpirationDate > DateTime.UtcNow.Date;

        return _ => true;
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
            return x.GetDiscount().Percent >= from && x.GetDiscount().Percent < to;
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