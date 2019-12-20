FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
EXPOSE 5000-5001
WORKDIR /build

COPY TesteDocker.sln .
COPY src/TesteDocker/TesteDocker.csproj src/TesteDocker/
COPY src/TesteDocker.Data/TesteDocker.Data.csproj src/TesteDocker.Data/
COPY src/TesteDocker.Data.Abstractions/TesteDocker.Data.Abstractions.csproj src/TesteDocker.Data.Abstractions/
RUN dotnet restore src/TesteDocker/TesteDocker.csproj

COPY . .
WORKDIR /build/src/TesteDocker
RUN dotnet build

FROM build as publish
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app/

COPY --from=publish /app .

ENTRYPOINT ["dotnet", "TesteDocker.dll"]
# docker build -t customersapi:1.0 . # Faz o build da imagem docker e atribui a tag
# docker run -d -p 8080:80 --name customersapi customersapi:1.0 # Roda a imagem 