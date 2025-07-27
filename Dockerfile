# Step 1: Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything from the repo into the Docker build
COPY . .

# Publish your .NET project to the /app folder
RUN dotnet publish DayMissions.App/DayMissions.App.csproj -c Release -o /app

# Step 2: Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy the published app from the build stage
COPY --from=build /app ./

# Expose port 8080 (Railway default)
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# Start the app - update this if the DLL name is different!
ENTRYPOINT ["dotnet", "DayMissions.App.dll"]
