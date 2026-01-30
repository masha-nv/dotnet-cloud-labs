using System;
using System.Runtime.CompilerServices;
using Customers.API.Data;
using Customers.API.Features.Customers.Constants;
using Customers.API.Features.Customers.GetCustomerById;
using Microsoft.AspNetCore.Mvc;
using Customers.API.Shared.FileUpload;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Customers.API.Features.Customers.CreateCustomer;

public static class CreateCustomerEndpoint
{
    private const string DefaultImageUri = "";
    public static void MapCreateCustomerEndpoint(this IEndpointRouteBuilder app)
    {

        app.MapPost("/", async (
            [FromForm] CreateCustomerDto customer,
            [FromServices] FileUploadHandler fileUploadHandler,
            [FromServices] CustomerContext dbContext,
            ClaimsPrincipal principal) =>
        {
            if (principal?.Identity?.IsAuthenticated == false)
            {
                return Results.Unauthorized();
            }
            var imageUri = DefaultImageUri;


            var lastUpdatedBy = principal?.FindFirstValue(JwtRegisteredClaimNames.Sub);

            if (customer.ImageFile is not null)
            {
                FileUploadResult result = await fileUploadHandler.UploadFileAsync(customer.ImageFile, StorageNames.CustomerImagesFolder);
                if (!result.IsSuccess)
                {
                    return Results.BadRequest(new { message = result.ErrorMessage });
                }

                imageUri = result.FileUploadUrl;
            }

            Models.Customer c = customer.ToNewCustomer(imageUri!, lastUpdatedBy!);
            await dbContext.Customers.AddAsync(c);
            await dbContext.SaveChangesAsync();
            return Results.CreatedAtRoute(RouteNames.GetCustomerByIdEndPoint, new { id = c.Id }, c.ToCustomerDetailsDto());
        }).
        DisableAntiforgery();
    }
}
