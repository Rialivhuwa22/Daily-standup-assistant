using OpenAI.Extensions;

using server.Services;

var builder = WebApplication.CreateBuilder(args);


// Load configuration (e.g., OpenAI key from appsettings.Development.json)
builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

// Register OpenAI service
builder.Services.AddOpenAIService(options =>
{
    options.ApiKey = builder.Configuration["OpenAI:ApiKey"];
});
builder.Services.AddScoped<ParaphrasingServices>();

// Register your controllers
builder.Services.AddControllers();

// Enable CORS (for frontend like React)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000") // 🔁 Match your frontend port
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseRouting();
app.UseCors();
app.UseAuthorization();
app.MapControllers(); // This maps all controllers like ReportController

app.Run();
Console.WriteLine("OpenAI Key: " + builder.Configuration["OpenAI:ApiKey"]);

