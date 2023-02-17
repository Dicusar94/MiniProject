using ErrorOr;
using Mag.Domain.Common.Models;
using Mag.Domain.ProductAggregate.ValueObjects;

namespace Mag.Domain.ProductAggregate.Entities;

public sealed class Product : AggregateRoot<ProductId>
{
    public string Name { get; private set; } = null!;
    public ProductAvailability Availability { get; private set; } = null!;
    public ProductPrice Pricing { get; private set; } = null!;

    private Product() : base(ProductId.CreateUniquer())
    {
    }

    private Product(
        ProductId id,
        string name,
        ProductAvailability availability,
        ProductPrice pricing)
        : base(id)
    {
        Id = id;
        Name = name;
        Availability = availability;
        Pricing = pricing;
    }

    public static ErrorOr<Product> Create(string name, double stockPrice, int daysOfValidity, DateTime? productionDate = default)
    {
        var errors = new List<Error>();

        var prodDate = productionDate ?? DateTime.UtcNow.Date;

        var availability = ProductAvailability.Create(prodDate, daysOfValidity);
        if (availability.IsError) errors.AddRange(availability.Errors);

        var pricing = ProductPrice.Create(stockPrice);
        if (pricing.IsError) errors.AddRange(pricing.Errors);

        if(errors.Count > 0) return errors;

        return new Product(
            ProductId.CreateUniquer(),
            name,
            availability.Value,
            pricing.Value);
    }

    public ErrorOr<Updated> Update(string name, double stockPrice, int daysOfValidity, DateTime? productionDate)
    {
        var errors = new List<Error>();

        var prodDate = productionDate ?? DateTime.UtcNow.Date;

        var availability = ProductAvailability.Create(prodDate, daysOfValidity);
        if (availability.IsError) errors.AddRange(availability.Errors);

        var pricing = ProductPrice.Create(stockPrice);
        if (pricing.IsError) errors.AddRange(pricing.Errors);

        if(errors.Count > 0) return errors;

        Name = name;
        Pricing = pricing.Value;
        Availability = availability.Value;

        return Result.Updated;
    }

    public ProductDiscount GetDiscount()
    {
        return ProductDiscount.Create(
            Availability.ProductionDate,
            Availability.DaysOfValidity,
            DateTime.UtcNow);
    }
}