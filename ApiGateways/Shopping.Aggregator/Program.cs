using Shopping.Aggregator.Services;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<ICatalogService, CatalogService>(c =>
{
    c.BaseAddress = new Uri(configuration["ApiSettings:CatalogUrl"]);
});

builder.Services.AddHttpClient<IBasketService, BasketService>(b =>
{
    b.BaseAddress = new Uri(configuration["ApiSettings:BasketUrl"]);
});

builder.Services.AddHttpClient<IOrderService, OrderService>(o =>
{
    o.BaseAddress = new Uri(configuration["ApiSettings:OrderingUrl"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
