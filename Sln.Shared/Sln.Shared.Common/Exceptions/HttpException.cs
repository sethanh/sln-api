using System.Net;

namespace Sln.Shared.Common.Exceptions
{
    public abstract class HttpException(string message, HttpStatusCode statusCode) : Exception(message)
    {
        public HttpStatusCode StatusCode { get; set; } = statusCode;
    }
    
    public class HttpNotFound(string message) : HttpException(message, HttpStatusCode.NotFound)
    {
    }

    public class HttpUnauthorized(string message) : HttpException(message, HttpStatusCode.Unauthorized)
    {
    }
    public class HttpPaymentRequired(string message) : HttpException(message, HttpStatusCode.PaymentRequired)
    {
    }
    public class HttpForbidden(string message) : HttpException(message, HttpStatusCode.Forbidden)
    {
    }
    public class HttpRequestTimeout(string message) : HttpException(message, HttpStatusCode.RequestTimeout)
    {
    }
    public class HttpGatewayTimeout(string message) : HttpException(message, HttpStatusCode.GatewayTimeout)
    {
    }

    public class HttpBadRequest(string message) : HttpException(message, HttpStatusCode.BadRequest)
    {
    }
    public class InternalServerError(string message) : HttpException(message, HttpStatusCode.InternalServerError)
    {
    }

    public class HttpNotImplemented(string message) : HttpException(message, HttpStatusCode.NotImplemented)
    {
    }
    public class HttpBadGateway(string message) : HttpException(message, HttpStatusCode.BadGateway)
    {
    }
}