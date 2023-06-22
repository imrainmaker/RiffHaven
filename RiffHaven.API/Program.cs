using RiffHaven.BLL.Interfaces;
using RiffHaven.DAL.Repositories;
using RiffHaven.DAL.Services;

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

builder.Services.AddScoped<IProductService, RiffHaven.BLL.Services.ProductService>();
builder.Services.AddScoped<IProductRepository, ProductService>(sp =>
    new ProductService(
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
