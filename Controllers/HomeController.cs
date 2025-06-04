using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AgentDemo.Models;

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
                Title = "AgentDemo Secures $10M in Series A Funding",
                Summary = "Our company has secured significant funding to accelerate growth and product development.",
                ImageUrl = "/images/news-funding.jpg",
                LinkUrl = "#funding-news",
                PublishedDate = DateTime.Now.AddDays(-5)
            },
            new NewsArticleViewModel
            {
                Title = "New Partnership Announced with Microsoft",
                Summary = "We're excited to announce our strategic partnership with Microsoft to enhance our cloud offerings.",
                ImageUrl = "/images/news-partnership.jpg",
                LinkUrl = "#partnership-news",
                PublishedDate = DateTime.Now.AddDays(-12)
            },
            new NewsArticleViewModel
            {
                Title = "AgentDemo Wins Innovation Award 2023",
                Summary = "Our team's hard work has been recognized with the prestigious Innovation Award for our AI solutions.",
                ImageUrl = "/images/news-award.jpg",
                LinkUrl = "#award-news",
                PublishedDate = DateTime.Now.AddDays(-20)
            },
            new NewsArticleViewModel
            {
                Title = "AgentDemo Expands to European Market",
                Summary = "We're thrilled to announce our expansion into the European market with new offices in London and Berlin.",
                ImageUrl = "/images/news-expansion.jpg",
                LinkUrl = "#expansion-news",
                PublishedDate = DateTime.Now.AddDays(-30)
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