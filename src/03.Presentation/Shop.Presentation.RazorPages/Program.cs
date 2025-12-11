using Microsoft.EntityFrameworkCore;
using Serilog;
using Shop.Domain.Core.CategoryAgg.Contracts;
using Shop.Domain.Core.FileAgg.Contracts;
using Shop.Domain.Core.OrderAgg.Contracts;
using Shop.Domain.Core.ProductAgg.Contracts;
using Shop.Domain.Core.UserAgg.Contracts;
using Shop.Domain.Service.AppService.CategoryAgg;
using Shop.Domain.Service.AppService.OrderAgg;
using Shop.Domain.Service.AppService.ProductAgg;
using Shop.Domain.Service.AppService.UserAgg;
using Shop.Domain.Service.DomainService.CategoryAgg;
using Shop.Domain.Service.DomainService.FileAgg;
using Shop.Domain.Service.DomainService.OrderAgg;
using Shop.Domain.Service.DomainService.ProductAgg;
using Shop.Domain.Service.DomainService.UserAgg;
using Shop.Infrastructure.EFCore.Persistence;
using Shop.Infrastructure.EFCore.Repositories.CategoryAgg;
using Shop.Infrastructure.EFCore.Repositories.OrderAgg;
using Shop.Infrastructure.EFCore.Repositories.ProductAgg;
using Shop.Infrastructure.EFCore.Repositories.UserAgg;
using Shop.Presentation.RazorPages.Middlewares;
using Shop.Presentation.RazorPages.Services.OnlineCartItem;

var builder = WebApplication.CreateBuilder(args);

#region Logging

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()

    //console log
    .WriteTo.Console()
    // Info ? Seq
    .WriteTo.Logger(lc => lc
        .WriteTo.Seq("http://localhost:5341"))

    .CreateBootstrapLogger();

builder.Host.UseSerilog();

#endregion Logging

// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

#region RegisterServices

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Shop-hw22;Trusted_Connection=True;"));

builder.Services.AddScoped<IProductAppService, ProductAppService>();
builder.Services.AddScoped<IProductDomainService, ProductDomainService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<IUserDomainService, UserDomainService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IOrderAppService, OrderAppService>();
builder.Services.AddScoped<IOrderDomainService, OrderDomainService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();
builder.Services.AddScoped<ICategoryDomainService, CategoryDomainService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IFileService, FileService>();

builder.Services.AddScoped<IOnlineCartItemService, OnlineCartItemService>();

#endregion RegisterServices

var app = builder.Build();

app.UseMiddleware<LoggingMiddleware>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();