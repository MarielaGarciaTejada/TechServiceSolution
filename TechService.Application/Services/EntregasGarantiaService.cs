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
        return await contexto.Set<EntregasGarantia>()
            .AnyAsync(e => e.EntregaId == entregaId);
    }

    public async Task<bool> Insertar(EntregaGarantiaDto entrega)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();

        var orden = await contexto.OrdenesReparacions
            .FirstOrDefaultAsync(o => o.OrdenId == entrega.OrdenId);
        if (orden == null) return false;

        // La tabla exige un método de pago y el DTO no lo trae: se usa el primero que exista
        var metodoPagoId = await contexto.Set<MetodosPago>()
            .Select(m => m.MetodoPagoId)
            .FirstOrDefaultAsync();
        if (metodoPagoId == 0) return false;

        var entidad = new EntregasGarantia
        {
            OrdenId = entrega.OrdenId,
            MetodoPagoId = metodoPagoId,
            FechaEntrega = entrega.FechaEntrega ?? DateTime.UtcNow,
            DiaGarantia = entrega.MesesGarantia * 30,
            TotalManoObra = orden.CostoManoObra,
            TotalRepuesto = 0,
            TotalCobrado = orden.CostoManoObra,
            ObservacionFinal = entrega.CondicionesGarantia ?? string.Empty
        };

        contexto.Set<EntregasGarantia>().Add(entidad);
        var guardo = await contexto.SaveChangesAsync() > 0;
        entrega.EntregaId = entidad.EntregaId;
        return guardo;
    }

    public async Task<bool> Modificar(EntregaGarantiaDto entrega)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var entidad = await contexto.Set<EntregasGarantia>()
            .FirstOrDefaultAsync(e => e.EntregaId == entrega.EntregaId);
        if (entidad == null) return false;

        entidad.FechaEntrega = entrega.FechaEntrega ?? entidad.FechaEntrega;
        entidad.DiaGarantia = entrega.MesesGarantia * 30;
        entidad.ObservacionFinal = entrega.CondicionesGarantia ?? string.Empty;

        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Result<EntregaGarantiaDto?>> Buscar(int entregaId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var dto = await contexto.Set<EntregasGarantia>()
            .AsNoTracking()
            .Where(e => e.EntregaId == entregaId)
            .Select(e => new EntregaGarantiaDto
            {
                EntregaId = e.EntregaId,
                OrdenId = e.OrdenId,
                FechaEntrega = e.FechaEntrega,
                MesesGarantia = e.DiaGarantia / 30,
                CondicionesGarantia = e.ObservacionFinal
            })
            .FirstOrDefaultAsync();

        if (dto == null)
            return default(EntregaGarantiaDto?);
        return dto;
    }

    public async Task<Result<List<EntregaGarantiaDto>>> GetList(Expression<Func<EntregaGarantiaDto, bool>> criterio)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Set<EntregasGarantia>()
            .AsNoTracking()
            .Select(e => new EntregaGarantiaDto
            {
                EntregaId = e.EntregaId,
                OrdenId = e.OrdenId,
                FechaEntrega = e.FechaEntrega,
                MesesGarantia = e.DiaGarantia / 30,
                CondicionesGarantia = e.ObservacionFinal
            })
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<Result> Eliminar(int entregaId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var eliminado = await contexto.Set<EntregasGarantia>()
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

    // Busca el id de un estado por su nombre (ej. "Entregado")
    public async Task<int?> ObtenerEstadoId(string nombre)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Set<Estado>()
            .Where(e => e.Nombre == nombre)
            .Select(e => (int?)e.EstadoId)
            .FirstOrDefaultAsync();
    }
}