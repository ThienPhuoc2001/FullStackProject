using System.Text.Json;
using api.Etc;
using DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Call ConfigureServices to set up dependency injection
ConfigureServices(builder.Services);
var app = builder.Build();
var appOptions = app.Services.GetRequiredService<AppOptions>();
Console.WriteLine(JsonSerializer.Serialize(appOptions));
app.UseOpenApi();
app.UseSwaggerUi();
app.MapControllers();
app.MapGet("/", () => "API is running!!");
app.GenerateApiClientsFromOpenApi("/../../client/src/models/generated-client.ts").GetAwaiter().GetResult();
app.UseCors(config => config.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().SetIsOriginAllowed(x => true));

app.Run();

public partial class Program
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IGenreService, GenreService>();
        services.AddScoped<IAuthorService, AuthorService>();

        services.AddOpenApiDocument();
        services.AddSingleton<AppOptions>(provider =>
        {
            var config = provider.GetRequiredService<IConfiguration>();
            var appOptions = new AppOptions();
            config.GetSection(nameof(AppOptions)).Bind(appOptions);
            return appOptions;
        });
        services.AddControllers();
        services.AddCors();
    }
}
