using Inventory_mvc_seven_eleven.Controllers;
using Inventory_mvc_seven_eleven.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Inventory_mvc_seven_eleven_development.Tests;
[TestClass]
public class ItemTest
{
    Mock<ILogger<ItemController>> _logger;

    private ApplicationDbContext _context;

    public IConfigurationRoot Configuration { get; set; }

    TestConnection testConnection;
    public ItemTest()
    {
        _logger = new Mock<ILogger<ItemController>>();
    }


    [TestMethod]
    public void IndexTest()
    {
        //Arrange
        var itemController = new ItemController(getConnectionString(), _logger.Object);

        // Act
        var result = itemController.Index() as ViewResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.Model);
        Assert.IsTrue(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Index");

    }

    public ApplicationDbContext getConnectionString()
    {

        var builder = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        Configuration = builder.Build();

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        _context = new ApplicationDbContext(optionsBuilder.Options);

        return _context;
    }

}