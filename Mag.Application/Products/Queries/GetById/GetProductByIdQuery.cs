using ErrorOr;
using Mag.Application.Products.Common;
using MediatR;

namespace Mag.Application.Products.Queries.GetById;

public record GetProductByIdQuery(Guid Id) : IRequest<ErrorOr<ProductResult>>;