using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestMVCApplication.BusinessLogic.Services;
using TestMVCApplication.Web.Models;

namespace TestMVCApplication.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IService _service;

    public HomeController(IService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        _service.Increment();
        return View();
    }

    public IActionResult Privacy()
    {
        var a = _service.ReturnValue();
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}