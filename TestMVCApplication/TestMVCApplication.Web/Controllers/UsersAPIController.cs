using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using TestMVCApplication.Web.Models;

namespace TestMVCApplication.Web.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class UsersAPIController : ControllerBase
{
    // https://localhost:7245/api/UsersAPI
    // {
    //     "username": "Test API 1",
    //     "firstName": "Test API 1",
    //     "lastName": "Test API 1"
    // }

    [HttpPost]
    public IActionResult Post(CreateUserViewModel createUserViewModel)
    {
        UsersController.StaticUsers.Add(new UserViewModel
        {
            Username = createUserViewModel.Username,
            FirstName = createUserViewModel.FirstName,
            LastName = createUserViewModel.LastName
        });

        return Created("Users/Index", createUserViewModel);
    }

    [HttpPost]
    public IActionResult Post([FromHeader] string contentType, [FromBody]CreateUserViewModel createUserViewModel)
    {
        UsersController.StaticUsers.Add(new UserViewModel
        {
            Username = createUserViewModel.Username,
            FirstName = createUserViewModel.FirstName,
            LastName = createUserViewModel.LastName
        });

        return Created("Users/Index", createUserViewModel);
    }
}