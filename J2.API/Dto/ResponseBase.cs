using J2.API.Common;
using System.Text.Json.Serialization;

namespace J2.API.Dto
{
    public class ResponseBase<T> where T : class
    {
        public ResponseBase(bool operationResult, string message, List<Error> error)
        {
            OperationResult = operationResult;
            Message = message;
            Error = error;
            if (error.Any())
            {
                var last = error.FirstOrDefault();
                actionCode = last.ErrorCode.ToString();
                ActionMessage = last.ErrorDesc.ToString();
                if (!string.IsNullOrEmpty(last.GatewayError))
                    ActionMessage += " - " + last.GatewayError;

                Message = ActionMessage;
            }
        }

        public ResponseBase(T data, string message = null, int totalRecords = 0, int currentIndex = 0, int recordsPerPage = 0)
        {
            OperationResult = true;
            actionCode = "00000";

            if (string.IsNullOrEmpty(message))
                Message = "عملیات با موفقیت انجام شد.";
            else
                Message = message;

            Data = data;

            Error = new List<Error>();
            Error.Add(new Error() { ErrorCode = (int)NErrorCode.OK });

            TotalRecords = totalRecords;
            CurrentIndex = currentIndex;
            RecordsPerPage = recordsPerPage;
        }

        [JsonPropertyName("operationResult")]
        public bool OperationResult { get; set; }

        [JsonPropertyName("actionCode")]
        public string actionCode { get; set; }

        [JsonPropertyName("actionMessage")]
        public string ActionMessage { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }


        [JsonPropertyName("data")]
        public T Data { get; set; }

        [JsonPropertyName("errorMessages")]
        public List<Error> Error { get; set; }


        [JsonPropertyName("referenceNumber")]
        public string ReferenceNumber { get; set; }


        [JsonPropertyName("traceNumber")]
        public string TraceNumber { get; set; }

        [JsonPropertyName("totalrecords")]
        public int TotalRecords { get; set; }

        [JsonPropertyName("currentindex")]
        public int CurrentIndex { get; set; }

        [JsonPropertyName("recordsperpage")]
        public int RecordsPerPage { get; set; }

    }

    public class Error
    {
        public int ErrorCode { get; set; }
        public string? ErrorDesc { get; set; }
        public string? ReferenceName { get; set; }
        public string? GatewayError { get; set; }
    }
}
