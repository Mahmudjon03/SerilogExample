using log4net;
using log4net.Config;
using WebApi.MiddleWhere;
using WebApi.Services;
var builder = WebApplication.CreateBuilder(args); 
// Add services to the container.

     builder.Services.AddSingleton<IUserService, UserService>();
     builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseExceptionHandler("/exception");


app.Map("/exception", app => app.Run(async httpContext =>
{
    ILog log = LogManager.GetLogger(typeof(Program));
    log.Error("Internal error in API");
    httpContext.Response.Clear();
    httpContext.Response.StatusCode = 404;
    await httpContext.Response.WriteAsync("Internal error in API");
}));
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
XmlConfigurator.Configure(new FileInfo("log4net.config"));

app.UseMiddleware<ExaptionHandler>();
app.UseMiddleware<Log>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
