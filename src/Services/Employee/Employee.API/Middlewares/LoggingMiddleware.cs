using System.Diagnostics;
using Employee.API.Models;
using System.Net;
using System.Text.Json;

namespace Employee.API.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;
        private readonly Stopwatch _stopwatch;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
            _stopwatch = new Stopwatch();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _stopwatch.Start();

            await _next(context);

            _stopwatch.Stop();

            var elapsedMilliseconds = _stopwatch.ElapsedMilliseconds;

            var message = $"Request [{context.Request.Method}] at {context.Request.Path} " +
                          $"with response code {context.Response.StatusCode} took {elapsedMilliseconds}";

            if(elapsedMilliseconds > 4000)
                _logger.LogWarning(message);

            _logger.LogInformation(message);
        }
    }
}
