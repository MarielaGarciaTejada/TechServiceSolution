using System.Linq.Expressions;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using TechService.Infrastructure.Data;
using TechService.Infrastructure.Models;

namespace TechService.Application.Services;

public class OrdenRepuestosService(
    IDbContextFactory<TechServiceDbContext> contextFactory
) : IServiceResult<OrdenRepuesto, int>
{
    public async Task<Result> Guardar(OrdenRepuesto ordenRepuesto)
    {
        if (!await Existe(ordenRepuesto.OrdenRepuestoId))
        {
            var inserto = await Insertar(ordenRepuesto);
            return Result.Success(inserto);
        }
        else
        {
            var modifico = await Modificar(ordenRepuesto);
            return Result.Success(modifico);
        }
    }

    public async Task<bool> Existe(int ordenRepuestoId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.OrdenRepuestos
            .AnyAsync(r => r.OrdenRepuestoId == ordenRepuestoId);
    }

    public async Task<bool> Insertar(OrdenRepuesto ordenRepuesto)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        contexto.OrdenRepuestos.Add(ordenRepuesto);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(OrdenRepuesto ordenRepuesto)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        contexto.OrdenRepuestos.Update(ordenRepuesto);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Result<OrdenRepuesto?>> Buscar(int ordenRepuestoId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.OrdenRepuestos
            .AsNoTracking()
            .Include(r => r.Item)
            .Include(r => r.EstadoAprobacion)
            .FirstOrDefaultAsync(r => r.OrdenRepuestoId == ordenRepuestoId);
    }

    public async Task<Result<List<OrdenRepuesto>>> GetList(Expression<Func<OrdenRepuesto, bool>> criterio)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.OrdenRepuestos
            .AsNoTracking()
            .Include(r => r.Item)
            .Include(r => r.EstadoAprobacion)
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<Result> Eliminar(int ordenRepuestoId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var eliminado = await contexto.OrdenRepuestos
            .Where(r => r.OrdenRepuestoId == ordenRepuestoId)
            .ExecuteDeleteAsync() > 0;
        return Result.Success(eliminado);
    }

    public async Task<List<OrdenRepuesto>> Listar(Expression<Func<OrdenRepuesto, bool>> criterio)
    {
        var result = await GetList(criterio);
        return result.Value ?? [];
    }

    public async Task<List<OrdenRepuesto>> GetList()
    {
        var result = await GetList(r => true);
        return result.Value ?? [];
    }
}
