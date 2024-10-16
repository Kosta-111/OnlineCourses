using Data;
using Data.Entities;
using Core.Services;
using Core.MapperProfiles;
using OnlineCourses.Services;
using OnlineCourses.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("LocalDb")!;

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<OnlineCoursesDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<User, IdentityRole>(options => 
    options.SignIn.RequireConfirmedAccount = false)
    .AddDefaultTokenProviders()
    .AddDefaultUI()
    .AddEntityFrameworkStores<OnlineCoursesDbContext>();

builder.Services.AddAutoMapper(typeof(AppProfile));
builder.Services.AddScoped<IFilesService, FilesService>();
builder.Services.AddScoped<IWishListService, WishListService>();
builder.Services.AddScoped<ICoursesService, CoursesService>();
builder.Services.AddScoped<IOrdersService, OrdersService>();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddHttpContextAccessor();

// -------- sessions
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddRazorPages();

var app = builder.Build();

// ---------- seed roles and admins
using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.SeedRoles().Wait();
    scope.ServiceProvider.SeedAdmin().Wait();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
