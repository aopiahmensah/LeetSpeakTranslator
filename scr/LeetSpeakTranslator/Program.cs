using LST.Model.Model.IRepository;
using LST.Repository.EF.All;
using LST.Repository.EF.All.Repository;
using LST.Service.Implementations;
using LST.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) =>
loggerConfig.ReadFrom.Configuration(context.Configuration));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<LSTContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("LSTContext")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => { options.AccessDeniedPath = "/Error/AuthorizeError"; options.LoginPath = "/Account/Login/"; options.LogoutPath = "/Account/Logout"; });
builder.Services.AddSession(options => { options.IdleTimeout = TimeSpan.FromMinutes(20); options.Cookie.HttpOnly = true; });
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("NormalUser", policy => policy.RequireRole("NormalUser"));
});

//register custom services
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IApiRequestRepository, ApiRequestRepository>();
builder.Services.AddScoped<IApiResponseRepository, ApiResponseRepository>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IWidgetService, WidgetService>();

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
app.UseAuthentication();
app.UseSession();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
