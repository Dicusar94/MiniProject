using Mag.Application.Common.Interfaces;
using Mag.Application.Products.Commands.Create;
using Mag.Application.Products.Commands.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mag.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class Products : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IProductRepository _productRepository;

    public Products(IMediator mediator, IProductRepository productRepository)
    {
        _mediator = mediator;
        _productRepository = productRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _productRepository.GetAll();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        try
        {
            var result = _productRepository.GetById(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("/expired")]
    public IActionResult GetExpired()
    {
        try
        {
            var products = _productRepository.Filter(x => x.IsExpiredValidityDays);
            return Ok(products);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet("/discounted/50")]
    public IActionResult GetDiscounted50()
    {
        try
        {
            var products = _productRepository.Filter(x => x.Discount == 0.5)!
                .OrderBy(x => x.InitialPrice);
            return Ok(products);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("/discounted/20")]
    public IActionResult GetDiscounted20()
    {
        try
        {
            var products = _productRepository.Filter(x => x.Discount == 0.2)!
                .OrderBy(x => x.InitialPrice);
            return Ok(products);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("/validity/1month")]
    public IActionResult GetValidity1Month()
    {
        try
        {
            var products = _productRepository.Filter(x => x.IsOneMonthBeforeExpired);
            return Ok(products);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("/withoutexpired")]
    public IActionResult GetWithoutExpired()
    {
        try
        {
            var products = _productRepository.Filter(x => !x.IsExpiredValidityDays);
            return Ok(products);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public IActionResult Create(AddProductCommand model)
    {
        try
        {
            _ = _mediator.Send(model).Result;
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    public IActionResult Update(UpdateProductCommand model)
    {
        try
        {
            var result = _mediator.Send(model).Result;
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete]
    public IActionResult Delete(string id)
    {
        try
        {
            var product = _productRepository.GetById(id);
            if (product is null)
            {
                throw new InvalidOperationException("product not found!");
            }

            _productRepository.Delete(product);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}