namespace J2.API.Common
{
    public class BaseResponse
    {
        public string ActionMessage { get; set; }
        public string ActionCode { get; set; }
        public string TraceNumber { get; set; }
        public Guid ReferenceNumber { get; set; }
        public IEnumerable<string> ErrorMessages { get; set; }
    }
    public class BaseResponse<T> : BaseResponse
    {
        public T Data { get; set; }
    }
}
