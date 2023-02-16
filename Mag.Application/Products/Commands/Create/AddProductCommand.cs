using ErrorOr;
using Mag.Application.Products.Common;
using MediatR;

namespace Mag.Application.Products.Commands.Create;

public class AddProductCommand : IRequest<ErrorOr<ProductResult>>
{
    public string Name { get; set; } = default!;
    public double StockPrice { get; set; }
    public int DaysOfValidity { get; set; }
    public DateTime? ProductionDate { get; set; }
}