using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;

namespace Customers.API.Shared.ErrorHandling;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
    {
        var traceId = Activity.Current?.TraceId;
        logger.LogError("Error occured, running on {MachineName}, with trace id: {TraceId}", Environment.MachineName, traceId);

        await Results.Problem(title: "Something went wrong", statusCode: context.Response.StatusCode, extensions: new Dictionary<string, object?> { { "traceId", traceId } }).ExecuteAsync(context);

        return true;
    }
}
