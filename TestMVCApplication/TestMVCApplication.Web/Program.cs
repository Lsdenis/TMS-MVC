using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TestMVCApplication.BusinessLogic.Services;
using TestMVCApplication.DAL;

var builder = WebApplication.CreateBuilder(args);

const string databaseSettingName = "name=ConnectionStrings:SQLConnection";

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<object>(provider => 5);
builder.Services.AddScoped<IService, Service>();
// builder.Services.AddSingleton<object>(provider => 5);
// builder.Services.AddSingleton<IService, Service>();
builder.Services.AddDbContext<UniversitiesDBContext>(optionsBuilder =>
    optionsBuilder.UseSqlServer(databaseSettingName));
builder.Services.AddControllers(options => { options.SuppressAsyncSuffixInActionNames = false; });
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    //options.AccessDeniedPath = new PathString("/Authentication");
    options.LoginPath = new PathString("/Authentication");
    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    options.SlidingExpiration = true;
    options.AccessDeniedPath = "/Authentication/Forbidden/";
});

// singleton
// scoped
// transient

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
    "default",
    "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();