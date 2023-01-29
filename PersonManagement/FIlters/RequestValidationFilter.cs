using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PersonManagement.WebApi.FIlters
{
    public class RequestValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid || context.ActionArguments.Any(s => s.Value == null))
            {
                context.Result = new BadRequestObjectResult($"Bad request data");
            }
        }
    }
}
