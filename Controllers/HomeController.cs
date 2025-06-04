using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AgentDemo.Models;
using System.Collections.Generic;
using System;

namespace AgentDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var newsArticles = GetNewsArticles();
        return View(newsArticles);
    }
    
    private List<NewsArticleViewModel> GetNewsArticles()
    {
        // In a real application, this data would come from a database or API
        return new List<NewsArticleViewModel>
        {
            new NewsArticleViewModel
            {
                Title = "Company Launches Revolutionary New Product",
                Description = "Our latest innovation is changing the industry with breakthrough technology and exceptional performance.",
                ImageUrl = "/images/logo.svg",
                LinkUrl = "#product-launch",
                PublicationDate = DateTime.Now.AddDays(-5)
            },
            new NewsArticleViewModel
            {
                Title = "AgentDemo Wins Industry Excellence Award",
                Description = "Our commitment to quality and innovation has been recognized with the prestigious Industry Excellence Award.",
                ImageUrl = "/images/logo.svg",
                LinkUrl = "#award-announcement",
                PublicationDate = DateTime.Now.AddDays(-14)
            },
            new NewsArticleViewModel
            {
                Title = "New Partnership Announcement",
                Description = "We're excited to announce our strategic partnership with a leading technology provider to enhance our service offerings.",
                ImageUrl = "/images/logo.svg",
                LinkUrl = "#partnership",
                PublicationDate = DateTime.Now.AddDays(-30)
            }
        };
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Contact(ContactViewModel model)
    {
        if (ModelState.IsValid)
        {
            // In a real application, you would process the feedback form here
            // For example, send an email or save to a database
            
            // Add a success message
            TempData["SuccessMessage"] = "Thank you for your feedback! We will get back to you soon.";
            
            // Redirect to prevent form resubmission
            return RedirectToAction(nameof(Contact));
        }
        
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}