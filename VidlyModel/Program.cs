using VidlyModel;
//pRq!Yk1
var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.ConfigurePipeline(app);

app.Run();

