# Docker

Créer une nouvelle solution :

```jsx
dotnet new sln
```

Créer une projet minimal api :

```jsx
dotnet new web -o siteDockerise.web
```

Ajout dans la solution :

```jsx
dotnet sln add .\[siteDockerise.web](http://sitedockerise.web/)\siteDockerise.web.csproj
```

Publier l’api :

```jsx
dotnet publish -c Release
```

Créer un docker file dans le répertoire de l’API

```jsx
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish -o /app/published-app

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=build /app/published-app /app
ENTRYPOINT ["dotnet", "siteDockerise.web.dll"]
```

Se mettre dans le répertoire de l’API

Builder l’image docker :

```jsx
docker build . -t sitedockerise -f .\siteDockerise.web\Dockerfile
```

Executer le  container :

```jsx
docker run -it --rm --name sitedockerise -p 8081:80 -d sitedockerise
```

Ouvrir le navigateur sur : [http://localhost:8081/](http://localhost:8081/)

Liens :

[https://learn.microsoft.com/fr-fr/dotnet/core/docker/build-container?tabs=windows](https://learn.microsoft.com/fr-fr/dotnet/core/docker/build-container?tabs=windows)

[https://dev.to/berviantoleo/web-api-in-net-6-docker-41d5](https://dev.to/berviantoleo/web-api-in-net-6-docker-41d5)