using System.Net;

namespace J2.API.Common
{
    public class HttpStatusAttribute : Attribute
    {
        public HttpStatusCode HttpStatus { get; }

        public HttpStatusAttribute(HttpStatusCode httpStatus)
        {
            this.HttpStatus = httpStatus;
        }
    }
}
