using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

public class Log
{
    private readonly RequestDelegate _next;
    private readonly ILog _logger;

    public Log(RequestDelegate next, ILoggerFactory loggerFactory)
    {
        _next = next;
        _logger = LogManager.GetLogger(typeof (Log));   
    }

    public async Task Invoke(HttpContext context)
    {
        // Log the request
        var request = await FormatRequest(context.Request);
        _logger.Info(request);

        // Store the current response body stream
        var originalBodyStream = context.Response.Body;

        // Create a new memory stream to capture the response
        using (var responseBody = new MemoryStream())
        {
            // Replace the response body with our stream
            context.Response.Body = responseBody;

            // Continue processing the request
            await _next(context);

            // Log the response
            var response = await FormatResponse(context.Response);
            _logger.Info(response);

            // Copy the response stream to the original body stream
            await responseBody.CopyToAsync(originalBodyStream);
        }
    }

    private async Task<string> FormatRequest(HttpRequest request)
    {
        request.EnableBuffering();

        // Read the request body
        using (var reader = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true))
        {
            var body = await reader.ReadToEndAsync();
            request.Body.Position = 0;
            return $"{request.Method} {request.Scheme}://{request.Host}{request.Path} {request.QueryString} {body}";
        }
    }

    private async Task<string> FormatResponse(HttpResponse response)
    {
        response.Body.Seek(0, SeekOrigin.Begin);

        // Read the response body
        var body = await new StreamReader(response.Body).ReadToEndAsync();

        // Restore the original response body position
        response.Body.Seek(0, SeekOrigin.Begin);

        return $"HTTP {response.StatusCode} {body}";
    }
}