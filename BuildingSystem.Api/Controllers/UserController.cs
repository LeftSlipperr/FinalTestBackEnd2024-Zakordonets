using BankSystemApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BuildingSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
}