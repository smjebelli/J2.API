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
        //public const string CUSTOMER_NOT_FOUND = "مشتری با شماره ارسالی یافت نشده.";
        //public const string DELIVERY_NOT_FOUND = "آدرس ارسال ثبت نشده است.";
        //public const string CARD_NOT_FOUND = "اطلاعات کارت یافت نشد";
        //public const string CARD_NOT_YOURS = "کارت انتخابی متعلق به شما نمی باشد";
        //public const string CARD_NOT_READY_PRINT = "اطلاعات صدور کارت در دسترس نیست";
        //public const string UNAUTHORIZE_CHEQ = "به دلیل وجود چک برگشتی مجاز به ادامه فرآیمد نمی باشید.";
        //public const string WALLET_TRANSACTION_FAILED = "خطا در برداشت از کیف پول";
        //public const string Request_Unfinished = "درخواست ناتمام دارید";

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
        //CUSTOMER_NOT_FOUND = 100,
        //DELIVERY_NOT_FOUND = 101,
        //CARD_NOT_FOUND = 102,
        //CARD_NOT_YOURS = 103,
        //CARD_NOT_READY_PRINT = 104,
        //WALLET_TRANSACTION_FAILED = 120,
        //Request_Unfinished = 121,
        //UNAUTHORIZE_CHEQ = 122,


    }
}
