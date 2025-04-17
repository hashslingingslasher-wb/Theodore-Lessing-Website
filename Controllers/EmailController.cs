using Microsoft.AspNetCore.Mvc;
using TDLSite.Models;
using System.Net;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Services;
public class EmailController : Controller
{
    private readonly IEmailService _emailService;


    public EmailController(IEmailService emailService)
    {
        _emailService = emailService;
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
    public IActionResult Confirmation()
    {
        ViewBag.Message = TempData["Message"]?.ToString();
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> SendEmail(ContactModel model)
    {

        if (ModelState.IsValid)
        {
            var success = await _emailService.SendEmailAsync(model.Email!, model.Name!, model.Subject!, model.Body!);

            if (success)
            {
                TempData["Message"] = "Email sent successfully!";
                return RedirectToAction("Confirmation");
            }
            else
            {
                TempData["Message"] = "There was an error sending the email. Please try again.";
                return RedirectToAction("Confirmation");
            }
        }
        else
        {
            TempData["Message"] = "Please fill out the form correctly.";
            return RedirectToAction("Confirmation");
        }
    }
}