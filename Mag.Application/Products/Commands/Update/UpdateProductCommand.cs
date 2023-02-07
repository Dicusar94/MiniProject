using Mag.Application.Products.Common;
using MediatR;

namespace Mag.Application.Products.Commands.Update;

public class UpdateProductCommand : IRequest<ProductResult>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public double StockPrice { get; set; }
    public int DaysOfValidity { get; set; }
    public DateTime? ProductionDate { get; set; }
}