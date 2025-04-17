using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
public class ContactModel
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string? Email { get; set; }
    public string? Subject { get; set; }
    public string? Name { get; set; }
    [Required(ErrorMessage = "Message cannot be empty")]
    [MinLength(10, ErrorMessage = "Message must be at least 10 characters long")]
    public string? Body { get; set; }
}

