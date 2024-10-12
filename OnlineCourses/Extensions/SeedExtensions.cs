using Data.Entities;
using System.Reflection;
using Microsoft.AspNetCore.Identity;

namespace OnlineCourses.Extensions;

public static class Roles
{
    public const string ADMIN = "admin";
    public const string USER = "user";
}

public static class Seeder
{
    public static async Task SeedRoles(this IServiceProvider app)
    {
        var roleManager = app.GetRequiredService<RoleManager<IdentityRole>>();

        var roles = typeof(Roles).GetFields(
            BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Select(x => (string)x.GetValue(null)!);

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    public static async Task SeedAdmin(this IServiceProvider app)
    {
        var userManager = app.GetRequiredService<UserManager<User>>();

        const string USERNAME = "admin@ukr.net";
        const string PASSWORD = "Qwerty-123";

        var existingUser = await userManager.FindByNameAsync(USERNAME);

        if (existingUser is null)
        {
            var user = new User
            {
                UserName = USERNAME,
                Email = USERNAME
            };
            var result = await userManager.CreateAsync(user, PASSWORD);

            if (result.Succeeded)
                await userManager.AddToRoleAsync(user, Roles.ADMIN);
        }
    }
}
