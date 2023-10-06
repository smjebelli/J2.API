namespace J2.API.Common
{
    public static class BaseApiResult
    {
        public static BaseResponse Result(string actionCode, string actionMessage, IEnumerable<string> errorMessages = null) => new BaseResponse()
        {
            ActionCode = actionCode,
            ActionMessage = actionMessage,
            ErrorMessages = errorMessages
        };

        public static BaseResponse Result(BaseResult result, IEnumerable<string> errorMessages = null) => new BaseResponse()
        {
            ActionCode = result.ActionCode,
            ActionMessage = result.ActionMessage,
            ErrorMessages = errorMessages
        };

    }
    public static class BaseApiResult<T>
    {
        public static BaseResponse<T> Result(BaseResult result, string traceNumber, Guid referenceNumber, T obj, IEnumerable<string> errorMessages = null) => new BaseResponse<T>
        {
            ActionCode = result.ActionCode,
            ActionMessage = result.ActionMessage,
            TraceNumber = traceNumber,
            ReferenceNumber = referenceNumber,
            Data = obj,
            ErrorMessages = errorMessages
        };

        public static BaseResponse<T> Result(string actionCode, string actionMessage, T obj, IEnumerable<string> errorMessages = null) => 
            new BaseResponse<T>
        {
            ActionCode = actionCode,
            ActionMessage = actionMessage,
            Data = obj,
            ErrorMessages = errorMessages
        };
    }
}
