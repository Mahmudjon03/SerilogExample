using Serilog;
using WebApi.Services;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
using var log = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();
     builder.Services.AddSingleton<Serilog.ILogger>(log);
     log.Information("!!!!!Test Serilog!!!!!");
     builder.Services.AddSingleton<IUserService, UserService>();
     builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
