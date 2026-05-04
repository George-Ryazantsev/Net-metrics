using Net_metrics.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

string filePath = "C:\\Users\\g.ryazancev\\Desktop\\Metrics\\metrics.txt";
//string filePath = "/home/dev1/metrics/Output/metrics.txt";
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.WebHost.UseUrls("http://0.0.0.0:5000");

builder.Services.AddScoped<IMetricsService, MetricsService>();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
    .MinimumLevel.Override("System", Serilog.Events.LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.File(filePath, rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

//builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // app.MapOpenApi();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Lifetime.ApplicationStarted.Register(() =>
{
    Console.WriteLine("Application started");
});

app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.Run();
