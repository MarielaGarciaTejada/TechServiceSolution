using System.Linq.Expressions;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using TechService.Infrastructure.Data;
using TechService.Infrastructure.Models;
using TechService.Application.Dtos;

namespace TechService.Application.Services;

public class CatalogoService(
    IDbContextFactory<TechServiceDbContext> contextFactory
) : IServiceResult<CatalogoItemDto, int>
{
    public async Task<Result> Guardar(CatalogoItemDto itemDto)
    {
        if (!await Existe(itemDto.ItemId))
        {
            var inserto = await Insertar(itemDto);
            return Result.Success(inserto);
        }
        else
        {
            var modifico = await Modificar(itemDto);
            return Result.Success(modifico);
        }
    }

    public async Task<bool> Existe(int itemId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.CatalogoItems.AnyAsync(i => i.ItemId == itemId);
    }

    public async Task<bool> Insertar(CatalogoItemDto itemDto)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var entidad = new CatalogoItem
        {
            ItemId = itemDto.ItemId,
            CodigoSku = itemDto.CodigoSku,
            Nombre = itemDto.Nombre,
            TipoItemId = itemDto.TipoItemId > 0 ? itemDto.TipoItemId : 1,
            TipoEquipoId = itemDto.TipoEquipoId > 0 ? itemDto.TipoEquipoId : 1,
            Precio = itemDto.Precio,
            Stock = itemDto.Stock,
            StockMinimoAlerta = itemDto.StockMinimoAlerta
        };
        contexto.CatalogoItems.Add(entidad);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(CatalogoItemDto itemDto)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var entidad = await contexto.CatalogoItems.FirstOrDefaultAsync(i => i.ItemId == itemDto.ItemId);
        if (entidad == null) return false;

        entidad.CodigoSku = itemDto.CodigoSku;
        entidad.Nombre = itemDto.Nombre;

        if (itemDto.TipoItemId > 0) entidad.TipoItemId = itemDto.TipoItemId;
        if (itemDto.TipoEquipoId > 0) entidad.TipoEquipoId = itemDto.TipoEquipoId;

        entidad.Precio = itemDto.Precio;
        entidad.Stock = itemDto.Stock;
        entidad.StockMinimoAlerta = itemDto.StockMinimoAlerta;

        contexto.CatalogoItems.Update(entidad);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Result<CatalogoItemDto?>> Buscar(int itemId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();

        var item = await contexto.CatalogoItems
            .FirstOrDefaultAsync(d => d.ItemId == itemId);

        if (item == null)
            return default(CatalogoItemDto?);

        return new CatalogoItemDto
        {
            ItemId = item.ItemId,
            CodigoSku = item.CodigoSku,
            Nombre = item.Nombre,
            Precio = item.Precio,
            Stock = item.Stock
        };
    }

    public async Task<Result<List<CatalogoItemDto>>> GetList(Expression<Func<CatalogoItemDto, bool>> criterio)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.CatalogoItems
            .AsNoTracking()
            .Select(i => new CatalogoItemDto
            {
                ItemId = i.ItemId,
                CodigoSku = i.CodigoSku,
                Nombre = i.Nombre,
                TipoItemId = i.TipoItemId,
                TipoItemNombre = i.TipoItem != null ? i.TipoItem.Nombre : "",
                TipoEquipoId = i.TipoEquipoId,
                TipoEquipoNombre = i.TipoEquipo != null ? i.TipoEquipo.Nombre : "",
                Precio = i.Precio,
                Stock = i.Stock,
                StockMinimoAlerta = i.StockMinimoAlerta
            })
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<Result> Eliminar(int itemId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var eliminado = await contexto.CatalogoItems
            .Where(i => i.ItemId == itemId)
            .ExecuteDeleteAsync() > 0;
        return Result.Success(eliminado);
    }

    public async Task<List<CatalogoItemDto>> Listar(Expression<Func<CatalogoItemDto, bool>> criterio)
    {
        var result = await GetList(criterio);
        return result.Value ?? [];
    }

    public async Task<List<CatalogoItemDto>> GetList()
    {
        var result = await GetList(i => true);
        return result.Value ?? [];
    }

    public async Task<List<CatalogoItemDto>> ListarStockBajo()
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.CatalogoItems
            .AsNoTracking()
            .Where(i => i.Stock <= i.StockMinimoAlerta)
            .Select(i => new CatalogoItemDto
            {
                ItemId = i.ItemId,
                CodigoSku = i.CodigoSku,
                Nombre = i.Nombre,
                TipoItemId = i.TipoItemId,
                TipoItemNombre = i.TipoItem != null ? i.TipoItem.Nombre : "",
                TipoEquipoId = i.TipoEquipoId,
                TipoEquipoNombre = i.TipoEquipo != null ? i.TipoEquipo.Nombre : "",
                Precio = i.Precio,
                Stock = i.Stock,
                StockMinimoAlerta = i.StockMinimoAlerta
            })
            .ToListAsync();
    }
}
