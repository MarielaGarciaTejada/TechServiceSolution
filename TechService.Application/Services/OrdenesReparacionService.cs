using System.Linq.Expressions;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using TechService.Application.Dtos;
using TechService.Infrastructure.Data;
using TechService.Infrastructure.Models;

namespace TechService.Application.Services;

public class OrdenesReparacionService(
    IDbContextFactory<TechServiceDbContext> contextFactory
) : IServiceResult<OrdenDto, int>
{
    public async Task<Result> Guardar(OrdenDto orden)
    {
        if (!await Existe(orden.OrdenId))
        {
            var inserto = await Insertar(orden);
            return Result.Success(inserto);
        }
        else
        {
            var modifico = await Modificar(orden);
            return Result.Success(modifico);
        }
    }

    public async Task<bool> Existe(int ordenId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.OrdenesReparacions.AnyAsync(o => o.OrdenId == ordenId);
    }

    public async Task<bool> Insertar(OrdenDto orden)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();

        if (string.IsNullOrWhiteSpace(orden.CodigoTracking))
        {
            orden.CodigoTracking = "ORD-" + Guid.NewGuid().ToString("N")[..8].ToUpper();
        }

        var entidad = new OrdenesReparacion
        {
            CodigoTracking = orden.CodigoTracking,
            ClienteId = orden.ClienteId,
            TecnicoId = orden.TecnicoId,
            TipoEquipoId = orden.TipoEquipoId,
            EstadoId = orden.EstadoId,
            PrioridadId = orden.PrioridadId,
            MarcaModelo = orden.MarcaModelo,
            NumeroSerieImei = orden.NumeroSerieImei,
            PinDesbloqueo = orden.PinDesbloqueo,
            IngresoEnciende = orden.IngresoEnciende,
            IngresoPantallaRota = orden.IngresoPantallaRota,
            IngresoMojado = orden.IngresoMojado,
            IngresoDejaCargador = orden.IngresoDejaCargador,
            FalloReportado = orden.FalloReportado,
            FechaIngreso = orden.FechaIngreso ?? DateTime.UtcNow,
            FechaEntregaEstimada = orden.FechaEntregaEstimada,
            CheckRevisionPlaca = orden.CheckRevisionPlaca,
            CheckCambioPieza = orden.CheckCambioPieza,
            CheckPruebasEncendido = orden.CheckPruebasEncendido,
            ObservacionTecnico = orden.ObservacionTecnico,
            CostoManoObra = orden.CostoManoObra,
            PresupuestoAprobadoCliente = orden.PresupuestoAprobadoCliente
        };

        contexto.OrdenesReparacions.Add(entidad);
        var guardo = await contexto.SaveChangesAsync() > 0;
        orden.OrdenId = entidad.OrdenId;
        return guardo;
    }

    public async Task<bool> Modificar(OrdenDto orden)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var entidad = await contexto.OrdenesReparacions.FindAsync(orden.OrdenId);
        if (entidad == null) return false;

        entidad.ClienteId = orden.ClienteId;
        entidad.TecnicoId = orden.TecnicoId;
        entidad.TipoEquipoId = orden.TipoEquipoId;
        entidad.EstadoId = orden.EstadoId;
        entidad.PrioridadId = orden.PrioridadId;
        entidad.MarcaModelo = orden.MarcaModelo;
        entidad.NumeroSerieImei = orden.NumeroSerieImei;
        entidad.PinDesbloqueo = orden.PinDesbloqueo;
        entidad.IngresoEnciende = orden.IngresoEnciende;
        entidad.IngresoPantallaRota = orden.IngresoPantallaRota;
        entidad.IngresoMojado = orden.IngresoMojado;
        entidad.IngresoDejaCargador = orden.IngresoDejaCargador;
        entidad.FalloReportado = orden.FalloReportado;
        entidad.FechaEntregaEstimada = orden.FechaEntregaEstimada;
        entidad.CheckRevisionPlaca = orden.CheckRevisionPlaca;
        entidad.CheckCambioPieza = orden.CheckCambioPieza;
        entidad.CheckPruebasEncendido = orden.CheckPruebasEncendido;
        entidad.ObservacionTecnico = orden.ObservacionTecnico;
        entidad.CostoManoObra = orden.CostoManoObra;
        entidad.PresupuestoAprobadoCliente = orden.PresupuestoAprobadoCliente;

        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Result<OrdenDto?>> Buscar(int ordenId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var orden = await contexto.OrdenesReparacions
            .Where(o => o.OrdenId == ordenId)
            .Select(o => new OrdenDto
            {
                OrdenId = o.OrdenId,
                CodigoTracking = o.CodigoTracking,
                ClienteId = o.ClienteId,
                ClienteNombre = o.Cliente != null ? o.Cliente.Nombre : null,
                ClienteTelefono = o.Cliente != null ? o.Cliente.Telefono : null,
                TecnicoId = o.TecnicoId,
                TecnicoNombre = o.Tecnico != null ? o.Tecnico.Nombre : null,
                TipoEquipoId = o.TipoEquipoId,
                TipoEquipoNombre = o.TipoEquipo != null ? o.TipoEquipo.Nombre : "",
                EstadoId = o.EstadoId,
                EstadoNombre = o.Estado != null ? o.Estado.Nombre : "",
                PrioridadId = o.PrioridadId,
                PrioridadNombre = o.Prioridad != null ? o.Prioridad.Nombre : "",
                MarcaModelo = o.MarcaModelo,
                NumeroSerieImei = o.NumeroSerieImei,
                PinDesbloqueo = o.PinDesbloqueo,
                IngresoEnciende = o.IngresoEnciende,
                IngresoPantallaRota = o.IngresoPantallaRota,
                IngresoMojado = o.IngresoMojado,
                IngresoDejaCargador = o.IngresoDejaCargador,
                FalloReportado = o.FalloReportado,
                FechaIngreso = o.FechaIngreso,
                FechaEntregaEstimada = o.FechaEntregaEstimada,
                CheckRevisionPlaca = o.CheckRevisionPlaca,
                CheckCambioPieza = o.CheckCambioPieza,
                CheckPruebasEncendido = o.CheckPruebasEncendido,
                ObservacionTecnico = o.ObservacionTecnico,
                CostoManoObra = o.CostoManoObra,
                PresupuestoAprobadoCliente = o.PresupuestoAprobadoCliente
            })
            .FirstOrDefaultAsync();

        return orden;
    }

    public async Task<Result<List<OrdenDto>>> GetList(Expression<Func<OrdenDto, bool>> criterio)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.OrdenesReparacions
            .Select(o => new OrdenDto
            {
                OrdenId = o.OrdenId,
                CodigoTracking = o.CodigoTracking,
                ClienteId = o.ClienteId,
                ClienteNombre = o.Cliente != null ? o.Cliente.Nombre : null,
                ClienteTelefono = o.Cliente != null ? o.Cliente.Telefono : null,
                TecnicoId = o.TecnicoId,
                TecnicoNombre = o.Tecnico != null ? o.Tecnico.Nombre : null,
                TipoEquipoId = o.TipoEquipoId,
                TipoEquipoNombre = o.TipoEquipo != null ? o.TipoEquipo.Nombre : "",
                EstadoId = o.EstadoId,
                EstadoNombre = o.Estado != null ? o.Estado.Nombre : "",
                PrioridadId = o.PrioridadId,
                PrioridadNombre = o.Prioridad != null ? o.Prioridad.Nombre : "",
                MarcaModelo = o.MarcaModelo,
                NumeroSerieImei = o.NumeroSerieImei,
                PinDesbloqueo = o.PinDesbloqueo,
                IngresoEnciende = o.IngresoEnciende,
                IngresoPantallaRota = o.IngresoPantallaRota,
                IngresoMojado = o.IngresoMojado,
                IngresoDejaCargador = o.IngresoDejaCargador,
                FalloReportado = o.FalloReportado,
                FechaIngreso = o.FechaIngreso,
                FechaEntregaEstimada = o.FechaEntregaEstimada,
                CheckRevisionPlaca = o.CheckRevisionPlaca,
                CheckCambioPieza = o.CheckCambioPieza,
                CheckPruebasEncendido = o.CheckPruebasEncendido,
                ObservacionTecnico = o.ObservacionTecnico,
                CostoManoObra = o.CostoManoObra,
                PresupuestoAprobadoCliente = o.PresupuestoAprobadoCliente
            })
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<Result> Eliminar(int ordenId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var eliminado = await contexto.OrdenesReparacions
            .Where(o => o.OrdenId == ordenId)
            .ExecuteDeleteAsync() > 0;
        return Result.Success(eliminado);
    }

    public async Task<List<OrdenDto>> Listar(Expression<Func<OrdenDto, bool>> criterio)
    {
        var result = await GetList(criterio);
        return result.Value ?? [];
    }

    public async Task<List<OrdenDto>> GetList()
    {
        var result = await GetList(o => true);
        return result.Value ?? [];
    }
}
