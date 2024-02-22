using log4net;
using log4net.Util;

namespace WebApi.MiddleWhere
{
    public class Log
    {
       
            private readonly RequestDelegate _next;
        private readonly ILog _log;

            public Log(RequestDelegate next)
            {
                _next = next;
                _log = LogManager.GetLogger(typeof(Log));
            }

            public async Task Invoke(HttpContext httpContext)
            {
                try
                {
                _log.InfoExt(httpContext.Response);
                    await _next(httpContext);
                }
                catch (Exception ex)
                {
                    var res = (200+ ex.Message);

                    httpContext.Response.Clear();
                    httpContext.Response.ContentType = "application/json";
                    httpContext.Response.StatusCode = 400;
                    await httpContext.Response.WriteAsync(res);

                }
            
            }
    }
}
