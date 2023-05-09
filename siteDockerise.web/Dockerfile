FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["siteDockerise.web/siteDockerise.web.csproj", "siteDockerise.web/"]
RUN dotnet restore "siteDockerise.web/siteDockerise.web.csproj"
COPY . .
WORKDIR "/src/siteDockerise.web"
RUN dotnet build "siteDockerise.web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "siteDockerise.web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "siteDockerise.web.dll"]
