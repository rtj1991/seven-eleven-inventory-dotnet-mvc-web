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
public class StockAdjustmentTest
{
    Mock<ILogger<StockAdjustmentController>> _logger;

    private ApplicationDbContext _context;

    public IConfigurationRoot Configuration { get; set; }

    TestConnection testConnection;
    public StockAdjustmentTest()
    {
        testConnection = new TestConnection();
        _logger = new Mock<ILogger<StockAdjustmentController>>();
    }


    [TestMethod]
    public void IndexTest()
    {
        //Arrange
        var stockController = new StockAdjustmentController(testConnection.getConnectionString());

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
        var stockController = new StockAdjustmentController(testConnection.getConnectionString());


        // Act
        var result = stockController.Details(2);

        // Assert
        Assert.IsNotNull(result);

    }

}