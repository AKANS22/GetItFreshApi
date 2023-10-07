using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
//Log.Logger = new LoggerConfiguration()
//    .WriteTo.File(path: "C:\\winks\\GetItFreshApi\\GetItFreshApi\\Log\\Log.txt",
//    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
//    rollingInterval: RollingInterval.Day,
//    rollOnFileSizeLimit:true,
//    restrictedToMinimumLevel: LogEventLevel.Information
//    )
//   .CreateLogger();

var log = new LoggerConfiguration()
    .WriteTo.File("Logs/Log.txt",
    rollingInterval: RollingInterval.Day,
    rollOnFileSizeLimit: true,
    restrictedToMinimumLevel:LogEventLevel.Information)
    .CreateLogger();

try
{
    log.Information("Application is starting");

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Host.UseSerilog();

    var app = builder.Build();
    

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseSerilogRequestLogging();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();


}
catch (Exception ex)
{

    Log.Fatal(ex, "Application failed to start");
}
finally
{
    Log.CloseAndFlush();
}
