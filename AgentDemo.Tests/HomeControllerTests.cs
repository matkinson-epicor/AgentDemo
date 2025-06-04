using AgentDemo.Controllers;
using AgentDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace AgentDemo.Tests;

public class HomeControllerTests
{
    private readonly Mock<ILogger<HomeController>> _loggerMock;
    private readonly HomeController _controller;

    public HomeControllerTests()
    {
        _loggerMock = new Mock<ILogger<HomeController>>();
        _controller = new HomeController(_loggerMock.Object);
    }

    [Fact]
    public void Index_ReturnsViewResult()
    {
        // Act
        var result = _controller.Index();

        // Assert
        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public void Privacy_ReturnsViewResult()
    {
        // Act
        var result = _controller.Privacy();

        // Assert
        Assert.IsType<ViewResult>(result);
    }
    
    [Fact]
    public void Contact_Get_ReturnsViewResult()
    {
        // Act
        var result = _controller.Contact();

        // Assert
        Assert.IsType<ViewResult>(result);
    }
    
    [Fact]
    public void Contact_Post_WithValidModel_RedirectsToContactAction()
    {
        // Arrange
        var model = new ContactViewModel
        {
            Name = "Test User",
            Email = "test@example.com",
            Subject = "Test Subject",
            Message = "Test Message"
        };

        // Act
        var result = _controller.Contact(model);

        // Assert
        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Contact", redirectResult.ActionName);
        Assert.NotNull(_controller.TempData["SuccessMessage"]);
    }
    
    [Fact]
    public void Contact_Post_WithInvalidModel_ReturnsViewWithModel()
    {
        // Arrange
        var model = new ContactViewModel(); // Empty model will be invalid
        _controller.ModelState.AddModelError("Name", "Name is required");

        // Act
        var result = _controller.Contact(model);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Equal(model, viewResult.Model);
    }
}