using Microsoft.AspNetCore.Mvc;
using TestMVCApplication.Web.Models;

namespace TestMVCApplication.Web.Controllers;

public class UsersController : Controller
{
    public static IList<UserViewModel> StaticUsers { get; } = new List<UserViewModel>
    {
        new()
        {
            Username = "Username 1",
            FirstName = "FirstName 1",
            LastName = "LastName 1"
        },
        new()
        {
            Username = "Username 2",
            FirstName = "FirstName 2",
            LastName = "LastName 2"
        },
        new()
        {
            Username = "Username 3",
            FirstName = "FirstName 3",
            LastName = "LastName 3"
        },
        new()
        {
            Username = "Username 4",
            FirstName = "FirstName 4",
            LastName = "LastName 4"
        },
        new()
        {
            Username = "Username 5",
            FirstName = "FirstName 5",
            LastName = "LastName 5"
        }
    };

    public IActionResult Index()
    {
        var usersViewModel = new UsersViewModel {Users = StaticUsers};

        return View(usersViewModel);
    }

    [HttpPost]
    //public IActionResult CreateUser([FromQuery]int id, [FromForm]CreateUserViewModel createUserViewModel)
    public IActionResult CreateUser(CreateUserViewModel createUserViewModel)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Index");
        }

        StaticUsers.Add(new UserViewModel
        {
            Username = createUserViewModel.Username,
            FirstName = createUserViewModel.FirstName,
            LastName = createUserViewModel.LastName
        });

        return RedirectToAction("Index");
    }
}