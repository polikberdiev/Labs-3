using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lab6.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ValidateModelFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (context.ModelState.IsValid)
            {
                return;
            }

            context.Result = new BadRequestObjectResult(context.ModelState);
        }
    }
}