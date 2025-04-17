using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TDLSite.Models;
namespace TDLSite.Controllers;
public class AboutFoundationController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public AboutFoundationController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Events()
    {
        return View();
    }
    public IActionResult Grants()
    {
        return View();
    }
    public IActionResult People()
    {
        return View();
    }
    public IActionResult Projects()
    {
        ViewBag.isVisible = true; // for toggling text views
        ViewBag.section1 = @"
            <div class='pdf-container'>
            <iframe src='\files\sample-work\never-again.pdf'width='100%' height='500'></iframe>
            </div>";
        ViewBag.section2 = @"
            <div class='pdf-container'>
            <iframe src='\files\sample-work\hindenberg.pdf'width='100%' height='500'></iframe>
            </div>";
        ViewBag.section3 = @"
            <div class='pdf-container'>
            <iframe src='\files\sample-work\haarman.pdf'width='100%' height='500'></iframe>
            </div>";
        return View();
    }
    public IActionResult AboutUs()
    {
        return View();
    }
}
