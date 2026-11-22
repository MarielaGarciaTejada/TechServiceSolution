# TechServiceSolution

**Sistema Multiplataforma de Gestión de Órdenes de Reparación, Control de Inventario, Punto de Venta (POS) y Notificaciones en Tiempo Real.**

---

## Integrantes
* **Mariela García Tejada**
* **Luis Enmanuel Burgos Rosa**

---

## Arquitectura del Proyecto (Clean Architecture)

La solución sigue una arquitectura limpia separada por responsabilidades y organizada en proyectos independientes dentro de `TechServiceSolution.slnx`:

| Proyecto | Capa / Rol | Descripción |
| :--- | :--- | :--- |
| **`TechService.Infrastructure`** | Infraestructura | Contiene `TechServiceDbContext`, `DataSeeder` y las entidades de Entity Framework Core mapeadas a SQL Server / Azure SQL. |
| **`TechService.Application`** | Aplicación | Contiene los DTOs (`Dtos/`), interfaces (`Aplicada1.Core.IServiceResult`) y los servicios de negocio (`ClientesService`, `TecnicosService`, `CatalogoService`, `UsuariosService`, `OrdenesReparacionService`, `OrdenRepuestosService`, `HistorialOrdenEventosService`, `VentasService`, `EntregasGarantiaService`, `HubNotificationService`). |
| **`TechService.Api`** | Web API (REST) | Controladores REST, configuración de CORS, Serilog, OpenAPI / Scalar y conexión a base de datos. |
| **`TechService.Hub`** | Tiempo Real (SignalR) | Microservicio con `ReparacionHub` (`/hubs/reparacion`) para chat de órdenes, cambios de estado y alertas en vivo. |
| **`TechService.BlazorClient`** | Cliente Web (Blazor WASM) | Portal web para clientes con consulta de catálogo de tarifas/repuestos (`/catalogo`) y seguimiento en tiempo real de reparaciones (`/tracking`). |
| **`tests/TechService.Application.UnitTests`** | Pruebas Unitarias | Suite de 54 pruebas unitarias con **xUnit** y **EF Core SQLite** en memoria cubriendo los 9 servicios de negocio. |

---

## Tecnologías Utilizadas

* **.NET 10** (`net10.0`)
* **ASP.NET Core Web API** + **Scalar OpenAPI**
* **Blazor WebAssembly** + **Bootstrap 5**
* **SignalR** (notificaciones y chat en tiempo real)
* **Entity Framework Core 10** (SQL Server / Azure SQL Database)
* **xUnit** + **Microsoft.EntityFrameworkCore.Sqlite** (pruebas unitarias aisladas en memoria)
* **Serilog** (registro estructurado de eventos)
* **GitHub Actions** (CI/CD automático para compilación y ejecución de pruebas)

---

## Configuración Inicial (Local)

1. **Clonar el repositorio:**
   ```bash
   git clone https://github.com/MarielaGarciaTejada/TechServiceSolution.git
   cd TechServiceSolution
   ```

2. **Base de Datos:**
   * Puedes ejecutar el script [`TechServiceDB.sql`](./TechServiceDB.sql) en tu instancia de SQL Server / LocalDB o conectarte a Azure SQL Database.
   * Crea un archivo `appsettings.json` en `TechService.Api/` tomando como plantilla [`TechService.Api/appsettings.Example.json`](./TechService.Api/appsettings.Example.json) y coloca tu cadena de conexión en `"AzureSqlConnection"`. *(Los archivos `appsettings.json` están excluidos en `.gitignore` para proteger credenciales).*

3. **Compilar toda la solución:**
   ```bash
   dotnet build TechServiceSolution.slnx
   ```

4. **Ejecutar las pruebas unitarias:**
   ```bash
   dotnet test TechServiceSolution.slnx
   ```

5. **Ejecutar los servicios:**
   ```bash
   # Web API (documentación interactiva en /scalar/v1)
   dotnet run --project TechService.Api/TechService.Api.csproj

   # Hub SignalR
   dotnet run --project TechService.Hub/TechService.Hub.csproj

   # Cliente Web Blazor
   dotnet run --project TechService.BlazorClient/TechService.BlazorClient.csproj
   ```

---

## Integración Continua (CI)

El repositorio incluye el workflow [`.github/workflows/dotnet.yml`](./.github/workflows/dotnet.yml) que en cada `push` o `pull_request` realiza automáticamente:
1. Restauración de dependencias (`dotnet restore TechServiceSolution.slnx`).
2. Compilación en modo `Release` de todos los proyectos.
3. Ejecución de las pruebas unitarias y publicación del reporte `.NET test results`.
