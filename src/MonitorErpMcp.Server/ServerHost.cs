using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol;
using MonitorErpMcp.Server.Tools;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MonitorErpMcp.Server
{
    /// <summary>
    /// Builds the MCP catalog server host for either transport. The same three read-only tools are
    /// served over stdio (the default) or stateless streamable HTTP (<c>--transport http</c>). The
    /// materialized catalog is built once as a singleton at startup (reflection over the 1,717-type
    /// MonitorG5.Api assembly, roughly 170 ms); tools are thin adapters over it.
    /// </summary>
    public static class ServerHost
    {
        /// <summary>The wire protocol transport the server binds to.</summary>
        public enum Transport
        {
            /// <summary>JSON-RPC over stdio; the default. Used by MCP clients that spawn the server.</summary>
            Stdio,

            /// <summary>Stateless streamable HTTP; no session state, so requests load-balance freely.</summary>
            Http,
        }

        /// <summary>
        /// Resolves <c>--transport</c> from <paramref name="args"/>; stdio is the default when the
        /// switch is absent. Both <c>--transport http</c> and <c>--transport=http</c> forms are accepted
        /// so an unknown switch never silently falls back to stdio.
        /// </summary>
        /// <exception cref="ArgumentException">The switch is missing a value or the value is unknown.</exception>
        public static Transport ParseTransport(string[] args)
        {
            for (var i = 0; i < args.Length; i++)
            {
                var arg = args[i];
                string? value;
                if (arg == "--transport")
                {
                    value = i + 1 < args.Length ? args[i + 1] : null;
                }
                else if (arg.StartsWith("--transport=", StringComparison.Ordinal))
                {
                    value = arg["--transport=".Length..];
                }
                else
                {
                    continue;
                }

                if (value is null)
                {
                    throw new ArgumentException("--transport requires a value: 'stdio' or 'http'.");
                }

                return value switch
                {
                    "stdio" => Transport.Stdio,
                    "http" => Transport.Http,
                    var unknown => throw new ArgumentException($"Invalid --transport value '{unknown}'; expected 'stdio' or 'http'."),
                };
            }

            return Transport.Stdio;
        }

        /// <summary>Builds a stdio-hosted catalog server (generic host; stdout carries the JSON-RPC protocol).</summary>
        public static IHost BuildStdioHost(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);
            ConfigureServices(builder.Services, Transport.Stdio);
            ConfigureLogging(builder.Logging);
            var host = builder.Build();
            _ = host.Services.GetRequiredService<CatalogService>(); // build the catalog at startup, not on the first request
            return host;
        }

        /// <summary>
        /// Builds an HTTP-hosted catalog server (stateless streamable HTTP at the app root, default
        /// <c>http://localhost:5000</c>; override with <c>--urls</c>). <c>MapMcp</c> has already been
        /// applied, so the returned app is ready to <c>RunAsync</c>.
        /// </summary>
        public static WebApplication BuildHttpApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder.Services, Transport.Http);
            ConfigureLogging(builder.Logging);
            var app = builder.Build();
            _ = app.Services.GetRequiredService<CatalogService>(); // build the catalog at startup, not on the first request
            app.MapMcp();
            return app;
        }

        /// <summary>
        /// The serializer for tool structured content and its JSON text fallback: identical to the SDK
        /// default (<see cref="McpJsonUtilities.DefaultOptions"/>) except null-valued properties are
        /// emitted rather than omitted, so every property the advertised output schema marks required
        /// is present on the wire.
        /// </summary>
        /// <remarks>
        /// The SDK's output-schema generator marks every property required (it ignores nullability
        /// annotations), while its default serializer drops nulls. A query result has no command
        /// <c>fullPath</c>, so omitting it makes the response fail any client that validates structured
        /// content against the advertised schema. Emitting nulls keeps <c>search</c> and
        /// <c>get_record</c> responses conformant.
        /// </remarks>
        public static JsonSerializerOptions StructuredContentSerializer { get; } =
            new(McpJsonUtilities.DefaultOptions) { DefaultIgnoreCondition = JsonIgnoreCondition.Never };

        /// <summary>
        /// Registers the services shared by both transports: the singleton catalog and the MCP server
        /// with the three read-only tools and the chosen transport.
        /// </summary>
        public static void ConfigureServices(IServiceCollection services, Transport transport)
        {
            // The materialized catalog (reflection over MonitorG5.Api) is a singleton; the host
            // builders resolve it eagerly once at startup so no request pays the build cost.
            services.AddSingleton<CatalogService>();

            var mcp = services.AddMcpServer().WithTools([typeof(MonitorApiTools)], StructuredContentSerializer);
            switch (transport)
            {
                case Transport.Stdio:
                    mcp.WithStdioServerTransport();
                    break;
                case Transport.Http:
                    // Stateless streamable HTTP: no session state and no session affinity, so requests can
                    // be load-balanced freely. Stateless is the default in the 2026-07-28 protocol
                    // revision; the option is explicit for clarity.
                    mcp.WithHttpTransport(options => options.Stateless = true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(transport), transport, "Unknown transport.");
            }
        }

        /// <summary>Keeps server logs off stdout (which carries the JSON-RPC protocol in stdio mode).</summary>
        private static void ConfigureLogging(ILoggingBuilder logging)
        {
            logging.ClearProviders();
            logging.AddConsole(options => options.LogToStandardErrorThreshold = LogLevel.Trace);
        }
    }
}
