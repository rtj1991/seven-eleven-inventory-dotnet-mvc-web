using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Inventory_mvc_seven_eleven.Dao;
using Inventory_mvc_seven_eleven.Data;
using Inventory_mvc_seven_eleven.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Inventory_mvc_seven_eleven.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly SignInManager<User> _signInManager;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, SignInManager<User> signInManager)
    {
        _logger = logger;
        _context = context;
        _signInManager = signInManager;
    }

    public IActionResult Index()
    {
        if (_signInManager.IsSignedIn(User))
        {
            return View();
        }
        else
        {
            return Redirect("/");
        }
    }

    [HttpPost("Authenticate")]
    public async Task<IActionResult> Authenticate([FromBody] UserCread userCread)
    {
        if (ModelState.IsValid)
        {
            User user = await this._context.Users.FirstOrDefaultAsync(user => user.Email == userCread.Username);
            var signingResult = await _signInManager.CheckPasswordSignInAsync(user, userCread.Password, false);
            if (signingResult.Succeeded)
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSetting.Key));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub,userCread.Username),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName,userCread.Username)

                };

                var token = new JwtSecurityToken(
                    JwtSetting.Issuer,
                    JwtSetting.Audience,
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(30),
                    signingCredentials: creds
                );

                var result = new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                };
                return Created("", result);
            }
            else
            {
                return BadRequest();
            }

        }
        return Ok();
    }

}
