using System.Net;
using Microsoft.AspNetCore.Mvc;
using Shared.ErrorModels;

namespace E_CommerceG01.Factories
{
    public class ApiResponseFactory
    {
        public static IActionResult CustomeValidationError(ActionContext actionContext)
        {
            //Get All Errors From ModelState
            var errors = actionContext.ModelState
             .Where(e => e.Value.Errors.Any())
             .Select(e => new ValidationError
             {
                 Field = e.Key,
                 Errors = e.Value.Errors.Select(x => x.ErrorMessage).ToList()
             });
            //Create Custom Response
            var response = new ValidationErrorsResponse
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                Message = "There Is A Problem With Validation",
                Errors = errors
            };
            //Return Bad Request
            return new BadRequestObjectResult(response);
        }
    }
}
