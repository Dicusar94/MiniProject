using Mag.Domain.Common.Models;
using Mag.Domain.ProductAggregate.ValueObjects;

namespace Mag.Domain.ProductAggregate.Entities;

public sealed class Product : AggregateRoot<ProductId>
{
    public string Name { get; private set; } = null!;
    public ProductAvailability Availability { get; private set; } = null!;
    public ProductPrice Pricing { get; private set; } = null!;
    public ProductDiscount Discount { get; private set; } = null!;

    private Product() : base(ProductId.CreateUniquer())
    {
    }

    private Product(
        ProductId id,
        string name,
        ProductAvailability availability,
        ProductPrice pricing,
        ProductDiscount discount)
        : base(id)
    {
        Id = id;
        Name = name;
        Availability = availability;
        Pricing = pricing;
        Discount = discount;
    }

    public static Product Create(string name, double stockPrice, int daysOfValidity, DateTime? productionDate = default)
    {
        var prodDate = productionDate ?? DateTime.UtcNow.Date;
        var discount = ProductDiscount.Create(prodDate, daysOfValidity);
        var pricing = ProductPrice.Create(stockPrice, discount);
        var availability = ProductAvailability.Create(prodDate, daysOfValidity);

        return new Product(
            ProductId.CreateUniquer(),
            name,
            availability,
            pricing,
            discount);
    }

    public void Update(string name, double stockPrice, int daysOfValidity, DateTime? productionDate)
    {
        var prodDate = productionDate ?? DateTime.UtcNow.Date;
        var availability = ProductAvailability.Create(prodDate, daysOfValidity);
        var discount = ProductDiscount.Create(prodDate, daysOfValidity);
        var pricing = ProductPrice.Create(stockPrice, Discount);

        Name = name;
        Discount = discount;
        Pricing = pricing;
        Availability = availability;
    }
}