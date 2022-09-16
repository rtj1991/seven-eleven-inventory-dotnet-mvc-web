using Inventory_mvc_seven_eleven.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Moq;

namespace Inventory_mvc_seven_eleven_development.Tests;
public class FakeSignInManager:SignInManager<User>
{
    public FakeSignInManager()
        : base(
              new Mock<FakeUserManager>().Object,
              new HttpContextAccessor(),
              new Mock<IUserClaimsPrincipalFactory<User>>().Object,
              new Mock<Microsoft.Extensions.Options.IOptions<IdentityOptions>>().Object,
              new Mock<ILogger<SignInManager<User>>>().Object,
              new Mock<Microsoft.AspNetCore.Authentication.IAuthenticationSchemeProvider>().Object,
              new Mock<Microsoft.AspNetCore.Identity.IUserConfirmation<User>>().Object
              )
    { }

}
