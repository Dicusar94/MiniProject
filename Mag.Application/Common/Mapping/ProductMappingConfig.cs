using Mag.Application.Products.Common;
using Mag.Domain.ProductAggregate.Entities;
using Mapster;

namespace Mag.Application.Common.Mapping;

public class ProductMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Product, ProductResult>();
    }
}