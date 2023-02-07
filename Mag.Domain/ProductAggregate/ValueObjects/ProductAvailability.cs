namespace Mag.Domain.ProductAggregate.ValueObjects;

public sealed class ProductAvailability
{
    public DateTime ProductionDate { get; }
    public DateTime ExpirationDate { get; }
    public int DaysOfValidity { get; }

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
}