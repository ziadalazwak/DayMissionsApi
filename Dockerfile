# Step 1: Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything
COPY . ./

# Publish the correct project
RUN dotnet publish DayMissions.App/DayMissions.App.csproj -c Release -o /app

# Step 2: Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy published output
COPY --from=build /app ./

# Expose port 8080 (used by Railway)
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# Run the app
ENTRYPOINT ["dotnet", "DayMissions.api.dll"]
