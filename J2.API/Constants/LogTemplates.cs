namespace J2.API.Constants
{
    public class LogTemplates
    {
        public const string Request = "Request InstanceName: {@InstanceName}, Schema: {@Schema},Host: {@Host},Path: {@Path},QueryString: {@QueryString},Body: {@Body},Header: {@Header}, UserData: {@UserData}";
        public const string Response = "Response InstanceName: {@InstanceName}, Schema: {@Schema},Host: {@Host},Path: {@Path},HttpStatus: {@HttpStatus},Body: {@Body}, UserData: {@UserData}";
        public const string Exception = "Exception InstanceName: {@InstanceName}, UserData: {@UserData}";
        public const string Information = "Information InstanceName: {@InstanceName}, ClassName: {@ClassName}, MethodName: {@MethodName}, UserData: {@UserData}";
        public const string RequestSoap = "RequestSoap InstanceName: {@InstanceName}, Request: {@Request}, UserData: {@UserData}";
        public const string ResponseSoap = "ResponseSoap InstanceName: {@InstanceName}, Response: {@Response}, UserData: {@UserData}, InstanceName: {@InstanceName}";
        public static string InstanceName => Environment.GetEnvironmentVariable("APSNETCORE_APP_InstanceName");
    }
}
