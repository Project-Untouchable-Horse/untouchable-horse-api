using Untouchable.Horse.Api.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

string authority = builder.Configuration["Auth0:Authority"] ??
throw new ArgumentNullException("Auth0:Authority");

string audience = builder.Configuration["Auth0:Audience"] ??
throw new ArgumentNullException("Auth0:Audience");


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAuthentication(options => 
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options => 
{
    options.Authority = authority;
    options.Audience = audience;
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("delete:catalog", policy =>
    policy.RequireAuthenticatedUser().RequireClaim("scope", "delete:catalog"));
});


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

app.UseAuthentication();

app.UseCors();

app.UseRouting();
