
using System.Net;

namespace BookStore.Service.Exceptions
{
    public class HttpException : Exception
    {
        private HttpStatusCode StatusCode;

        private string Message;

        private int StatusNumericCode;

        public HttpException(string message, HttpStatusCode statusCode) : base(message) 
        {
            this.StatusCode = statusCode;
            this.StatusNumericCode = (int)statusCode;
        }

        public HttpException(string message, int statusCode) : base(message)
        {
            StatusNumericCode = statusCode;
            if (Enum.TryParse<HttpStatusCode>(statusCode.ToString(), out HttpStatusCode code))
                StatusCode = code;

        }
    }
}
