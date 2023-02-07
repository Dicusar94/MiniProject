namespace Mag.Contracts.Product.Request;

public record CreateProductRequest(
    string Name,
    double StockPrice,
    int DaysOfValidity,
    DateTime? ProductionDate);