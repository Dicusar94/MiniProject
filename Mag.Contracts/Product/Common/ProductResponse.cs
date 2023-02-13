namespace Mag.Contracts.Product.Common;

public record  ProductResponse(
    ProductIdResponse Id,
    string Name,
    ProductAvailabilityResponse Availability,
    ProductPriceResponse Pricing,
    ProductDiscountResponse Discount
);

public record ProductIdResponse(Guid Value);

public record ProductAvailabilityResponse(
    DateTime ProductionDate,
    DateTime ExpirationDate,
    int DaysOfValidity,
    int RemainingDaysOfValidity
);

public record ProductPriceResponse(
    double Stock,
    double Sale
);

public record ProductDiscountResponse(
    double Percent
);