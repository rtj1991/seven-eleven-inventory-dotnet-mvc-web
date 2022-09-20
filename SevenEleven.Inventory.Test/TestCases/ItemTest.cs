using System;
using SevenEleven.Inventory.Mvc.Controllers;
using SevenEleven.Inventory.Mvc.Data;
using SevenEleven.Inventory.Mvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace SevenEleven.Inventory.Test;

[TestClass]
public class ItemTest
{
    private Mock<ILogger<ItemController>> _logger;
    private ApplicationDbContext _context;
    private TestConnection _testConnection;
    private TestUserClaim _testUserClaim;
    public ItemTest()
    {
        _testConnection = new TestConnection();
        _testUserClaim = new TestUserClaim();
        _logger = new Mock<ILogger<ItemController>>();
    }

    [TestMethod]
    public void IndexTest()
    {
        //Arrange
        var itemController = new ItemController(_testConnection.getConnectionString(), _logger.Object);

        // Act
        var result = itemController.Index() as ViewResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.Model);
        Assert.IsTrue(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Index");
    }

    [TestMethod]
    public void DetailsTest()
    {
        //Arrange
        var itemController = new ItemController(_testConnection.getConnectionString(), _logger.Object);

        // Act
        var result = itemController.Details(2);

        // Assert
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void CreateTest()
    {
        //Arrange
        var itemController = new ItemController(_testConnection.getConnectionString(), _logger.Object);

        // Act
        var result = itemController.Create() as ViewResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Create");
    }

    [TestMethod]
    public void CreatePostTest()
    {
        //Arrange
        var itemController = new ItemController(_testConnection.getConnectionString(), _logger.Object);

        itemController.ControllerContext = new ControllerContext();
        itemController.ControllerContext.HttpContext = new DefaultHttpContext { User = _testUserClaim.getUser() };
        // Act
        var item = new Item(5, "test item", "test description", 20.0, 1, DateTime.UtcNow, "a28a0f64-fbef-4c08-ad20-6f4b8fd1f00a");
        var result = itemController.Create(item);

        // Assert
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void EditTest()
    {
        //Arrange
        var itemController = new ItemController(_testConnection.getConnectionString(), _logger.Object);

        // Act
        var result = itemController.Edit(2);

        // Assert
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void EditPostTest()
    {
        //Arrange
        var itemController = new ItemController(_testConnection.getConnectionString(), _logger.Object);

        // Act
        var item = new Item(2, "test item", "test description", 20.0, 1, DateTime.UtcNow, "a28a0f64-fbef-4c08-ad20-6f4b8fd1f00a");
        var result = itemController.Edit(2, item);

        // Assert
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void DeleteTest()
    {
        //Arrange
        var itemController = new ItemController(_testConnection.getConnectionString(), _logger.Object);

        // Act
        var result = itemController.Delete(2);

        // Assert
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void DeleteConfirmTest()
    {
        //Arrange
        var itemController = new ItemController(_testConnection.getConnectionString(), _logger.Object);

        // Act
        var result = itemController.DeleteConfirmed(2);

        // Assert
        Assert.IsNotNull(result);
    }
}