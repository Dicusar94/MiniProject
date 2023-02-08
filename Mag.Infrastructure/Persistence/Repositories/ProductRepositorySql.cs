using Mag.Application.Common.Interfaces.Persistence;
using Mag.Domain.ProductAggregate.Entities;
using Mag.Domain.ProductAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Mag.Infrastructure.Persistence.Repositories;

public class ProductRepositorySql :IProductRepository
{
    private readonly MagContext _context;
    public ProductRepositorySql(MagContext context)
    {
        _context = context;
    }

    public IEnumerable<Product> GetAll()
    {
        return _context.Products;
    }

    public Product? GetById(Guid id)
    {
        return _context.Products.FirstOrDefault(x => x.Id.Value == id);
    }

    public IEnumerable<Product> Filter(Func<Product, bool> predicate)
    {
        return _context.Products.Where(predicate);
    }

    public async Task<Product> AddAsync(Product entity)
    {
        await _context.Products.AddAsync(entity);
        return entity;
    }

    public async Task AddRangeAsync(IEnumerable<Product> products)
    {
        await _context.AddRangeAsync(products);
    }

    public Product Update(Product entity)
    {
        return _context.Products.Update(entity).Entity;
    }

    public ProductId Delete(Product entity)
    {
        _context.Products.Remove(entity);
        return entity.Id;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}