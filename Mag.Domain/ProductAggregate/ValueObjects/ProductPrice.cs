using ErrorOr;
using Mag.Domain.Common.Models;
using Mag.Domain.Common.Errors;

namespace Mag.Domain.ProductAggregate.ValueObjects;

public sealed class ProductPrice : ValueObject
{
    public double Stock { get; private set; }

    private ProductPrice()
    {
    }

    private ProductPrice(double stock)
    {
        Stock = stock;
    }

    public static ErrorOr<ProductPrice> Create(double stockPrice)
    {
        if (stockPrice <= 0)
        {
            return Errors.Product.ProductPrice.StockPrice;
        }

        return new ProductPrice(stockPrice);
    }

    public double GetSalePrice(ProductDiscount discount)
    {
        var discountAmount = Stock * discount.Percent / 100;
        return Stock - discountAmount;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Stock;
    }
}