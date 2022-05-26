using Merchant.Core;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(config =>
    {
        config.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        config.DefaultChallengeScheme = "oidc";

    })
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddOpenIdConnect("oidc", config =>
    {
        config.ClientId = "web_admin";
        config.ClientSecret = "admin_secret_key";
        config.SaveTokens = true;
        config.Authority = "http://localhost:2000";
        config.ResponseType = "code";
        config.RequireHttpsMetadata = false;
        config.Scope.Add("AdminPanel");
    });
builder.Services.AddDbContext<MerchantDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("Mssql")), ServiceLifetime.Transient);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
