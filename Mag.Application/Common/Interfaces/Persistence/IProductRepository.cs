using Mag.Domain.ProductAggregate.Entities;
using Mag.Domain.ProductAggregate.ValueObjects;

namespace Mag.Application.Common.Interfaces.Persistence;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    Product? GetById(Guid id);
    IEnumerable<Product> Filter(Func<Product, bool> predicate);
    Task<Product> AddAsync(Product entity);
    Task AddRangeAsync(IEnumerable<Product> products);
    Product Update(Product entity);
    ProductId Delete(Product entity);
    void SaveChanges();
}