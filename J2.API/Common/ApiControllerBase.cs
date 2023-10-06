using J2.API.Common.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace J2.API.Common
{
    [ApiController]
    [ExceptionActionFilter]
    public class ApiControllerBase : ControllerBase
    {
        protected IConfiguration _configuration;
        protected readonly IHttpContextAccessor _accessor;
        
        public ApiControllerBase(IConfiguration configuration, IHttpContextAccessor accessor)
        {
            this._accessor = accessor;
            _configuration = configuration;


        }
        protected string GetHeader(string key)
        {
            return _accessor.HttpContext.Request.Headers[key].ToString() ?? "";
        }


        
        protected ObjectResult StatusCode(HttpStatusCode statusCode, object value) =>
            StatusCode((int)statusCode, value);
        protected ObjectResult HandleResponse<ResponseType, ResponseClass>(ResponseBase<ResponseType, ResponseClass> response) =>
            StatusCode(response.HttpStatusCode, response);


        protected ObjectResult BadRequest(IEnumerable<string> errors = null) =>
              StatusCode(BaseResult.BadRequest.HttpStatus, BaseApiResult.Result(BaseResult.BadRequest.ActionCode, BaseResult.BadRequest.ActionMessage, errors));

        protected ObjectResult GeneralResponse(object obj, IEnumerable<string> errors = null)
        {
            var generalBaseResponse = obj as GeneralBaseResponse;
            var data = generalBaseResponse.GetType().GetProperty("Data");
            if (data != null)
                return StatusCode(generalBaseResponse.Result.HttpStatus, BaseApiResult<object>.Result(generalBaseResponse.Result.ActionCode, generalBaseResponse.Result.ActionMessage, data.GetValue(obj)));
            else
                return StatusCode(generalBaseResponse.Result.HttpStatus, BaseApiResult.Result(generalBaseResponse.Result.ActionCode, generalBaseResponse.Result.ActionMessage, errors));

        }


    }
}
