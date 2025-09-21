# Use the .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build
WORKDIR /server/Dockerfile
COPY ["./", "."]
# Publish the application as a framework-dependent app.
# This is more standard for containerized .NET apps and avoids issues with self-contained executables.
RUN dotnet publish "api/api.csproj" \
    -c Release \
    -o /app/publish

# Use the ASP.NET runtime image for the final stage.
# This image includes the necessary .NET runtime to run the application.
FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080

# The entry point is the dotnet runtime, which will execute the application's DLL.
ENTRYPOINT ["dotnet", "api.dll"]
