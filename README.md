# URL Shortener

A small URL shortener built with ASP.NET Core minimal APIs, EF Core and SQL Server. It was a practice project for learning ASP.NET Core, based on Milan Jovanović's URL shortener tutorial.

## Features

- `POST /api/shorten` takes a long URL and returns a short link
- `GET /api/{code}` redirects to the original URL, or returns `404` if the code doesn't exist
- Rejects invalid URLs with a `400`
- Generates unique 7-character codes and checks the database to avoid duplicates
- Swagger UI for testing the API

## Tech stack

- .NET 10, ASP.NET Core minimal APIs
- Entity Framework Core with SQL Server
- Swagger (Swashbuckle)

## Getting started

### Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server or SQL Server LocalDB

### Run it

1. Clone the repo:
   ```
   git clone https://github.com/ananhany238/UrlShortenerApi
   ```
2. Check the connection string in `appsettings.json` under `ConnectionStrings:Database`. The default uses LocalDB. Change the server name if you use another SQL Server instance.
3. Run the app:
   ```
   dotnet run
   ```
   In Development, the database migrations are applied automatically on startup.
4. Open Swagger at `https://localhost:7152/swagger`.

## Usage

Send a request to shorten a URL:

```
POST /api/shorten
Content-Type: application/json

{
  "url": "https://example.com/some/very/long/path"
}
```

The response is a short link such as `https://localhost:7152/api/aB3xY9z`. Opening it redirects to the original URL.

## Roadmap

- [ ] Only allow `http` and `https` URLs
- [ ] Click counter
- [ ] Caching for frequent lookups
