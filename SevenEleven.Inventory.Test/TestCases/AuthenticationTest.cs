using SevenEleven.Inventory.Mvc.Controllers;
using SevenEleven.Inventory.Mvc.Dao;
using SevenEleven.Inventory.Mvc.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace SevenEleven.Inventory.Test;

[TestClass]
public class AuthenticationTest
{
    Mock<ILogger<HomeController>> _logger;
    private ApplicationDbContext _context;
    private TestConnection _testConnection;
    private TestUserClaim _testUserClaim;
    public AuthenticationTest()
    {
        _testConnection = new TestConnection();
        _testUserClaim = new TestUserClaim();
        _logger = new Mock<ILogger<HomeController>>();
    }

    [TestMethod]
    public void IndexTest()
    {
        //Arrange
        var signInManager = new Mock<FakeSignInManager>();
        var homeController = new HomeController(_logger.Object, _testConnection.getConnectionString(), signInManager.Object);

        homeController.ControllerContext = new ControllerContext();
        homeController.ControllerContext.HttpContext = new DefaultHttpContext { User = _testUserClaim.getUser() };

        // Act
        var result = homeController.Index() as RedirectResult;

        // Assert
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void AuthenticateTest()
    {
        //Arrange
        var signInManager = new Mock<FakeSignInManager>();
        var homeController = new HomeController(_logger.Object, _testConnection.getConnectionString(), signInManager.Object);
        var user = new UserCread("admin@gmail.com", "C23456;c");

        // Act
        var result = homeController.Authenticate(user);

        // Assert
        Assert.IsNotNull(result);
    }
}