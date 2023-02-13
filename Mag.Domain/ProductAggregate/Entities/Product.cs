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

    public static Product Create(string name, double stockPrice, int daysOfValidity, DateTime? productionDate = default)
    {
        var prodDate = productionDate ?? DateTime.UtcNow.Date;
        var pricing = ProductPrice.Create(stockPrice);
        var availability = ProductAvailability.Create(prodDate.Date, daysOfValidity);

        return new Product(
            ProductId.CreateUniquer(),
            name,
            availability,
            pricing);
    }

    public void Update(string name, double stockPrice, int daysOfValidity, DateTime? productionDate)
    {
        var prodDate = productionDate ?? DateTime.UtcNow.Date;
        var availability = ProductAvailability.Create(prodDate, daysOfValidity);
        var pricing = ProductPrice.Create(stockPrice);

        Name = name;
        Pricing = pricing;
        Availability = availability;
    }

    public ProductDiscount GetDiscount()
    {
        return ProductDiscount.Create(
            Availability.ProductionDate,
            Availability.DaysOfValidity,
            DateTime.UtcNow);
    }
}