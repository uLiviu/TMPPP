using Microsoft.EntityFrameworkCore;
using Store.Services;
using Microsoft.AspNetCore.Identity;
using Store.Models;
using Store.Pages.Admin.Products;
using Store.Pages.Admin.Products.Builder;
using Store.Pages.Admin.Products.Prototype;
using Microsoft.Extensions.DependencyInjection;
using Store.Pages.Admin.Reviews.Proxy;
using Store.Pages.Admin.Products.Observer;
using Store.Pages.Admin.Orders.Facade;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<IProductFactory, ProductFactory>();

builder.Services.AddScoped<IProductBuilder, ProductBuilder>();

builder.Services.AddScoped<ProductPrototype>();

builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.Decorate<IReviewService, ReviewServiceProxy>();

builder.Services.AddScoped<IProductObserver, UserNotificationService>();

builder.Services.AddScoped<OrderFacade>();

static async Task<int> GetNotificationCount(IServiceProvider serviceProvider)
{
    var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
    var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
    var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

    var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
    if (user == null)
    {
        return 0;
    }

    return await context.Notifications.CountAsync(n => n.UserId == user.Id);
}

builder.Services.AddScoped<Func<Task<int>>>(serviceProvider => () => GetNotificationCount(serviceProvider));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
