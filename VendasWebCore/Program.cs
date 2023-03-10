using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using VendasWebCore.Data;
using VendasWebCore.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("VendasWebCoreContext");
builder.Services.AddDbContext<VendasWebCoreContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<ServiceVendedor>();
builder.Services.AddScoped<ServiceDepartamento>();
builder.Services.AddScoped<ServiceVendas>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

Configure(app);

var enUS =  new CultureInfo("en-US");
var opcoesLocalizacao = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(enUS),
    SupportedCultures = new List<CultureInfo> { enUS },
    SupportedUICultures = new List<CultureInfo> { enUS },
};

app.UseRequestLocalization(opcoesLocalizacao);

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

void Configure(WebApplication host)
{
    using var scope = host.Services.CreateScope();
    var services = scope.ServiceProvider;

    try
    {
        var dbContext = services.GetRequiredService<VendasWebCoreContext>();
        SeedingService.Seed(dbContext);

    }
    catch (Exception ex)
    {
        //Log some error
        throw;
    }
}