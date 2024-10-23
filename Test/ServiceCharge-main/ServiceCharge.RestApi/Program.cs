using ServiceCharge.Persistence.Ef;
using ServiceCharge.Persistence.Ef.UnitOfWorks;
using ServiceCharge.Services.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using ServiceCharge.Persistence.Ef.Blocks;
using ServiceCharge.Persistence.Ef.Floors;
using ServiceCharge.Persistence.Ef.Units;
using ServiceCharge.Services.Blocks;
using ServiceCharge.Services.Blocks.Contracts;
using ServiceCharge.Services.Floors.Contracts;
using ServiceCharge.Services.Units.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EfDataContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<UnitOfWork, EfUnitOfWork>();
builder.Services.AddScoped<BlockRepository, EFBlockRepository>();
builder.Services.AddScoped<BlockService, BlockAppService>();
builder.Services.AddScoped<BlockQuery, EFBlockQuery>();
builder.Services.AddScoped<FloorQuery, EFFloorQuery>();
builder.Services.AddScoped<FloorRepository, EFFloorRepository>();
builder.Services.AddScoped<FloorService, FloorService>();
builder.Services.AddScoped<UnitRepository, EFUnitRepository>();
builder.Services.AddScoped<UnitService, UnitService>();
builder.Services.AddScoped<UnitQuery, EFUnitQuery>();

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