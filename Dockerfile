FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

COPY . .
RUN dotnet restore

RUN dotnet build -c Release --no-restore

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS runtime
WORKDIR /app
COPY --from=build /app .

ENV ASPNETCORE_ENVIRONMENT=Production

EXPOSE 7237
EXPOSE 5136

CMD ["dotnet", "BikeServiceAPI.dll"]
