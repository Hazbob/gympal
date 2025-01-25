using GymPal.config;
using GymPal.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);
var domain = $"https://{builder.Configuration["Auth0:Domain"]}/";
builder.Services.Configure<Auth0Secrets>(
    builder.Configuration.GetSection("Auth0"));

//Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    var audience =
                   builder.Configuration["Auth0:Audience"];

    options.Authority =
          $"https://{builder.Configuration["Auth0:Domain"]}/";
    options.Audience = audience;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = true,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddHttpClient();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        var clientOriginUrl = builder.Configuration["Auth0:ClientOriginUrl"];
        policy.WithOrigins(
            clientOriginUrl)
            .WithHeaders(new string[] {
                HeaderNames.ContentType,
                HeaderNames.Authorization,
            })
            .WithMethods("GET")
            .SetPreflightMaxAge(TimeSpan.FromSeconds(86400));
    });
});
builder.Services.AddControllers();
#region Deps
builder.Services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
builder.Services.AddScoped<JwtHelper>();
#endregion

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapControllers();

app.Run();
