# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia os arquivos do projeto e restaura dependências
COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Instala o cliente do PostgreSQL para usar pg_isready
RUN apt-get update && apt-get install -y postgresql-client && rm -rf /var/lib/apt/lists/*

COPY --from=build /app/out ./
COPY wait-for-postgres.sh ./

RUN chmod +x wait-for-postgres.sh

# Executa o script antes de iniciar a aplicação
ENTRYPOINT ["./wait-for-postgres.sh"]
CMD ["dotnet", "WebApplication1.dll"]


