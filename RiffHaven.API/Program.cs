using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RiffHaven.BLL.Interfaces;
using RiffHaven.BLL.Services;
using RiffHaven.DAL.Repositories;
using RiffHaven.DAL.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(o => o.AddPolicy("angular", option =>
            option.WithOrigins("http://localhost:4200")
                    .AllowCredentials()
                    .AllowAnyMethod()
                    .AllowAnyHeader()));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true, // peut être false
        ValidateAudience = true, // peut être false
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["jwt:issuer"],
        ValidAudience = builder.Configuration["jwt:audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt:key"]))

    };
}
);
//JWT
builder.Services.AddScoped<IJwtService, JwtService>();

builder.Services.AddScoped<IProductService, RiffHaven.BLL.Services.ProductService>();
builder.Services.AddScoped<IProductRepository, RiffHaven.DAL.Services.ProductService>(sp =>
    new RiffHaven.DAL.Services.ProductService(
        new System.Data.SqlClient.SqlConnection(
            builder.Configuration.GetConnectionString("default"))));
builder.Services.AddScoped<IUserService, RiffHaven.BLL.Services.UserService>();
builder.Services.AddScoped<IUserRepository, RiffHaven.DAL.Services.UserService>(sp =>
    new RiffHaven.DAL.Services.UserService(
        new System.Data.SqlClient.SqlConnection(
            builder.Configuration.GetConnectionString("default"))));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("angular");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
