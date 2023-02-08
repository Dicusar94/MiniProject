using Mag.Application.Common.Interfaces.Persistence;
using Mag.Domain.ProductAggregate.Entities;
using Mag.Domain.ProductAggregate.ValueObjects;

namespace Mag.Infrastructure.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private static readonly List<Product> Products;

    static ProductRepository()
    {
        Products = new List<Product>
        {
            Product.Create("20Discount", 10, 20, DateTime.UtcNow.AddDays(-11).Date),
            Product.Create("50Discount", 14, 30, DateTime.UtcNow.AddDays(-25).Date),
            Product.Create("0Price", 15, 40, DateTime.UtcNow.AddDays(-50).Date),
            Product.Create("AtLeastOneMonthValidity", 16, 25),
            Product.Create("Other2", 17, 60),
        };
    }

    public IEnumerable<Product> GetAll()
    {
        return Products;
    }

    public Product? GetById(Guid id)
    {
        return Products.Find(x => x.Id.Value == id);
    }

    public IEnumerable<Product> Filter(Func<Product, bool> predicate)
    {
        return Products.Where(predicate);
    }

    public Task<Product> AddAsync(Product entity)
    {
        Products.Add(entity);
        return Task.FromResult(entity);
    }

    public async Task AddRangeAsync(IEnumerable<Product> products)
    {
        Products.AddRange(products);
        await Task.CompletedTask;
    }

    public Product Update(Product entity)
    {
        return entity;
    }

    public ProductId Delete(Product entity)
    {
        Products.Remove(entity);
        return entity.Id;
    }

    public void SaveChanges()
    {
    }
}