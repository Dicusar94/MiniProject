using Mag.Api.Controllers.Base;
using Mag.Application.Products.Commands.Create;
using Mag.Application.Products.Commands.Delete;
using Mag.Application.Products.Commands.Update;
using Mag.Application.Products.Queries.GetAll;
using Mag.Application.Products.Queries.GetById;
using Mag.Contracts.Product.Common;
using Mag.Contracts.Product.Request;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mag.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class Products : BaseController
{
    public Products(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllProductsRequest filter)
    {
        try
        {
            var query = Mapper.Map<GetAllProductsQuery>(filter);
            var result = await Mediator.Send(query);
            var response = result.Select(Mapper.Map<ProductResponse>);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var query = new GetProductByIdQuery(id);
            var result = await Mediator.Send(query);
            var response = Mapper.Map<ProductResponse>(result);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductRequest request)
    {
        try
        {
            var command = Mapper.Map<AddProductCommand>(request);
            var result = await Mediator.Send(command);
            var response = Mapper.Map<ProductResponse>(result);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id,  UpdateProductRequest request)
    {
        try
        {
            var command = (id, request).Adapt<UpdateProductCommand>();
            var result = await Mediator.Send(command);
            var response = Mapper.Map<ProductResponse>(result);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            var command = new DeleteProductCommand(id);
            var result = await Mediator.Send(command);
            var response = Mapper.Map<ProductIdResponse>(result);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}