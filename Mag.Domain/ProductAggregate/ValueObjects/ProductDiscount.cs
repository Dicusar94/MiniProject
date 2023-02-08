using Mag.Domain.Common.Models;

namespace Mag.Domain.ProductAggregate.ValueObjects;

public sealed class ProductDiscount : ValueObject
{
    private const double TwentyPercent = 20;
    private const double FiftyPercent = 50;
    private const double OneHundredPercent = 100;
    private const double NoDiscount = 0;
    private readonly DateTime _expirationDate;
    private readonly DateTime _twentyPercentDiscountDate;
    private readonly DateTime _fiftyPercentDiscountDate;

    public double Percent { get; private set; }
    public bool IsTwentyPercent { get; private set; }
    public bool IsFiftyPercent { get; private set; }
    public bool IsOneHundredPercent { get; private set; }

    private ProductDiscount()
    {
    }

    private ProductDiscount(DateTime productionDate, int daysOfValidity)
    {
        _expirationDate = productionDate.AddDays(daysOfValidity).Date;
        _twentyPercentDiscountDate = productionDate.AddDays(daysOfValidity * 0.5).Date;
        _fiftyPercentDiscountDate = productionDate.AddDays(daysOfValidity * 0.75).Date;

        Percent = GetDiscountPercent();
        IsTwentyPercent = Percent == TwentyPercent;
        IsFiftyPercent = Percent == FiftyPercent;
        IsOneHundredPercent = Percent == OneHundredPercent;
    }

    public static ProductDiscount Create(DateTime productionDate, int daysOfValidity)
    {
        return new ProductDiscount(productionDate, daysOfValidity);
    }

    private double GetDiscountPercent()
    {
        var today = DateTime.UtcNow.Date;

        if (today >= _twentyPercentDiscountDate && today < _fiftyPercentDiscountDate)
            return TwentyPercent;

        if (today >= _fiftyPercentDiscountDate && today < _expirationDate)
            return FiftyPercent;

        if (today >= _expirationDate)
            return OneHundredPercent;

        return NoDiscount;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Percent;
        yield return IsTwentyPercent;
        yield return IsFiftyPercent;
        yield return IsOneHundredPercent;
    }
}