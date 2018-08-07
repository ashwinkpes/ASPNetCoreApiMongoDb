# Mongo ASP.Net Core API

ASP.Net Core 2.1 Web API using MongoDB with repository pattern.

## Requirements

> .Net Core SDK 2.1
>
> A MongoDb database (Connection string and database name in `appsettings.json`)

## Build

| AppVeyor |
| --- |
| [![Build status](https://ci.appveyor.com/api/projects/status/7yidyghyl4gv7a41?svg=true)](https://ci.appveyor.com/project/Flysenberg/aspnetcoreapimongodb) |

> This project uses the new `async Main(string[] args)` entrypoint in C# 7.3

```powershell
> dotnet restore .\MongoDB\MongoDB.csproj
> dotnet build -c Release
```

## Run

> This API runs on Kestrel server

Also make sure to have a MongoDb database running, recommend using the official `Docker` container, which is what this project was tested with.

Docker container:

```powershell
> docker run -p 21017:21017 mongo
```

Make sure to edit the connection string and database name in `appsettings.json` with your information.

Program:

```powershell
> dotnet run MongoDB.dll
```

## License

MIT
