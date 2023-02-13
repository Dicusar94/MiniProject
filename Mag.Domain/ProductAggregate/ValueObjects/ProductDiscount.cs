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
    private readonly DateTime _today;

    public double Percent { get; }
    public bool IsTwentyPercent { get; }
    public bool IsFiftyPercent { get; }
    public bool IsOneHundredPercent { get; }

    private ProductDiscount()
    {
    }

    private ProductDiscount(DateTime productionDate, int daysOfValidity, DateTime today)
    {
        _expirationDate = productionDate.AddDays(daysOfValidity).Date;
        _twentyPercentDiscountDate = productionDate.AddDays(daysOfValidity * 0.5).Date;
        _fiftyPercentDiscountDate = productionDate.AddDays(daysOfValidity * 0.75).Date;
        _today = today;

        Percent = GetDiscountPercent();
        IsTwentyPercent = Percent == TwentyPercent;
        IsFiftyPercent = Percent == FiftyPercent;
        IsOneHundredPercent = Percent == OneHundredPercent;
    }

    public static ProductDiscount Create(DateTime productionDate, int daysOfValidity, DateTime today)
    {
        return new ProductDiscount(productionDate, daysOfValidity, today);
    }

    private double GetDiscountPercent()
    {
        var today = _today.ToUniversalTime().Date;

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