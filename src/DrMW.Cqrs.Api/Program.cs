using System.Text.Json.Serialization;
using DrMW.Cqrs.Repository;
using DrMW.Cqrs.Service;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Graylog;
using Serilog.Sinks.Graylog.Core.Transport;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddHealthChecks();
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .Filter.ByExcluding(c => c.Properties.ContainsKey("RequestPath") && c.Properties["RequestPath"].ToString().Contains("/health"))
    .WriteTo.Console()
    .CreateLogger();
        
builder.Host.UseSerilog();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSerilogRequestLogging(options =>
{
    options.GetLevel = (httpContext, elapsed, ex) => LogEventLevel.Verbose;
    options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
    {
        diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
        diagnosticContext.Set("RequestPath", httpContext.Request.Path);
    };
});
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseHealthChecks("/api/health",new HealthCheckOptions
{
    ResponseWriter = async (context, report) =>
    {
        await context.Response.WriteAsync("Ok");
    }
});
app.Run();

