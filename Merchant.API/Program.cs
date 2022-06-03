using Merchant.API;
using Merchant.Core;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(c => c.AddDefaultPolicy(f => f.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000").AllowCredentials()));
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("Mssql");
builder.Services.AddDbContext<MerchantDbContext>(o => o.UseSqlServer(connectionString), contextLifetime: ServiceLifetime.Scoped);
builder.Services.AddSignalR();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        options.SlidingExpiration = true;
        options.Cookie.SameSite = SameSiteMode.None;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.AccessDeniedPath = "/";
        options.Cookie.HttpOnly = true;
    });
builder.Services.AddHostedService<TransactionsHostedService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (true)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
var cookiePolicyOptions = new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.None,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
};
app.UseCookiePolicy(cookiePolicyOptions);
app.UseCors();
app.MapControllers();

app.MapHub<MerchantHub>("/signalr");

app.Run();
