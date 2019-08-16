FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

EXPOSE 5000

# Copy csproj and restore as distinct layers
COPY *.sln ./
COPY ScrumEstimationTool/*.csproj ./ScrumEstimationTool/
RUN dotnet restore

# Copy everything else and build
COPY . ./
WORKDIR /app/ScrumEstimationTool
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
COPY --from=build-env /app/ScrumEstimationTool/out .
ENV ASPNETCORE_URLS http://+:5000
ENTRYPOINT ["dotnet", "ScrumEstimationTool.dll"]