using Autofac;
using Autofac.Extensions.DependencyInjection;
using GuideService.API.Utilities;
using GuideService.Data.Contexts;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<DatabaseSettings>(
        builder.Configuration.GetSection("MongoConnection"));

builder.Services.AddSingleton<IMongoDatabase>(options => {
    var settings = builder.Configuration.GetSection("MongoConnection").Get<DatabaseSettings>();
    var client = new MongoClient(settings.ConnectionString);
    return client.GetDatabase(settings.DatabaseName);
});

builder.Services.AddSingleton<MongoDbContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton<MongoDbContext>();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new DependencyResolver()));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
    policy =>
    {
        policy.WithOrigins(builder.Configuration["Allowed:Origins"])
            .WithMethods(builder.Configuration["Allowed:Methods"])
        .WithHeaders(builder.Configuration["Allowed:Headers"]);
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseStaticFiles();

app.MapControllers();

app.Run();
