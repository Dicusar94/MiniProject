using Mag.Domain.ProductAggregate.Entities;
using Mag.Domain.ProductAggregate.ValueObjects;

namespace Mag.Application.Common.Interfaces.Persistence;

public interface IProductRepository
{
    List<Product> GetAll();
    Product? GetById(Guid id);
    List<Product>? Filter(Func<Product, bool> predicate);
    Product Add(Product entity);
    void AddRange(IList<Product> products);
    Product Update(Product entity);
    ProductId Delete(Product entity);
}