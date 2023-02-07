using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mag.Api.Controllers.Base;

public abstract class BaseController : ControllerBase
{
    protected IMediator Mediator { get; }
    protected IMapper Mapper { get; }
    protected BaseController(IMediator mediator, IMapper mapper)
    {
        Mediator = mediator;
        Mapper = mapper;
    }
}