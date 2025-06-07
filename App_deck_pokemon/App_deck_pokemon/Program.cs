using App_deck_pokemon.Repositories;
using App_deck_pokemon.Services;
using App_deck_pokemon.Tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<ImagePokemonRepository>();
builder.Services.AddScoped<PokemonRepository>();
builder.Services.AddScoped<UserPokemonRepository>();
builder.Services.AddScoped<PasswordService>();
builder.Services.AddScoped<JWTService>();

builder.Services.AddDbContext<DataDbContext>();

builder.Services.AddAuthentication(a =>
{
    a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o => o.TokenValidationParameters = new TokenValidationParameters()
{
    ValidateIssuerSigningKey = true,
    ValidateIssuer = true,
    ValidIssuer = "sogeti",
    ValidateLifetime = true,
    ValidateAudience = true,
    ValidAudience = "sogeti",
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Bonjour je suis la cl� de s�curit� pour g�n�rer la JWT")),

});
builder.Services.AddAuthorization((builder) =>
{
    builder.AddPolicy("admin", options =>
    {
        options.RequireRole("admin");
    });
    builder.AddPolicy("client", options =>
    {
        options.RequireRole("client", "admin");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
