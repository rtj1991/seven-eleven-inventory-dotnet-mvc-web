using Inventory_mvc_seven_eleven.Controllers;
using Inventory_mvc_seven_eleven.Dao;
using Inventory_mvc_seven_eleven.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Inventory_mvc_seven_eleven_development.Tests;
[TestClass]
public class AuthenticationTest
{
    Mock<ILogger<HomeController>> _logger;
    private ApplicationDbContext _context;
    public IConfigurationRoot Configuration { get; set; }
    TestConnection testConnection;
    TestUserClaim testUserClaim;
    public AuthenticationTest()
    {
        testConnection = new TestConnection();
        testUserClaim = new TestUserClaim();
        _logger = new Mock<ILogger<HomeController>>();

    }


    [TestMethod]
    public void IndexTest()
    {
        //Arrange
        var signInManager = new Mock<FakeSignInManager>();
        var homeController = new HomeController(_logger.Object, testConnection.getConnectionString(), signInManager.Object);

        homeController.ControllerContext = new ControllerContext();
        homeController.ControllerContext.HttpContext = new DefaultHttpContext { User = testUserClaim.getUser() };

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
        var homeController = new HomeController(_logger.Object, testConnection.getConnectionString(), signInManager.Object);
        var user = new UserCread("admin@gmail.com", "C23456;c");

        // Act
        var result = homeController.Authenticate(user);

        // Assert
        Assert.IsNotNull(result);

    }

}