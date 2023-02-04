using MediatR;

namespace Mag.Application.Products.Commands.Create;

public class AddProductCommand : IRequest
{
    public string Name { get; set; } = default!;
    public double InitialPrice { get; set; }
    public int DaysOfValidity { get; set; }
}