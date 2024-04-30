using DecoratorPattern.Computers;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddLogging(config =>
{
    config.AddConsole();
    config.AddDebug();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

Debug.WriteLine("------------Apple laptop -------------");
AppleLaptop appleLaptop = new AppleLaptop();
appleLaptop.CloseLidExtended();

Debug.WriteLine("--------------Dell Laptop -------------");

DellLaptop dellLaptop = new DellLaptop();
dellLaptop.CloseLidExtended();
Debug.WriteLine("--------------Dell Laptop END -------------");



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
