using Mag.Application.Products.Common;
using MediatR;

namespace Mag.Application.Products.Commands.Delete;

public record DeleteProductCommand(Guid Id) : IRequest<ProductIdResult>;