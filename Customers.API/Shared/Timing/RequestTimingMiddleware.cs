using System;
using System.Diagnostics;

namespace Customers.API.Shared.Timing;

public class RequestTimingMiddleware(RequestDelegate next, ILogger<RequestTimingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var stopWatch = new Stopwatch();
        try
        {
            stopWatch.Start();
            await next(context);
            stopWatch.Stop();
            var elapsedMls = stopWatch.ElapsedMilliseconds;
            logger.LogInformation("Request Method {Method} took {ElapsedMs} ms", context.Request.Method, elapsedMls);
        }
        catch (Exception ex)
        {
            logger.LogInformation("Request failed with {ErrorMessage}", ex.Message);
        }
    }
}
