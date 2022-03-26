#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Be3Test.Web/Be3Test.Web.csproj", "src/Be3Test.Web/"]
RUN dotnet restore "src/Be3Test.Web/Be3Test.Web.csproj"
COPY . .
WORKDIR "/src/src/Be3Test.Web"
RUN dotnet build "Be3Test.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Be3Test.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Be3Test.Web.dll"]