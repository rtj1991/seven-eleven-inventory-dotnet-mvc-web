using SevenEleven.Inventory.Mvc.Models;
using Microsoft.AspNetCore.Identity;

public static class ContextSeed
{
    public static async Task SeedRolesAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        //Seed Roles
        await roleManager.CreateAsync(new IdentityRole(SevenEleven.Inventory.Mvc.Enums.Roles.Admin.ToString()));
        await roleManager.CreateAsync(new IdentityRole(SevenEleven.Inventory.Mvc.Enums.Roles.Operator.ToString()));
        await roleManager.CreateAsync(new IdentityRole(SevenEleven.Inventory.Mvc.Enums.Roles.Manager.ToString()));
        await roleManager.CreateAsync(new IdentityRole(SevenEleven.Inventory.Mvc.Enums.Roles.ApiUser.ToString()));
    }

    public static async Task SeedSuperAdminAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        //Seed Default User
        var defaultUser = new User
        {
            UserName = "admin@gmail.com",
            Email = "admin@gmail.com",
            FirstName = "admin",
            LastName = "admin",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        };
        if (userManager.Users.All(u => u.Id != defaultUser.Id))
        {
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "C23456;c");
                await userManager.AddToRoleAsync(defaultUser, SevenEleven.Inventory.Mvc.Enums.Roles.Admin.ToString());
                await userManager.AddToRoleAsync(defaultUser, SevenEleven.Inventory.Mvc.Enums.Roles.Operator.ToString());
                await userManager.AddToRoleAsync(defaultUser, SevenEleven.Inventory.Mvc.Enums.Roles.Manager.ToString());
                await userManager.AddToRoleAsync(defaultUser, SevenEleven.Inventory.Mvc.Enums.Roles.ApiUser.ToString());
            }

        }
    }

    public static async Task SeedManagerAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        //Seed Default User
        var defaultUser = new User
        {
            UserName = "manager@gmail.com",
            Email = "manager@gmail.com",
            FirstName = "manager",
            LastName = "manager",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        };
        if (userManager.Users.All(u => u.Id != defaultUser.Id))
        {
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "A23456;a");
                await userManager.AddToRoleAsync(defaultUser, SevenEleven.Inventory.Mvc.Enums.Roles.Manager.ToString());
            }

        }
    }
    public static async Task SeedOperatorAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        //Seed Default User
        var defaultUser = new User
        {
            UserName = "operator@gmail.com",
            Email = "operator@gmail.com",
            FirstName = "operator",
            LastName = "operator",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        };
        if (userManager.Users.All(u => u.Id != defaultUser.Id))
        {
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "B23456;b");
                await userManager.AddToRoleAsync(defaultUser, SevenEleven.Inventory.Mvc.Enums.Roles.Operator.ToString());
            }

        }
    }
    public static async Task SeedApiUserAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        //Seed Default User
        var defaultUser = new User
        {
            UserName = "apiuser@gmail.com",
            Email = "apiuser@gmail.com",
            FirstName = "apiuser",
            LastName = "apiuser",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        };
        if (userManager.Users.All(u => u.Id != defaultUser.Id))
        {
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "D23456;d");
                await userManager.AddToRoleAsync(defaultUser, SevenEleven.Inventory.Mvc.Enums.Roles.ApiUser.ToString());
            }

        }
    }
}
