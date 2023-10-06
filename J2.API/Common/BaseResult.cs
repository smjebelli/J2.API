using System.Net;

namespace J2.API.Common
{
    public class GeneralBaseResponse<T> : GeneralBaseResponse
    {
        public T Data { get; set; }
    }
    public class GeneralBaseResponse
    {
        public BaseResult Result { get; set; }
    }
    public class BaseResult
    {
        public virtual string ActionMessage { get; set; }
        public virtual string ActionCode { get; set; }
        public virtual bool OperationResult { get; set; }
        public virtual HttpStatusCode HttpStatus { get; set; }

        public BaseResult(bool operationResult,string message, string code, HttpStatusCode httpStatus)
        {
            this.ActionMessage = message;
            this.ActionCode = code;
            this.HttpStatus = httpStatus;
            this.OperationResult = operationResult;

        }
        
        public static BaseResult Ok => new BaseResult(true,"انجام عملیات موفق آمیز بود", "0000", HttpStatusCode.OK);
        public static BaseResult Created => new BaseResult(true,"انجام عملیات موفق آمیز بود", "0000", HttpStatusCode.Created);
        public static BaseResult Error => new BaseResult(false,"خطای سیستمی رخ داده است", "0500", HttpStatusCode.InternalServerError);
        public static BaseResult BadRequest => new BaseResult(false,"خطا در مقادیر ورودی", "0400", HttpStatusCode.BadRequest);
        //public static BaseResult NotFound => new BaseResult(false, "داده ای برای اعمال یافت نشد.", "0404", HttpStatusCode.NotFound);
        public static BaseResult NotContent => new BaseResult(false, "داده ای برای اعمال یافت نشد.", "0204", HttpStatusCode.NoContent);
        

    }
}
