using EnterpriseERP.Webapi.Middleware;

namespace EnterpriseERP.Webapi.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder
            UseGlobalExceptionHandler(this  IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionHandler>();
        }
    }
}
