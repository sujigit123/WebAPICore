using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace TestWebAPI.Filters
{
    public class ValidateKeyAttribute : Attribute,IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string  inputKey = context.ActionArguments.Values.FirstOrDefault().ToString();           

            if (!Regex.Match(inputKey, @"^[a-zA-Z0-9-_~\.]{1,32}$").Success)
            {
                context.Result = new BadRequestObjectResult("Invalid key provided."); // other option to check
                return;                
            }
        }
    }
}
