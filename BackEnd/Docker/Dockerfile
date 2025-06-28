# Stage 1 - Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY . .  

RUN dotnet restore "ErpProdutos.csproj"

RUN dotnet build "ErpProdutos.csproj" -c Release -o /app/build
RUN dotnet publish "ErpProdutos.csproj" -c Release -o /app/publish

# Stage 2 - Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 80

ENTRYPOINT ["dotnet", "ErpProdutos.dll"]
