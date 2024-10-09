using Library.Application.Lends.ReturnLends;
using Library.Application.Lends.ReturnLends.Contracts;
using Library.Persistence.Ef;
using Library.Persistence.Ef.Books;
using Library.Persistence.Ef.Lends;
using Library.Persistence.Ef.Rates;
using Library.Persistence.Ef.UnitOfWorks;
using Library.Persistence.Ef.Users;
using Library.Services.Books;
using Library.Services.Books.Contracts;
using Library.Services.Lends;
using Library.Services.Lends.Contracts;
using Library.Services.Rates;
using Library.Services.Rates.Contracts;
using Library.Services.UnitOfWorks;
using Library.Services.Users;
using Library.Services.Users.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EfDataContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<BookService, BookAppService>();
builder.Services.AddScoped<UserService, UserAppService>();
builder.Services.AddScoped<BookRepository, EfBookRepository>();
builder.Services.AddScoped<UserRepository, EfUserRepository>();
builder.Services.AddScoped<UnitOfWork, EfUnitOfWork>();
builder.Services.AddScoped<LendsService, LendsAppService>();
builder.Services.AddScoped<LendRepository, EfLendRepository>();
builder.Services.AddScoped<RatesService, RatesAppService>();
builder.Services.AddScoped<RatesRepository, EfRatesRepository>();
builder.Services.AddScoped<ReturnLendHandler, ReturnLendCommandHandler>();

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