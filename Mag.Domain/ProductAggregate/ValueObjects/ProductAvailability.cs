namespace Mag.Domain.ProductAggregate.ValueObjects;

public sealed class ProductAvailability
{
    public DateTime ProductionDate { get; private set; }
    public DateTime ExpirationDate { get; private set; }
    public int DaysOfValidity { get; private set; }

    private ProductAvailability()
    {
    }

    private ProductAvailability(DateTime productionDate, DateTime expirationDate, int daysOfValidity)
    {
        ProductionDate = productionDate;
        ExpirationDate = expirationDate;
        DaysOfValidity = daysOfValidity;
    }

    public static ProductAvailability Create(DateTime productionDate, int daysOfValidity)
    {
        if (daysOfValidity < 0)
            throw new InvalidOperationException($"{nameof(DaysOfValidity)} must be greater than 0");

        var expirationDate = productionDate.AddDays(daysOfValidity).Date;

        return new ProductAvailability(
            productionDate,
            expirationDate,
            daysOfValidity);
    }

    public int GetRemainingValidityDays(DateTime today)
    {
        return (int)(ExpirationDate.Date - today.ToUniversalTime().Date).TotalDays;
    }
}