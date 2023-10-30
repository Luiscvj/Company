using API.Services;
using AutoMapper;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]

public class BaseApiController : ControllerBase
{

    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IUserService _userService;
    protected readonly IMapper _mapper;

    public BaseApiController(IUnitOfWork unitOfWork , IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper  = mapper;
    }
    public BaseApiController(IUserService userService)
    {
        _userService = userService;
    }

    public BaseApiController(IUnitOfWork unitOfWork, IUserService userService)
    {
        _unitOfWork = unitOfWork;
        _userService = userService;
    }

}