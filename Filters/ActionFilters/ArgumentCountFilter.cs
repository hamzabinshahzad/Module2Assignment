using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ModuleAssignment.Filters.ActionFilters
{
    public class ArgumentCountFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if(context.ActionArguments.Count() < 1)
            {
                context.Result = new BadRequestObjectResult("Required arguments were missing!");
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"[ArgumentCountFilter]: [controller: {context.Controller}][Action: {context.ActionDescriptor}] Model State => {context.ModelState}");
        }
    }
}
