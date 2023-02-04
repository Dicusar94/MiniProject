using Mag.Domain.Entities;
using MediatR;

namespace Mag.Application.Products.Commands.Update;

public class UpdateProductCommand : IRequest<Product>
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public double InitialPrice { get; set; }
    public int ValidityDays { get; set; }
}