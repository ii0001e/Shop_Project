using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Shop.ApplicationServices.Services;
using Shop.Core.Domain;
using Shop.Core.ServiceInterface;
using Shop.Data;
using Shop.Security;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<ShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//add dependence interface and service class
builder.Services.AddScoped<ISpaceshipServices, SpaceshipServices>();
//add dependence interface and service class
builder.Services.AddScoped<IFileServices, FileServices>();

//add dependence interface and service class
builder.Services.AddScoped<IRealEstateServices, RealEstatesServices>();
//add dependence interface and service class
builder.Services.AddScoped<IKindergartenServices, KinderGartenServices>();

builder.Services.AddScoped<IWheatherForecastServices, WheatherForecastServices>();

builder.Services.AddScoped<ICackNorisServices, ChackNorisServices>();

builder.Services.AddScoped<ICoctailServices, CoctailServices>();

builder.Services.AddScoped<IAcuWeatherServices, AcuWeatherServices>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
        options.Password.RequiredLength = 3;


        options.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
        options.Lockout.MaxFailedAccessAttempts = 2;
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

    })
    .AddEntityFrameworkStores<ShopContext>()
    .AddDefaultTokenProviders()
    .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>("CustomEmailConfirmation")
    .AddDefaultUI();


builder.Services.Configure<DataProtectionTokenProviderOptions>(o =>
            o.TokenLifespan = TimeSpan.FromHours(5));
builder.Services.Configure<CustomEmailConfirmationTokenProviderOptions>(o =>
            o.TokenLifespan = TimeSpan.FromDays(3));








var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
//for display pictures in details
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider

    (Path.Combine(builder.Environment.ContentRootPath, "multipleFileUpload")),
    RequestPath = "/multipleFileUpload"



});

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


app.UseStaticFiles();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "realstates",
//        pattern: "Realstates/{action=Index}/{id?}",
//        defaults: new { controller = "Realstates" });
//    // Other route configurations...
//});
