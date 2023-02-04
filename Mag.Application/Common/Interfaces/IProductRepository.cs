using Mag.Domain.Entities;

namespace Mag.Application.Common.Interfaces;

public interface IProductRepository
{
    List<Product> GetAll();
    Product? GetById(string id);
    List<Product>? Filter(Func<Product, bool> predicate);
    void Add(Product entity);
    void AddRange(IList<Product> products);
    Product Update(string id, Product entity);
    void Delete(Product entity);
}