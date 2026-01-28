using System;
using Customers.API.Data;
using Microsoft.AspNetCore.Mvc;
using Customers.API.Shared.FileUpload;
using Microsoft.VisualBasic;
using Customers.API.Features.Customers.Constants;

namespace Customers.API.Features.Customers.UpdateCustomer;

public static class UpdateCustomerEndpoint
{
    public static void MapUpdateCustomerEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPut("/{id}", async (
            [FromRoute] Guid id,
            [FromForm] UpdateCustomerDto customer,
            [FromServices] FileUploadHandler fileUploadHandler,
            [FromServices] CustomerContext dbContext) =>
        {
            var found = await dbContext.Customers.FindAsync(id);
            if (found is null)
            {
                return Results.NotFound();
            }

            if (customer.ImageFile is not null)
            {
                FileUploadResult fileUploadResult = await fileUploadHandler.
                                            UploadFileAsync(customer.ImageFile,
                                                            StorageNames.CustomerImagesFolder);
                if (!fileUploadResult.IsSuccess)
                {
                    return Results.BadRequest();
                }
                found.FileUri = fileUploadResult.FileUploadUrl!;
            }

            found.CustomerAddressId = customer.CustomerAddressId;
            found.GithubUserName = customer.GithubUserName;
            found.Name = customer.Name;
            await dbContext.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}
