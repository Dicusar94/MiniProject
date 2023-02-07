using Mag.Application.Common.Interfaces.Persistence;
using Mag.Domain.ProductAggregate.Entities;
using Mag.Domain.ProductAggregate.ValueObjects;

namespace Mag.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private static readonly List<Product> Products;

    static ProductRepository()
    {
        Products = new List<Product>
        {
            Product.Create("20Discount", 10, 20, DateTime.Now.AddDays(-11)),
            Product.Create("50Discount", 14, 30, DateTime.Now.AddDays(-25)),
            Product.Create("0Price", 15, 40, DateTime.Now.AddDays(-50)),
            Product.Create("AtLeastOneMonthValidity", 16, 25),
            Product.Create("Other2", 17, 60),
        };
    }

    public List<Product> GetAll()
    {
        return Products;
    }

    public Product? GetById(Guid id)
    {
        return Products.Find(x => x.Id.Value == id);
    }

    public List<Product>? Filter(Func<Product, bool> predicate)
    {
        return Products.Where(predicate).ToList();
    }

    public Product Add(Product entity)
    {
        Products.Add(entity);
        return entity;
    }

    public void AddRange(IList<Product> products)
    {
        Products.AddRange(products);
    }

    public Product Update(Product entity)
    {
        var product = Products.Find(x => x == entity);

        product?.Update(
            entity.Name,
            entity.Pricing.Stock,
            entity.Availability.DaysOfValidity,
            entity.Availability.ProductionDate);

        return product!;
    }

    public ProductId Delete(Product entity)
    {
        Products.Remove(entity);
        return entity.Id;
    }
}