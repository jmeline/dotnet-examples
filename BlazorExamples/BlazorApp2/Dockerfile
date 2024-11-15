FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy-arm64v8 AS base
# FROM drivetimedevtest.azurecr.io/dotnetaspnet:8.0-jammy AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["/BlazorApp2.csproj", "."]
RUN dotnet restore "BlazorApp2.csproj"

COPY . .
RUN dotnet build "BlazorApp2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorApp2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ["dotnet", "BlazorApp2.dll"]
