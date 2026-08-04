using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MonitorErpMcp.Server;
using MonitorErpMcp.Server.Tools;

// Stdio-hosted MCP catalog server. stdout carries the JSON-RPC protocol; server logs go to stderr.
var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddMcpServer()
    .WithStdioServerTransport()
    .WithTools<MonitorApiTools>();

// Build the materialized catalog once at startup (reflection over MonitorG5.Api, tens of ms).
builder.Services.AddSingleton<CatalogService>();

builder.Logging.ClearProviders();
builder.Logging.AddConsole(options =>
{
    options.LogToStandardErrorThreshold = LogLevel.Trace;
});

await builder.Build().RunAsync();
