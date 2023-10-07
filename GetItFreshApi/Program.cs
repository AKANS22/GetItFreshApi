using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Log.Logger = new LoggerConfiguration()
//    .WriteTo.File(path: "C:\\winks\\GetItFreshApi\\GetItFreshApi\\Log\\Log.txt")
//    .CreateLogger();

var log = new LoggerConfiguration()
    .WriteTo.File("Logs/Log.txt",
    rollingInterval: RollingInterval.Day,
    rollOnFileSizeLimit: true)
    .CreateLogger();

try
{
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


}
catch (Exception ex)
{

    Log.Fatal(ex, "Application failed to start");
}
finally
{
    Log.CloseAndFlush();
}
