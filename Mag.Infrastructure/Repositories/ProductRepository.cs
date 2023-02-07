using Mag.Application.Common.Interfaces;
using Mag.Domain.Entities;

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

    public Product? GetById(string id)
    {
        return Products.Find(x => x.Id.ToString() == id);
    }

    public List<Product>? Filter(Func<Product, bool> predicate)
    {
        return Products.Where(predicate).ToList();
    }

    public void Add(Product entity)
    {
        Products.Add(entity);
    }

    public void AddRange(IList<Product> products)
    {
        Products.AddRange(products);
    }

    public void Delete(Product entity)
    {
        Products.Remove(entity);
    }
}