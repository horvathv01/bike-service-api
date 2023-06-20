# Stage 1: Build Stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

COPY . .
RUN dotnet restore

RUN dotnet build -c Release --no-restore

# Stage 2: Runtime Stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS runtime
WORKDIR /app
COPY --from=build /app .

ENV ASPNETCORE_ENVIRONMENT=Production

# Generálja a fejlesztői tanúsítványt és másolja be a konténerbe
RUN dotnet dev-certs https --clean
RUN dotnet dev-certs https --export-path /root/.dotnet/https/aspnetapp.pfx --password examplepassword

# Másolja át a tanúsítványt a helyes helyre
RUN mkdir -p /usr/share/dotnet/sdk/NuGetFallbackFolder
RUN cp /root/.dotnet/https/aspnetapp.pfx /usr/share/dotnet/sdk/NuGetFallbackFolder/aspnetapp.pfx

EXPOSE 7237
EXPOSE 5136

CMD ["dotnet", "run", "--launch-profile", "https"]
