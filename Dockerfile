FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /app

# Copy the project file
COPY *.sln ./
COPY DockService.App/*.csproj ./DockService.App/
COPY DockService.Core/*.csproj ./DockService.Core/
COPY DockService.Infrastructure/*.csproj ./DockService.Infrastructure/


# Restore the packages
RUN dotnet restore

# Copy everything else
COPY . ./
WORKDIR /app/DockService.App

FROM build AS publish
# Build the release
RUN dotnet publish -c Release -o out

# Build the runtime image
FROM microsoft/aspnetcore:2.0 AS runtime
WORKDIR /app

# Copy the output from the build env
COPY --from=publish /app/DockService.App/out ./

EXPOSE 5000

ENTRYPOINT [ "dotnet", "DockService.App.dll" ]