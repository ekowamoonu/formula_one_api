using AutoMapper;
using FormulaOne.DataService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
// ControllerBase is the base class for ASP.NET Core MVC controllers that don't use view-related features.
public class BaseController : ControllerBase
{

    protected readonly IUnitOfWork _unitOfWork;

    protected readonly IMapper _mapper;

    public BaseController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

}