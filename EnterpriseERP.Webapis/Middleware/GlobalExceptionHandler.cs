using System.Net;
using System.Text.Json;

namespace EnterpriseERP.Webapi.Middleware
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _request;
        private readonly ILogger<GlobalExceptionHandler> _logger;
        public GlobalExceptionHandler(RequestDelegate Request, ILogger<GlobalExceptionHandler> logger)
        {
            _request = Request;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int) 
                    HttpStatusCode.InternalServerError;
                var response = new
                {
                    Success = false,
                    Message = ex.Message
                };
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}
