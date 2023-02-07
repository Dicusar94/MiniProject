using Mag.Application.Products.Common;
using MediatR;

namespace Mag.Application.Products.Queries.GetAll;

public record GetAllProductsQuery(
    string? Name,
    bool? IsExpired,
    bool? IsOneMonthTillExpiration,
    double? DiscountFrom,
    double? DiscountTo) : IRequest<IEnumerable<ProductResult>>;