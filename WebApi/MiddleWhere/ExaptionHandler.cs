using log4net;
using Microsoft.AspNetCore.Http;

namespace WebApi.MiddleWhere
{
    public class ExaptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILog _log;
        public ExaptionHandler(RequestDelegate next)
        {
            _next = next;
            _log = LogManager.GetLogger(typeof(ExaptionHandler));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
               await _next(context);
            }
            catch (Exception ex)
            {

                _log.Error(ex.Message);
                context.Response.Clear();
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 400;
                string message = "Test";
                await context.Response.WriteAsync(message);
            }
        }
    }
}
