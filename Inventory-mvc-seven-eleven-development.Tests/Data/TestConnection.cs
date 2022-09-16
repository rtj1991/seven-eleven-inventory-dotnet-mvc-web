using Inventory_mvc_seven_eleven.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Inventory_mvc_seven_eleven_development.Tests;
public class TestConnection
{
    public ApplicationDbContext? _context;
    public IConfigurationRoot? Configuration { get; set; }
    public virtual ApplicationDbContext getConnectionString()
    {

        var builder = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        Configuration = builder.Build();

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        _context = new ApplicationDbContext(optionsBuilder.Options);

        return _context;
    }

}
