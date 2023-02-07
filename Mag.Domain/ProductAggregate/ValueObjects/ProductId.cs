using Mag.Domain.Common.Models;

namespace Mag.Domain.ProductAggregate.ValueObjects;

public sealed class ProductId : ValueObject
{
    public Guid Value { get; }

    private ProductId(Guid value)
    {
        Value = value;
    }

    public static ProductId CreateUniquer()
    {
        return new (Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}