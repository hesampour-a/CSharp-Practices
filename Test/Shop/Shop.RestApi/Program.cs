using Microsoft.EntityFrameworkCore;
using Shop.Applications.Orders.AddOrders;
using Shop.Applications.Orders.AddOrders.Contracts;
using Shop.Persistence.Ef.Customers;
using Shop.Persistence.Ef.Data;
using Shop.Persistence.Ef.OrderItems;
using Shop.Persistence.Ef.Orders;
using Shop.Persistence.Ef.Products;
using Shop.Persistence.Ef.UnitOfWorks;
using Shop.Services.Customers.Contracts;
using Shop.Services.OrderItems.Contracts;
using Shop.Services.Orders;
using Shop.Services.Orders.Contracts;
using Shop.Services.Products.Contracts;
using Shop.Services.UnitOfWorks.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EfDataContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ProductsRepository, EfProductsRepository>();
builder.Services.AddScoped<CustomersRepository, EfCustomersRepository>();
builder.Services.AddScoped<OrdersRepository, EfOrdersRepository>();
builder.Services.AddScoped<OrderItemsRepository, EfOrderItemsRepository>();
builder.Services.AddScoped<OrdersService, OrdersAppService>();
builder.Services.AddScoped<ProductService, ProductService>();
builder.Services.AddScoped<CustomersService, CustomersService>();
builder.Services.AddScoped<OrderItemsService, OrderItemsService>();
builder.Services.AddScoped<UnitOfWork, EfUnitOfWork>();
builder.Services.AddScoped<AddOrderHandler, AddOrderCommandHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();