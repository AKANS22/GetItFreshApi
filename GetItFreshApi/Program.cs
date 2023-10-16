using GetItFreshApi.DatabaseManagement;
using Serilog;
using Serilog.Events;
using Microsoft.EntityFrameworkCore;
using GetItFreshApi.Configuration;
using GetItFreshApi.IRepository;
using GetItFreshApi.GenericRepository;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
Log.Logger = new LoggerConfiguration()
    .WriteTo.File(path: "C:\\winks\\GetItFreshApi\\GetItFreshApi\\Log\\Log.txt",
    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
    rollingInterval: RollingInterval.Day,
    rollOnFileSizeLimit: true,
    restrictedToMinimumLevel: LogEventLevel.Information
    )
   .CreateLogger();

//var log = new LoggerConfiguration()
//    .WriteTo.File("Logs/Log.txt",
//    rollingInterval: RollingInterval.Day,
//    rollOnFileSizeLimit: true,
//    restrictedToMinimumLevel:LogEventLevel.Information)
//    .CreateLogger();

try
{
    Log.Information("Application is starting");
    var connectionString = builder.Configuration.GetConnectionString("AppConnection");
    builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString), ServiceLifetime.Scoped);

    builder.Services.AddControllers().AddNewtonsoftJson(o => 
    o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Host.UseSerilog();
    builder.Services.AddAutoMapper(typeof(AutoMapperInitialization));
    builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

    var app = builder.Build();
    

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI( c=> c.SwaggerEndpoint("/swagger/v1/swagger.json", "GetItFresh v1"));
    }

    app.UseSerilogRequestLogging();

    app.UseHttpsRedirection();

    app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
    app.UseRouting();
    app.UseAuthorization();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });


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
