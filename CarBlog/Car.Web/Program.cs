using Car.Web.DataContext;
using Microsoft.EntityFrameworkCore;
using Car.Web.Inatface;
using Car.Web.Repository;
using Microsoft.AspNetCore.Identity;
using Car.Web.Data;
using Car.Web.Models;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<CarDataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("CarDataContext")));



builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<CarUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<CarDataContext>();


builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});


builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});

builder.Services.AddControllersWithViews();


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICarBand, CarBandRepository>();
builder.Services.AddScoped<ICarModel, CarModelRepository>();
builder.Services.AddScoped<ICarModelClass, CarModelClassRepository>();
builder.Services.AddScoped<IFontCarBlogSearchIndex, FontCarBlogSearchIndexRepository>();



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

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=FondCarBlog}/{action=SearchIndex}/{id?}");

app.MapRazorPages();


app.Run();
