using System;
using Inventory_mvc_seven_eleven.Controllers;
using Inventory_mvc_seven_eleven.Data;
using Inventory_mvc_seven_eleven.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Inventory_mvc_seven_eleven_development.Tests;
[TestClass]
public class LocationTest
{
    Mock<ILogger<LocationController>> _logger;

    private ApplicationDbContext _context;

    public IConfigurationRoot Configuration { get; set; }

    TestConnection testConnection;
    TestUserClaim testUserClaim;
    public LocationTest()
    {
        testConnection = new TestConnection();
        testUserClaim = new TestUserClaim();
        _logger = new Mock<ILogger<LocationController>>();
    }


    [TestMethod]
    public void IndexTest()
    {
        //Arrange
        var locationController = new LocationController(testConnection.getConnectionString(), _logger.Object);

        // Act
        var result = locationController.Index() as ViewResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.Model);
        Assert.IsTrue(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Index");

    }

    [TestMethod]
    public void DetailsTest()
    {
        //Arrange
        var locationController = new LocationController(testConnection.getConnectionString(), _logger.Object);

        // Act
        var result = locationController.Details(2);

        // Assert
        Assert.IsNotNull(result);

    }

    [TestMethod]
    public void CreateTest()
    {
        //Arrange
        var locationController = new LocationController(testConnection.getConnectionString(), _logger.Object);

        // Act
        var result = locationController.Create() as ViewResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Create");

    }

    [TestMethod]
    public void CreatePostTest()
    {
        //Arrange
        var locationController = new LocationController(testConnection.getConnectionString(), _logger.Object);

        locationController.ControllerContext = new ControllerContext();
        locationController.ControllerContext.HttpContext = new DefaultHttpContext { User = testUserClaim.getUser() };
        // Act
        var location = new Location(2, "test location", "test description", 1, DateTime.UtcNow, "a28a0f64-fbef-4c08-ad20-6f4b8fd1f00a");
        var result = locationController.Create(location);

        // Assert
        Assert.IsNotNull(result);
        // Assert.IsTrue(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Create");

    }

    [TestMethod]
    public void EditTest()
    {
        //Arrange
        var locationController = new LocationController(testConnection.getConnectionString(), _logger.Object);

        // Act
        var result = locationController.Edit(2);

        // Assert
        Assert.IsNotNull(result);

    }

    [TestMethod]
    public void EditPostTest()
    {
        //Arrange
        var locationController = new LocationController(testConnection.getConnectionString(), _logger.Object);

        // itemController.ControllerContext = new ControllerContext();
        // itemController.ControllerContext.HttpContext = new DefaultHttpContext { User = testUserClaim.getUser() };
        // Act
        var location = new Location(2, "test location", "test description", 1, DateTime.UtcNow, "a28a0f64-fbef-4c08-ad20-6f4b8fd1f00a");

        var result = locationController.Edit(2, location);

        // Assert
        Assert.IsNotNull(result);
        // Assert.IsTrue(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Create");

    }

    [TestMethod]
    public void DeleteTest()
    {
        //Arrange
        var locationController = new LocationController(testConnection.getConnectionString(), _logger.Object);

        // Act
        var result = locationController.Delete(2);

        // Assert
        Assert.IsNotNull(result);

    }
    [TestMethod]
    public void DeleteConfirmTest()
    {
        //Arrange
        var locationController = new LocationController(testConnection.getConnectionString(), _logger.Object);

        // Act
        var result = locationController.DeleteConfirmed(2);

        // Assert
        Assert.IsNotNull(result);

    }
}