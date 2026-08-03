# Digital Services BD

Digital Services BD is an ASP.NET Core MVC e-commerce-style platform for selling digital products and bundled service items, with account management, cart/checkout, order workflows, admin management, search, and payment gateway integration.

## Current Stack

- **Backend:** ASP.NET Core MVC on **.NET 10**
- **ORM/Data:** Entity Framework Core (SQL Server)
- **Auth:** ASP.NET Core Identity
- **UI:** Razor Views + Bootstrap **5.3.3** (+ compatibility layer for legacy Bootstrap 4-style attributes/classes)
- **Client libs:** LibMan-managed assets under `wwwroot/lib`
- **Logging:** NLog
- **PDF:** Rotativa + wkhtmltopdf runtime assets

## Solution Architecture

The project follows a layered, MVC-centric architecture:

- `Controllers/`  
  HTTP endpoints and request orchestration.
- `Services/`  
  Business/use-case services (cart, orders, catalog ops, payment transaction ops, search, email, encryption, gateway clients).
- `Models/`  
  Domain entities, EF Core model configuration, identity entities.
- `ViewModels/`  
  View-specific DTOs and request/response models.
- `Views/`  
  Razor UI for storefront, account, admin, and shared layouts.
- `Utilities/`  
  Cross-cutting helpers, custom attributes, policy/assertion helpers, filters.
- `Resources/`  
  Localization resources.
- `wwwroot/`  
  Static assets (CSS/JS/images/libman libraries).

## Request Pipeline and Platform Behavior

Configured in `Startup.cs` and `Program.cs`:

- SQL Server context registration with pooling (`AppDbContext`)
- ASP.NET Identity with token providers and cookie policy
- Localization support (`en-US`, `bn-BD`)
- Authorization policy: `AdminFullAccess`
- Data protection keys persisted in DB
- Rotativa setup for PDF generation
- Production middleware hardening:
  - exception handler route (`/Home/Error`)
  - HSTS + HTTPS redirection

## Prerequisites

- .NET SDK **10.x**
- SQL Server instance
- Git

## Local Development Setup

1. Clone and restore:
   ```bash
   dotnet restore "Digital Services BD.csproj"
   ```
2. Restore client libraries:
   ```bash
   dotnet tool restore
   dotnet libman restore
   ```
3. Configure secrets/settings (recommended via environment variables or user secrets; avoid hardcoding secrets in committed files):
   - `ConnectionStrings__SqlServerConn`
   - `SeedIdentity__Admin__UserName`
   - `SeedIdentity__Admin__Email`
   - `SeedIdentity__Admin__Password`
   - `Encryption__Key`
   - Payment/email provider sections as needed
4. Apply migrations:
   ```bash
   dotnet ef database update
   ```
5. Run:
   ```bash
   dotnet run --project "Digital Services BD.csproj"
   ```

## Build

```bash
dotnet build "Digital Services BD.csproj" -c Release
```

## Database and Identity Notes

- On startup, admin identity seeding is performed by `IdentitySeedData.CreateAdminEntries(...)`.
- Ensure seed credentials are provided securely per environment.

## Frontend Notes (Bootstrap 5 Migration)

- Layouts now reference Bootstrap 5.
- Compatibility helpers are intentionally included:
  - `wwwroot/js/site.js` (legacy `data-toggle/data-target/...` bridging)
  - `wwwroot/css/bootstrap4-compat.css` (legacy utility aliases)
- This preserves existing UI behavior while allowing gradual modernization of legacy markup.

## CI/CD: Azure DevOps Pipeline

Pipeline file: `azure-pipelines.yml`

### Stages

1. **Build**
   - Install .NET SDK
   - Restore, Build, Publish
   - Publish artifact (`drop`)
2. **Deploy**
   - Download build artifact
   - Deploy ZIP package to Azure App Service via `AzureWebApp@1`

### Required Pipeline Variable Updates

Set these in Azure DevOps before deployment:

- `azureSubscription`: Azure service connection name
- `appName`: Azure Web App name

## Deployment Targets

The current pipeline deploys to **Azure App Service**. If Azure Cloud Services (classic/extended support) is required, replace deploy tasks with the appropriate packaging/deployment tasks for that hosting model.

## Security and Operations Recommendations

- Move all credentials and secret keys to secret stores (Azure Key Vault / pipeline secret variables / user secrets for local).
- Keep `appsettings*.json` environment-safe and non-sensitive.
- Restrict production IP safelists and payment callbacks to trusted ranges only.

## Repository Hygiene

- `.editorconfig` enforces consistent formatting for C#, Razor/HTML, JSON/YAML/XML.
- `.gitignore` includes modern .NET/IDE/build/test artifacts.

