using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TDLSite.Models;

namespace TDLSite.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Terms()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult LinksResources()
    {
        return View();
    }
    public IActionResult Contact()
    {
        return View();
    }
    public IActionResult Donate()
    {
        return View();
    }
    public IActionResult Submit()
    {
        return View();
    }
    public IActionResult Schopenhauer()
    {
        return View();
    }
    public IActionResult MythicalAfterimages()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
