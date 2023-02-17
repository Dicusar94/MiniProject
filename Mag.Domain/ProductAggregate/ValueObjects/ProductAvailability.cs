using ErrorOr;
using Mag.Domain.Common.Errors;

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

    public static ErrorOr<ProductAvailability> Create(DateTime productionDate, int daysOfValidity)
    {
        if (daysOfValidity <= 0)
            return Errors.Product.ProductAvailability.DaysOfValidity;

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