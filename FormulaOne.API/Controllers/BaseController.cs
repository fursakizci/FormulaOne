using AutoMapper;
using FormulaOne.DataService.Resositories.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected IMediator Mediator;
    protected readonly IUnitOfWork UnitOfWork;
    protected readonly IMapper Mapper;

    public BaseController
        (
        IUnitOfWork unitOfWork,
        IMapper mapper, IMediator mediator)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
        Mediator = mediator;
    }
}