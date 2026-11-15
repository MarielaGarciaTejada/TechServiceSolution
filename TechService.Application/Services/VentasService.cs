using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TechService.Infrastructure.Data;
using TechService.Infrastructure.Models;
using TechService.Application.Dtos;

namespace TechService.Application.Services;

public class VentasService(
    IDbContextFactory<TechServiceDbContext> contextFactory
) : IServiceResult<VentaDto, int>
{
    public async Task<Result> Guardar(VentaDto venta)
    {
        if (!await Existe(venta.VentaId))
        {
            var inserto = await Insertar(venta);
            return Result.Success(inserto);
        }
        else
        {
            var modifico = await Modificar(venta);
            return Result.Success(modifico);
        }
    }

    public async Task<bool> Existe(int ventaId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Ventas
            .AnyAsync(v => v.VentaId == ventaId);
    }

    public async Task<bool> Insertar(VentaDto venta)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var entidad = new Venta
        {
            ClienteId = venta.ClienteId,
            MetodoPagoId = venta.MetodoPagoId,
            FechaVenta = venta.Fecha,
            Subtotal = venta.Subtotal,
            Itbis = venta.Itbis,
            TotalVenta = venta.Total,
            DetalleVenta = venta.Detalles.Select(d => new DetalleVenta
            {
                ItemId = d.ItemId,
                Cantidad = d.Cantidad,
                PrecioUnitario = d.PrecioUnitario
            }).ToList()
        };
        contexto.Ventas.Add(entidad);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(VentaDto venta)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var entidad = await contexto.Ventas.FirstOrDefaultAsync(v => v.VentaId == venta.VentaId);
        if (entidad == null) return false;
        entidad.ClienteId = venta.ClienteId;
        entidad.MetodoPagoId = venta.MetodoPagoId;
        entidad.FechaVenta = venta.Fecha;
        entidad.Subtotal = venta.Subtotal;
        entidad.Itbis = venta.Itbis;
        entidad.TotalVenta = venta.Total;
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Result<VentaDto?>> Buscar(int ventaId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var dto = await contexto.Ventas
            .AsNoTracking()
            .Where(v => v.VentaId == ventaId)
            .Select(v => new VentaDto
            {
                VentaId = v.VentaId,
                ClienteId = v.ClienteId,
                ClienteNombre = v.Cliente != null ? v.Cliente.Nombre : null,
                Fecha = v.FechaVenta ?? default,
                MetodoPagoId = v.MetodoPagoId,
                MetodoPagoNombre = v.MetodoPago != null ? v.MetodoPago.Nombre : string.Empty,
                Subtotal = v.Subtotal,
                Itbis = v.Itbis,
                Total = v.TotalVenta,
                Detalles = v.DetalleVenta.Select(d => new DetalleVentaDto
                {
                    DetalleVentaId = d.DetalleVentaId,
                    VentaId = d.VentaId,
                    ItemId = d.ItemId,
                    Cantidad = d.Cantidad,
                    PrecioUnitario = d.PrecioUnitario
                }).ToList()
            })
            .FirstOrDefaultAsync();

        if (dto == null)
            return default(VentaDto?);
        return dto;
    }

    public async Task<Result<List<VentaDto>>> GetList(Expression<Func<VentaDto, bool>> criterio)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Ventas
            .AsNoTracking()
            .Select(v => new VentaDto
            {
                VentaId = v.VentaId,
                ClienteId = v.ClienteId,
                ClienteNombre = v.Cliente != null ? v.Cliente.Nombre : null,
                Fecha = v.FechaVenta ?? default,
                MetodoPagoId = v.MetodoPagoId,
                MetodoPagoNombre = v.MetodoPago != null ? v.MetodoPago.Nombre : string.Empty,
                Subtotal = v.Subtotal,
                Itbis = v.Itbis,
                Total = v.TotalVenta
            })
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<Result> Eliminar(int ventaId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        await contexto.Set<DetalleVenta>()
            .Where(d => d.VentaId == ventaId)
            .ExecuteDeleteAsync();
        var eliminado = await contexto.Ventas
            .Where(v => v.VentaId == ventaId)
            .ExecuteDeleteAsync() > 0;
        return Result.Success(eliminado);
    }

    public async Task<List<VentaDto>> Listar(Expression<Func<VentaDto, bool>> criterio)
    {
        var result = await GetList(criterio);
        return result.Value ?? [];
    }

    public async Task<List<VentaDto>> GetList()
    {
        var result = await GetList(v => true);
        return result.Value ?? [];
    }
}
