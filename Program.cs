using Net_metrics.Services;
using ServiceCloud.Extensions.Logging.File;

var builder = WebApplication.CreateBuilder(args);

//builder.Logging.AddJsonFileLogger(options=> options.FilePath = "C:\\Users\\g.ryazancev\\Desktop\\Metrics\\metrics.txt");
builder.Logging.AddJsonFileLogger(options => options.FilePath = "/home/dev1/metrics/Output/metrics.txt");
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.WebHost.UseUrls("http://0.0.0.0:5000");

builder.Services.AddScoped<IMetricsService, MetricsService>();

//builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
   // app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Lifetime.ApplicationStarted.Register(() =>
{
    Console.WriteLine("Application started!!!");
});

/*app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});*/

app.Run();
