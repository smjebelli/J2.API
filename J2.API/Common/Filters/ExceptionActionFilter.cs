using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using J2.API.Constants;

namespace J2.API.Common.Filters
{
    public class ExceptionActionFilter : ExceptionFilterAttribute
    {
        public ExceptionActionFilter()
        {
        }

        #region Overrides of ExceptionFilterAttribute

        public override void OnException(ExceptionContext context)
        {
            if (context.ExceptionHandled) return;
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)BaseResult.Error.HttpStatus;

            
            Log.Error(
                context.Exception,
                LogTemplates.Exception,
                LogTemplates.InstanceName
                );

            var obj = BaseApiResult.Result(BaseResult.Error);

            context.Result = new JsonResult(obj);
            context.ExceptionHandled = true;
            base.OnException(context);
        }


        #endregion
    }
}
