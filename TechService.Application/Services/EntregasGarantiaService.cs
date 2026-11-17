using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TechService.Infrastructure.Data;
using TechService.Infrastructure.Models;
using TechService.Application.Dtos;

namespace TechService.Application.Services;

public class EntregasGarantiaService(
    IDbContextFactory<TechServiceDbContext> contextFactory
) : IServiceResult<EntregaGarantiaDto, int>
{
    public async Task<Result> Guardar(EntregaGarantiaDto entrega)
    {
        if (!await Existe(entrega.EntregaId))
        {
            var inserto = await Insertar(entrega);
            return Result.Success(inserto);
        }
        else
        {
            var modifico = await Modificar(entrega);
            return Result.Success(modifico);
        }
    }

    public async Task<bool> Existe(int entregaId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.EntregasGarantia
            .AnyAsync(e => e.EntregaId == entregaId);
    }

    public async Task<bool> Insertar(EntregaGarantiaDto entrega)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();

        var orden = await contexto.OrdenesReparacions
            .FirstOrDefaultAsync(o => o.OrdenId == entrega.OrdenId);
        if (orden == null) return false;

        var metodoPagoId = entrega.MetodoPagoId;
        if (metodoPagoId <= 0)
        {
            metodoPagoId = await contexto.MetodosPagos
                .Select(m => m.MetodoPagoId)
                .FirstOrDefaultAsync();
            if (metodoPagoId == 0) return false;
        }

        var manoObra = entrega.TotalManoObra > 0 ? entrega.TotalManoObra : orden.CostoManoObra;
        var repuesto = entrega.TotalRepuesto;
        var cobrado = entrega.TotalCobrado > 0 ? entrega.TotalCobrado : (manoObra + repuesto);

        var entidad = new EntregasGarantia
        {
            OrdenId = entrega.OrdenId,
            MetodoPagoId = metodoPagoId,
            FechaEntrega = entrega.FechaEntrega ?? DateTime.UtcNow,
            DiaGarantia = entrega.DiaGarantia > 0 ? entrega.DiaGarantia : 30,
            TotalManoObra = manoObra,
            TotalRepuesto = repuesto,
            TotalCobrado = cobrado,
            ObservacionFinal = entrega.ObservacionFinal ?? string.Empty
        };

        contexto.EntregasGarantia.Add(entidad);
        var guardo = await contexto.SaveChangesAsync() > 0;
        entrega.EntregaId = entidad.EntregaId;
        return guardo;
    }

    public async Task<bool> Modificar(EntregaGarantiaDto entrega)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var entidad = await contexto.EntregasGarantia
            .FirstOrDefaultAsync(e => e.EntregaId == entrega.EntregaId);
        if (entidad == null) return false;

        entidad.OrdenId = entrega.OrdenId;
        if (entrega.MetodoPagoId > 0)
            entidad.MetodoPagoId = entrega.MetodoPagoId;
        entidad.FechaEntrega = entrega.FechaEntrega ?? entidad.FechaEntrega;
        entidad.DiaGarantia = entrega.DiaGarantia > 0 ? entrega.DiaGarantia : entidad.DiaGarantia;
        entidad.TotalManoObra = entrega.TotalManoObra;
        entidad.TotalRepuesto = entrega.TotalRepuesto;
        entidad.TotalCobrado = entrega.TotalCobrado;
        entidad.ObservacionFinal = entrega.ObservacionFinal ?? string.Empty;

        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Result<EntregaGarantiaDto?>> Buscar(int entregaId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var dto = await contexto.EntregasGarantia
            .AsNoTracking()
            .Where(e => e.EntregaId == entregaId)
            .Select(e => new EntregaGarantiaDto
            {
                EntregaId = e.EntregaId,
                OrdenId = e.OrdenId,
                MetodoPagoId = e.MetodoPagoId,
                MetodoPagoNombre = e.MetodoPago != null ? e.MetodoPago.Nombre : string.Empty,
                FechaEntrega = e.FechaEntrega,
                DiaGarantia = e.DiaGarantia,
                FechaVencimientoGarantia = e.FechaVencimientoGarantia,
                TotalManoObra = e.TotalManoObra,
                TotalRepuesto = e.TotalRepuesto,
                TotalCobrado = e.TotalCobrado,
                ObservacionFinal = e.ObservacionFinal
            })
            .FirstOrDefaultAsync();

        if (dto == null)
            return default(EntregaGarantiaDto?);
        return dto;
    }

    public async Task<Result<List<EntregaGarantiaDto>>> GetList(Expression<Func<EntregaGarantiaDto, bool>> criterio)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.EntregasGarantia
            .AsNoTracking()
            .Select(e => new EntregaGarantiaDto
            {
                EntregaId = e.EntregaId,
                OrdenId = e.OrdenId,
                MetodoPagoId = e.MetodoPagoId,
                MetodoPagoNombre = e.MetodoPago != null ? e.MetodoPago.Nombre : string.Empty,
                FechaEntrega = e.FechaEntrega,
                DiaGarantia = e.DiaGarantia,
                FechaVencimientoGarantia = e.FechaVencimientoGarantia,
                TotalManoObra = e.TotalManoObra,
                TotalRepuesto = e.TotalRepuesto,
                TotalCobrado = e.TotalCobrado,
                ObservacionFinal = e.ObservacionFinal
            })
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<Result> Eliminar(int entregaId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var eliminado = await contexto.EntregasGarantia
            .Where(e => e.EntregaId == entregaId)
            .ExecuteDeleteAsync() > 0;
        return Result.Success(eliminado);
    }

    public async Task<List<EntregaGarantiaDto>> Listar(Expression<Func<EntregaGarantiaDto, bool>> criterio)
    {
        var result = await GetList(criterio);
        return result.Value ?? [];
    }

    public async Task<List<EntregaGarantiaDto>> GetList()
    {
        var result = await GetList(e => true);
        return result.Value ?? [];
    }

    public async Task<int?> ObtenerEstadoId(string nombre)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Estados
            .Where(e => e.Nombre.ToLower() == nombre.ToLower())
            .Select(e => (int?)e.EstadoId)
            .FirstOrDefaultAsync();
    }
}
