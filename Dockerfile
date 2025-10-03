# Stage 1: Build the application
# We use the .NET 9.0 SDK image which contains all the tools to build the app.
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies first.
# This leverages Docker's layer caching. If the project file doesn't change,
# Docker won't re-download the dependencies on subsequent builds.
COPY ["ApplicationInterface/ApplicationInterface.csproj", "ApplicationInterface/"]
RUN dotnet restore "ApplicationInterface/ApplicationInterface.csproj"

# Copy the rest of the source code
COPY . .
WORKDIR "/src/ApplicationInterface"

# Build and publish the application for release.
RUN dotnet publish "ApplicationInterface.csproj" -c Release -o /app/publish --no-restore

# Stage 2: Create the final, smaller runtime image
# We use the ASP.NET runtime image which is optimized for running the app.
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /app/publish .

# The default ASP.NET Core port is 8080. We expose it here.
EXPOSE 8080

# Set the entry point for the container to run the application
ENTRYPOINT ["dotnet", "ApplicationInterface.dll"]