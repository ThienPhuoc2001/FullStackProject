

using System.Text.Json;
using api.Etc;
using DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddOpenApiDocument();
builder.Services.AddSingleton<AppOptions>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var appOptions = new AppOptions();
    configuration.GetSection(nameof(AppOptions)).Bind(appOptions);
    return appOptions;
});
builder.Services.AddControllers();
builder.Services.AddCors();


var app = builder.Build();
var appOptions = app.Services.GetRequiredService<AppOptions>();
Console.WriteLine(JsonSerializer.Serialize(appOptions));
app.UseOpenApi();
app.UseSwaggerUi();
app.MapControllers();
app.MapGet("/", () => "Hello World!");
app.GenerateApiClientsFromOpenApi("/../../client/src/models/generated-client.ts").GetAwaiter().GetResult();
app.UseCors(config => config.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().SetIsOriginAllowed(x => true));

app.Run();
