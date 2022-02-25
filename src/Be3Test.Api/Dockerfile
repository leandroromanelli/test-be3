#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Be3Test.Api/Be3Test.Api.csproj", "src/Be3Test.Api/"]
COPY ["src/Be3Test.Domain/Be3Test.Domain.csproj", "src/Be3Test.Domain/"]
COPY ["src/Be3Test.Infra/Be3Test.Infra.csproj", "src/Be3Test.Infra/"]
RUN dotnet restore "src/Be3Test.Api/Be3Test.Api.csproj"
COPY . .
WORKDIR "/src/src/Be3Test.Api"
RUN dotnet build "Be3Test.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Be3Test.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Be3Test.Api.dll"]