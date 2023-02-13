using Mag.Application.Products.Common;
using Mag.Domain.ProductAggregate.Entities;
using Mapster;

namespace Mag.Application.Common.Mapping;

public class ProductMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Product, ProductResult>()
            .Map(dest => dest.Discount, src => src.GetDiscount())
            .Map(dest => dest.Pricing.Sale,
                src => src.Pricing.GetSalePrice(src.GetDiscount()))
            .Map(dest => dest.Availability.RemainingDaysOfValidity, 
                src => src.Availability.GetRemainingValidityDays(DateTime.UtcNow));
    }
}