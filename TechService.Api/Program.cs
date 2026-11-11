using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Serilog;
using TechService.Infrastructure.Data;
using TechService.Application.Services;

// Configuración de Bootstrap para Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Integrar Serilog como motor de logging
    builder.Host.UseSerilog((context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
        .WriteTo.Console());

    // Configuración de CORS
    const string CorsPolicy = "TechServiceCorsPolicy";
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(CorsPolicy, policy =>
        {
            policy.WithOrigins(
                    "https://localhost:7093",
                    "http://localhost:5047",
                    "https://localhost:7290",
                    "https://localhost:7183",
                    "http://localhost:5081",
                    "http://localhost:5163",
                    "https://techserviceapi-g0a4h6daeghqg9fv.westus3-01.azurewebsites.net",
                    "https://techservicehub-fgg2bjheghfmarhw.westus3-01.azurewebsites.net",
                    "https://techserviceblazorclient-gah0gpdgdjbef0gz.westus3-01.azurewebsites.net"
                )
                .SetIsOriginAllowed(_ => true)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
    });

    // Base de Datos: DbContext y DbContextFactory con Azure SQL Database
    var connectionString = builder.Configuration.GetConnectionString("AzureSqlConnection")
        ?? builder.Configuration["AzureSqlConnection"]
        ?? builder.Configuration["ConnectionStrings:AzureSqlConnection"]
        ?? throw new InvalidOperationException("No se encontró la cadena de conexión 'AzureSqlConnection' en la configuración.");

    builder.Services.AddDbContextFactory<TechServiceDbContext>(options =>
        options.UseSqlServer(connectionString));
    builder.Services.AddScoped(sp => sp.GetRequiredService<IDbContextFactory<TechServiceDbContext>>().CreateDbContext());

    // Inyección de Dependencias de los Servicios
    builder.Services.AddScoped<ClientesService>();
    builder.Services.AddScoped<TecnicosService>();
    builder.Services.AddScoped<CatalogoService>();
    builder.Services.AddScoped<OrdenesReparacionService>();
    builder.Services.AddScoped<OrdenRepuestosService>();
    builder.Services.AddScoped<HistorialOrdenEventosService>();
    //builder.Services.AddScoped<EntregasGarantiaService>();
    //builder.Services.AddScoped<VentasService>();
    builder.Services.AddScoped<UsuariosService>();

    // Servicio de Notificaciones hacia TechService.Hub
    builder.Services.AddHttpClient<IHubNotificationService, HubNotificationService>();

    // Controladores
    builder.Services.AddControllers(options =>
    {
        options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
    })
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler =
                System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.DefaultIgnoreCondition =
                System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
        });

    // Configuración OpenAPI para Scalar
    builder.Services.AddOpenApi();

    var app = builder.Build();

    // Sembrar datos de prueba si la BD está vacía
    try
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<TechServiceDbContext>();
        await DataSeeder.SeedAsync(db);
    }
    catch (Exception ex)
    {
        Log.Warning(ex, "Aviso: No se pudo conectar a la base de datos durante el inicio o el seeder: {Message}", ex.Message);
    }

    // Middleware de Serilog para auditar peticiones HTTP
    app.UseSerilogRequestLogging();

    // Documentación con Scalar
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.WithTitle("TechService API - Sistema de Reparaciones & POS")
               .WithTheme(ScalarTheme.Moon);
    });

    // Redirigir la raíz hacia Scalar
    app.MapGet("/", () => Results.Redirect("/scalar/v1")).ExcludeFromDescription();

    app.UseHttpsRedirection();

    // Aplicar CORS
    app.UseCors(CorsPolicy);

    app.UseAuthorization();

    // Mapeo de Controladores
    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Fallo crítico al iniciar la aplicación TechService.Api");
}
finally
{
    Log.CloseAndFlush();
}
