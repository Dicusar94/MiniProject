using Mag.Domain.Common.Models;

namespace Mag.Domain.ProductAggregate.ValueObjects;

public sealed class ProductPrice : ValueObject
{
    public double Stock { get; }
    public double Sale { get; }

    private ProductPrice(double stock, double sale)
    {
        Stock = stock;
        Sale = sale;
    }

    public static ProductPrice Create(double stockPrice, ProductDiscount discount)
    {
        if (stockPrice < 0)
            throw new InvalidOperationException($"{nameof(Stock)} price must be greater thant 0");

        var salePrice = CalculateSalePrice(stockPrice, discount);
        return new ProductPrice(stockPrice, salePrice);
    }

    private static double CalculateSalePrice(double stockPrice, ProductDiscount discount)
    {
        var discountAmount = stockPrice * discount.Percent / 100;
        return stockPrice - discountAmount;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Stock;
        yield return Sale;
    }
}