using J2.API.Common;
using System.Net;

namespace J2.API.Constants
{
    public class NodeResult : BaseResult
    {
        public NodeResult(bool operationResult,string message, string code, HttpStatusCode httpStatus) : base(operationResult,message, code, httpStatus)
        {
            this.ActionMessage = message;
            this.ActionCode = code;
            this.HttpStatus = httpStatus;
            this.OperationResult= operationResult;
        }



        public static NodeResult UserNotFound => new NodeResult(false,"کاربر یافت نشد", "1001", HttpStatusCode.NoContent);
        public static NodeResult FamilyAlreadyExists => new NodeResult(false,"خانواده ای با همین نام برای این کاربر موجود است", "1002", HttpStatusCode.NotAcceptable);

    }
}
