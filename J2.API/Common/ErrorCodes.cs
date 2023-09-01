namespace J2.API.Common
{
    public static class ErrorCode
    {
        public const string EXC = "خطای سیستمی";
        public const string OK = "عملیات موفق";
        public const string NOK = "خطایی رخ داده است";
        public const string EMPTYDATA = "داده خالی";
        public const string EMPTYDATA_USER = "ورود کاربر تائید نشده";
        public const string PROVIDER_ERROR = "خطای سرویس دهنده";
        public const string NO_METHOD_WERE_FOUND = "متد اجرا پیدا نشد.";
       
    }

    public enum NErrorCode
    {
        EXC = -1,
        OK = 0,
        NOK = 1,
        EMPTYDATA = 2,
        EMPTYDATA_USER = 3,
        PROVIDER_ERROR = 10,
        NO_METHOD_WERE_FOUND = 30,
       


    }
}
