using Mag.Application.Products.Commands.Update;
using Mag.Contracts.Product.Request;
using Mapster;

namespace Mag.Api.Common.Mapping;

public class ProductMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(Guid Id, UpdateProductRequest request), UpdateProductCommand>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest, src => src.request);
    }
}