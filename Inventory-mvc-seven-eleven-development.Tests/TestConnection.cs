using Inventory_mvc_seven_eleven.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Inventory_mvc_seven_eleven_development.Tests;
public class TestConnection
{
    private ApplicationDbContext? _context;
    public IConfigurationRoot? Configuration { get; set; }
    public ApplicationDbContext getConnectionString()
    {

        var builder = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        Configuration = builder.Build();

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        _context= new ApplicationDbContext(optionsBuilder.Options);

        return _context;
    }

}
