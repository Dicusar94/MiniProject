namespace Mag.Contracts.Product.Request;

public record UpdateProductRequest(
    string Name,
    double StockPrice,
    int DaysOfValidity,
    DateTime? ProductionDate);