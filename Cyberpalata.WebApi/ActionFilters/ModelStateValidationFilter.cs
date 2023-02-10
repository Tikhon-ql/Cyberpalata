using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Cyberpalata.WebApi.ActionFilters
{
    public class ModelStateValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var modelState = context.ModelState;
                var errorList = modelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );
                //var message = string.Join(" | ", modelState.Values
                //.SelectMany(v => v.Errors)
                //.Select(e => e.ErrorMessage));
                var json = JsonConvert.SerializeObject(errorList);
                context.Result = new UnprocessableEntityObjectResult(json);
            }
        }
    }
}
