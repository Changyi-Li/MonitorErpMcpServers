using MonitorErpMcp.Server;

// The catalog MCP server serves the same three read-only tools over stdio (the default) or stateless
// streamable HTTP (--transport http). stdout carries the JSON-RPC protocol in stdio mode; server
// logs go to stderr.
var transport = ServerHost.ParseTransport(args);

if (transport == ServerHost.Transport.Http)
{
    var app = ServerHost.BuildHttpApp(args);
    await app.RunAsync();
}
else
{
    var host = ServerHost.BuildStdioHost(args);
    await host.RunAsync();
}
