using MassTransit;
using MassTransit.Testing;
using Microsoft.EntityFrameworkCore;
using Product.API.Data;
using System.Reflection;
using TransactionService.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AccountDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProductConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<IPublishEndpoint>();
builder.Services.AddScoped<ITransactonServices, TransactonServices>();
builder.Services.AddMassTransit(config =>
{
    config.SetKebabCaseEndpointNameFormatter();

    //config.AddConsumer<NewCustomerConsumer>();
    //config.AddConsumer<ActivateCustomerConsumer>();
    //config.AddConsumer<AccountTransactionConsumer>();

    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.ConfigureEndpoints(ctx);
        cfg.Host("localhost", hostConfigurator => { });
    });

    config.AddConsumers(Assembly.GetExecutingAssembly());


});
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
