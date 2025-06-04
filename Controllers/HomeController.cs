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
        return View();
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