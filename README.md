# User Auth API

An ASP.NET Core 8 REST Web API for user authentication and account management. It uses ASP.NET Core Identity for user handling and issues JWT bearer tokens on login, backed by a PostgreSQL database through Entity Framework Core.

## Tech stack

- C# and .NET 8 (ASP.NET Core Web API)
- ASP.NET Core Identity for user registration, password management and validation
- JWT bearer authentication (Microsoft.AspNetCore.Authentication.JwtBearer)
- Entity Framework Core 8 with the Npgsql provider for PostgreSQL
- Swashbuckle (Swagger / OpenAPI) for interactive API documentation
- CORS configured to allow any origin, method and header

## What it does

The API exposes an `AccountController` under the `api/Account` route with the following endpoints:

Authentication and accounts:
- `POST /api/Account/register` creates a new Identity user from a name, email and password.
- `POST /api/Account/login` validates credentials and returns a signed JWT on success.
- `POST /api/Account/change-password` changes the current user password. Requires a valid bearer token.
- `POST /api/Account/auth-token` returns a confirmation that the caller is authorized. Requires a valid bearer token.

Metrics:
- `GET /api/Account/get-metrics` returns the stored metrics records.
- `POST /api/Account/post-metrics` creates a new metrics record.

Orders:
- `GET /api/Account/get-orders` returns orders that are not marked as inactive.
- `POST /api/Account/post-orders` creates a new order.
- `PUT /api/Account/put-orders` marks an existing order as inactive by id.

Tokens are signed with HMAC SHA-512 and expire five minutes after issue.

## Data layer

`UserDbContext` extends `IdentityDbContext<IdentityUser>` and adds two application tables:

- `Metrics` (orders count, total, stock, users)
- `Orders` (value, date, payment method, status)

Initial `Metrics` and `Orders` rows are seeded through EF Core `HasData` in `OnModelCreating`. The included migrations create the Identity schema and these tables.

## Running locally

Requirements: the .NET 8 SDK and a running PostgreSQL instance.

Clone the repository:

```bash
git clone https://github.com/nicolasfvp/user-auth-api.git
cd user-auth-api
```

Configure the database connection and JWT settings in `appsettings.json`. The `ConnectionStrings:DefaultConnection` value points at a local PostgreSQL database, and the `Jwt` section holds the issuer, audience and signing key. Update these before running.

Restore packages, apply the migrations and start the API:

```bash
dotnet restore
dotnet ef database update
dotnet run
```

Applying migrations with `dotnet ef` requires the EF Core tools. Install them if needed:

```bash
dotnet tool install --global dotnet-ef
```

When running in the Development environment, Swagger UI is served at the application root (for example `http://localhost:5000`) so you can explore and call the endpoints.

## Project structure

```
Program.cs           Application startup, service and middleware configuration
Controllers/         AccountController with the auth, metrics and orders endpoints
Models/              Request and entity models (User, LoginModel, Orders, Metrics, ...)
Context/             UserDbContext (EF Core Identity DbContext and seed data)
Migrations/          EF Core migrations for the Identity and application schema
appsettings.json     Connection string and JWT configuration
```

## Status

Personal study project built to practice ASP.NET Core Identity, JWT authentication and Entity Framework Core with PostgreSQL. The sample credentials and signing key in `appsettings.json` are for local development only and should not be used in production.

## License

Released under the MIT License. See the [LICENSE](LICENSE) file.
