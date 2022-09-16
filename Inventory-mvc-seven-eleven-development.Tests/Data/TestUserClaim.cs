using System.Security.Claims;

namespace Inventory_mvc_seven_eleven_development.Tests;
public class TestUserClaim
{

    public ClaimsPrincipal getUser()
    {
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] {
                                        new Claim(ClaimTypes.NameIdentifier, "admin@gmail.com"),
                                        new Claim(ClaimTypes.Name, "admin@gmail.com")
                                        // other required and custom claims
                                   }, "TestAuthentication"));
        return user;

    }

}
