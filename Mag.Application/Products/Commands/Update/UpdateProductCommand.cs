using Mag.Domain.Entities;
using MediatR;

namespace Mag.Application.Products.Commands.Update;

public class UpdateProductCommand : IRequest<Product>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public double InitialPrice { get; set; }
    public int ValidityDays { get; set; }
}