using System;
using SevenEleven.Inventory.Mvc.Controllers;
using SevenEleven.Inventory.Mvc.Data;
using SevenEleven.Inventory.Mvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace SevenEleven.Inventory.Test;

[TestClass]
public class StockTest
{
    Mock<ILogger<StockController>> _logger;

    private ApplicationDbContext _context;

    public IConfigurationRoot Configuration { get; set; }

    TestConnection testConnection;
    TestUserClaim testUserClaim;
    public StockTest()
    {
        testConnection = new TestConnection();
        testUserClaim = new TestUserClaim();
        _logger = new Mock<ILogger<StockController>>();
    }


    [TestMethod]
    public void IndexTest()
    {
        //Arrange
        var stockController = new StockController(testConnection.getConnectionString(), _logger.Object);

        // Act
        var result = stockController.Index();

        // Assert
        Assert.IsNotNull(result);
        // Assert.IsNotNull(result.Model);
        // Assert.IsTrue(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Index");

    }

    [TestMethod]
    public void DetailsTest()
    {
        //Arrange
        var stockController = new StockController(testConnection.getConnectionString(), _logger.Object);


        // Act
        var result = stockController.Details(2);

        // Assert
        Assert.IsNotNull(result);

    }

    [TestMethod]
    public void CreateTest()
    {
        //Arrange
        var stockController = new StockController(testConnection.getConnectionString(), _logger.Object);


        // Act
        var result = stockController.Create();

        // Assert
        Assert.IsNotNull(result);
        // Assert.IsTrue(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Create");

    }

    [TestMethod]
    public void CreatePostTest()
    {
        //Arrange
        var stockController = new StockController(testConnection.getConnectionString(), _logger.Object);


        stockController.ControllerContext = new ControllerContext();
        stockController.ControllerContext.HttpContext = new DefaultHttpContext { User = testUserClaim.getUser() };
        // Act
        var stock = new Stock(2, "test description", 20.0, 1,true, DateTime.UtcNow, DateTime.UtcNow, 2, 2, "a28a0f64-fbef-4c08-ad20-6f4b8fd1f00a", "a28a0f64-fbef-4c08-ad20-6f4b8fd1f00a");
        var result = stockController.Create(stock);

        // Assert
        Assert.IsNotNull(result);
        // Assert.IsTrue(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Create");

    }

    [TestMethod]
    public void EditTest()
    {
        //Arrange
        var stockController = new StockController(testConnection.getConnectionString(), _logger.Object);


        // Act
        var result = stockController.Edit(1);

        // Assert
        Assert.IsNotNull(result);

    }

    [TestMethod]
    public void EditPostTest()
    {
        //Arrange
        var stockController = new StockController(testConnection.getConnectionString(), _logger.Object);


        stockController.ControllerContext = new ControllerContext();
        stockController.ControllerContext.HttpContext = new DefaultHttpContext { User = testUserClaim.getUser() };
        // Act
        var stock = new StockAdjustmentDao("test description", 20.0, 2, 2, 2);

        var result = stockController.Edit(1, stock);

        // Assert
        Assert.IsNotNull(result);
        // Assert.IsTrue(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Create");

    }

    [TestMethod]
    public void DeleteTest()
    {
        //Arrange
        var stockController = new StockController(testConnection.getConnectionString(), _logger.Object);


        // Act
        var result = stockController.Delete(2);

        // Assert
        Assert.IsNotNull(result);

    }
    [TestMethod]
    public void DeleteConfirmTest()
    {
        //Arrange
        var stockController = new StockController(testConnection.getConnectionString(), _logger.Object);


        // Act
        var result = stockController.DeleteConfirmed(2);

        // Assert
        Assert.IsNotNull(result);

    }
}