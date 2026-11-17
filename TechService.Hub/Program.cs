using Microsoft.AspNetCore.SignalR;
using TechService.Hub.Hubs;
using TechService.Application.Dtos;

var builder = WebApplication.CreateBuilder(args);

// Configurar SignalR
builder.Services.AddSignalR();

// Habilitar CORS para permitir llamadas de WinForms, Blazor y API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins(
                  "https://techserviceapi-g0a4h6daeghqg9fv.westus3-01.azurewebsites.net",
                  "https://techserviceblazorclient-gah0gpdgdjbef0gz.westus3-01.azurewebsites.net",
                  "https://techservicehub-fgg2bjheghfmarhw.westus3-01.azurewebsites.net",
                  "http://localhost:5034",
                  "http://localhost:5081",
                  "https://localhost:7183",
                  "https://localhost:7093"
              )
              .SetIsOriginAllowed(_ => true)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

// Endpoint informativo
app.MapGet("/", () => "TechService SignalR Hub activo en puerto 5035");

// Mapear el Hub de SignalR
app.MapHub<ReparacionHub>("/hubs/reparacion");

// ==========================================
// Endpoints de difusión para la API / microservicios
// ==========================================

app.MapPost("/api/notificaciones/alerta-caja", async (IHubContext<ReparacionHub> hub, AlertaCajaDto alerta) =>
{
    await hub.Clients.Group("SalaCaja").SendAsync("RecibirAlertaCaja", alerta);
    return Results.Ok(new { status = "Alerta emitida a SalaCaja" });
});

app.MapPost("/api/notificaciones/cambio-estado", async (IHubContext<ReparacionHub> hub, CambioEstadoOrdenDto cambio) =>
{
    await hub.Clients.Group($"Orden-{cambio.CodigoTracking}").SendAsync("OrdenEstadoActualizado", cambio);
    await hub.Clients.Group("SalaCaja").SendAsync("OrdenEstadoActualizado", cambio);
    return Results.Ok(new { status = "Cambio de estado emitido" });
});

app.MapPost("/api/notificaciones/nueva-orden", async (IHubContext<ReparacionHub> hub, NuevaOrdenDto orden) =>
{
    await hub.Clients.Group("SalaTecnicos").SendAsync("NuevaOrdenIngresada", orden);
    return Results.Ok(new { status = "Nueva orden emitida a SalaTecnicos" });
});

app.MapPost("/api/notificaciones/mensaje-chat", async (IHubContext<ReparacionHub> hub, MensajeChatDto mensaje) =>
{
    await hub.Clients.Group($"Orden-{mensaje.CodigoTracking}").SendAsync("RecibirMensajeOrden", mensaje);
    return Results.Ok(new { status = "Mensaje emitido a orden" });
});

app.Run();
