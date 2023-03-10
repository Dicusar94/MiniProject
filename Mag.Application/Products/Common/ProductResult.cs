namespace Mag.Application.Products.Common;

public record  ProductResult(
    ProductIdResult Id,
    string Name,
    ProductAvailabilityResult Availability,
    ProductPriceResult Pricing,
    ProductDiscountResult Discount
);

public record ProductIdResult(Guid Value);

public record ProductAvailabilityResult(
    DateTime ProductionDate,
    DateTime ExpirationDate,
    int DaysOfValidity
);

public record ProductPriceResult(
    double Stock,
    double Sale
);

public record ProductDiscountResult(
    double Percent,
    bool IsTwentyPercent,
    bool IsFiftyPercent,
    bool IsOneHundredPercent
);