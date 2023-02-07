using Mag.Domain.Common.Models;
using Mag.Domain.ProductAggregate.ValueObjects;

namespace Mag.Domain.Entities;

public sealed class Product : AggregateRoot<ProductId>
{
    public string Name { get; private set; }
    public ProductAvailability Availability { get; set; }
    public ProductPrice Pricing { get; set; }
    public ProductDiscount Discount { get; private set; }

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

    public static Product Create(string name, double stockPrice, int daysOfValidity)
    {
        return Create(
            name,
            stockPrice,
            daysOfValidity,
            DateTime.UtcNow.Date);
    }

    public static Product Create(string name, double stockPrice, int daysOfValidity, DateTime productionDate)
    {
        var discount = ProductDiscount.Create(daysOfValidity, productionDate);
        var pricing = ProductPrice.Create(stockPrice, discount);
        var availability = ProductAvailability.Create(productionDate, daysOfValidity);

        return new Product(
            ProductId.CreateUniquer(),
            name,
            availability,
            pricing,
            discount);
    }
}