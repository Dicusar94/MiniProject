namespace Mag.Contracts.Product.Request;

public record GetAllProductsRequest(
    string? Name,
    bool? IsExpired,
    bool? IsOneMonthTillExpiration,
    double? DiscountFrom,
    double? DiscountTo);