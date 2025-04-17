using System.ComponentModel;
using System.Diagnostics;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using TDLSite.Models;

namespace TDLSite.Controllers;

public class AboutTheodorController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public AboutTheodorController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult BiographicalTimeline()
    {
        return View();
    }
    public List<Article> GetArticles()
    {
        List<Article> articles = new List<Article>();
        Article art1 = new Article
        {
            Title = "Mythical Afterimages",
            Author = "Herman Simissen",
            FileName = "/files/research-papers/mythical-afterimages-simissen.pdf"
        };
        Article art2 = new Article
        {
            Title = "Philosophy on the Internet",
            Author = "Dr. Rainer Marwedel",
            FileName = "/files/research-papers/philosophy-on-internet-marwedel.pdf"
        };
        Article art3 = new Article
        {
            Title = "Spazierstock-Schopenhauer",
            Author = "Theodor Lessing",
            FileName = "/files/research-papers/spazierstock.pdf"
        };
        Article art4 = new Article
        {
            Title = "Theodor Lessing - Between Jewish Self and Zionism",
            Author = "Lawrence Baron",
            FileName = "/files/research-papers/between-jewish-self.pdf"

        };
        Article art5 = new Article
        {
            Title = "Noise and Degeneration: Theodor Lessings Crusade for Quiet",
            Author = "Lawrence Baron",
            FileName = "/files/research-papers/noise-and-degeneration.pdf"
        };
        Article art6 = new Article
        {
            Title = "Discipleship and Dissent",
            Author = "Lawrence Baron",
            FileName = "/files/research-papers/discipleship-and-dissent.pdf"
        };
        articles.Add(art1);
        articles.Add(art2);
        articles.Add(art3);
        articles.Add(art4);
        articles.Add(art5);
        articles.Add(art6);
        return articles;
    }
    public IActionResult Papers(string toggleDiv)
    {
        ViewBag.isVisible = toggleDiv == "true"; // for toggling text views
        return View(GetArticles());
    }
    public IActionResult NewsClips()
    {
        ViewBag.isVisible = true; // for toggling text views
        var articles = new List<Article>{
            new Article {Title = "Arthur Heller Memorial", FileName = "/files/Arthur Heller Memorial0000.pdf"},
            new Article {Title = "Czech Announcement", FileName = "/files/Czech Announcement0000.pdf"},
            new Article {Title = "Hindenburg Fallout", FileName = "/files/Hindenburg Fallout0000.pdf"},
            new Article {Title = "Jewish Daily Bulletin", FileName = "/files/Jewish Daily Bulletin.pdf"},
            new Article {Title = "Prague Criminal Pros", FileName = "/files/Prague Criminal Pros Article.p10000.pdf"},
            new Article {Title = "Prague Funeral Article", FileName = "/files/Prague Funeral Article.pdf"},
            new Article {Title = "Schopenhauers Walking Stick to Masaryk", FileName = "/files/schopenhauer.pdf"},
            new Article {Title = "The Expensive Prof. Lessing", FileName = "/files/The Expensive PRof Lessing0000.pdf"},
            new Article {Title = "Daily Herald: Lessing Murder", FileName = "/files/Daily Herald.Lessing Murder.Color.pdf"},
            new Article {Title = "Daily Mail Article: Lessing Murder", FileName = "/files/Daily Mail Article.Murder0000.pdf"},
            new Article {Title = "Daily Telegraph: Lessing Murder", FileName = "/files/Daily Telegraph Article.Murder0000.pdf"},
            new Article {Title = "Danish Article: Lessing Murder", FileName = "/files/Danish Article.Murder0001.pdf"},
            new Article {Title = "Hebrew Article: Lessing Murder", FileName = "/files/Hebrew Article.Murder0000.pdf"},
            new Article {Title = "Morning Post: Lessing Murder", FileName = "/files/MorningPostMurder.pdf"},
            new Article {Title = "Jewish News: Lessing Murder", FileName = "/files/Murder Headline.Jewish News0000.pdf"},
            new Article {Title = "The Times: Lesing Murder", FileName = "/files/The Times Article.Murder0000.pdf"},
        };
        return View(articles);
    }
    public IActionResult PhotoGallery()
    {
        return View();
    }
    public IActionResult SampleWork()
    {
        ViewBag.isVisible = true; // for toggling text views
        var articles = new List<Article>{
            new Article {Title = "Haarmann - Story of a Werewolf", Author = "Translated by Mo Croasdale", FileName = "/files/sample-work/haarman.pdf"},
            new Article {Title = "Once and Never Again", Author = "Translated by Jefferson Chase", FileName = "/files/sample-work/never-again.pdf"},
            new Article {Title = "Hindenburg", Author = "Translated by George Phocas", FileName = "/files/sample-work/hindenberg.pdf"}
        };

        return View(articles);
    }
    public IActionResult ShortBiography()
    {
        Article art1 = new Article { Title = "Theodor Lessing", Author = "George Phocas", FileName = "/files/About-Theodor-Lessing.Final.pdf" };
        return View(art1);
    }
    public IActionResult AdaBiography()
    {
        Article art1 = new Article { Title = "An Undesired Survivor: Ada Lessing and the Volkshochschule Hannover", Author = "Herman Simissen", FileName = "/files/AdaLessingBio.pdf" };
        return View(art1);
    }
}
