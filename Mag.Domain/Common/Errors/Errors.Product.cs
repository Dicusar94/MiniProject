using ErrorOr;

namespace Mag.Domain.Common.Errors;

public static partial class Errors
{
    public static class Product
    {
        public static class ProductAvailability
        {
            public static Error DaysOfValidity => Error.Validation(
                code: "Product.Availability.DaysOfValidity",
                description: "must be greater than 0"
            );
        }

        public static class ProductPrice
        {
            public static Error StockPrice => Error.Validation(
                code: "Product.Price.StockPrice",
                description : "must be greater than 0"
            );
        }
    }
}