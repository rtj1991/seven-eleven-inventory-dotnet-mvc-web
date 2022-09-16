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