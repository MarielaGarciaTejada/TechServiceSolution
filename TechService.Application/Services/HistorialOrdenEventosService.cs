using System.Linq.Expressions;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using TechService.Application.Dtos;
using TechService.Infrastructure.Data;
using TechService.Infrastructure.Models;

namespace TechService.Application.Services;

public class HistorialOrdenEventosService(
    IDbContextFactory<TechServiceDbContext> contextFactory
) : IServiceResult<HistorialEventoDto, int>
{
    public async Task<Result> Guardar(HistorialEventoDto evento)
    {
        if (!await Existe(evento.EventoId))
        {
            var inserto = await Insertar(evento);
            return Result.Success(inserto);
        }
        else
        {
            var modifico = await Modificar(evento);
            return Result.Success(modifico);
        }
    }

    public async Task<bool> Existe(int eventoId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.HistorialOrdenEventos.AnyAsync(h => h.EventoId == eventoId);
    }

    public async Task<bool> Insertar(HistorialEventoDto evento)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var entidad = new HistorialOrdenEvento
        {
            OrdenId = evento.OrdenId,
            Origen = evento.Origen,
            Autor = evento.Autor,
            Mensaje = evento.Mensaje,
            FechaHora = evento.FechaHora ?? DateTime.UtcNow
        };

        contexto.HistorialOrdenEventos.Add(entidad);
        var guardo = await contexto.SaveChangesAsync() > 0;
        evento.EventoId = entidad.EventoId;
        return guardo;
    }

    public async Task<bool> Modificar(HistorialEventoDto evento)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var entidad = await contexto.HistorialOrdenEventos.FindAsync(evento.EventoId);
        if (entidad == null) return false;

        entidad.OrdenId = evento.OrdenId;
        entidad.Origen = evento.Origen;
        entidad.Autor = evento.Autor;
        entidad.Mensaje = evento.Mensaje;
        entidad.FechaHora = evento.FechaHora ?? entidad.FechaHora;

        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Result<HistorialEventoDto?>> Buscar(int eventoId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var evento = await contexto.HistorialOrdenEventos
            .Where(h => h.EventoId == eventoId)
            .Select(h => new HistorialEventoDto
            {
                EventoId = h.EventoId,
                OrdenId = h.OrdenId,
                Origen = h.Origen,
                Autor = h.Autor,
                Mensaje = h.Mensaje,
                FechaHora = h.FechaHora
            })
            .FirstOrDefaultAsync();

        return evento;
    }

    public async Task<Result<List<HistorialEventoDto>>> GetList(Expression<Func<HistorialEventoDto, bool>> criterio)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.HistorialOrdenEventos
            .Select(h => new HistorialEventoDto
            {
                EventoId = h.EventoId,
                OrdenId = h.OrdenId,
                Origen = h.Origen,
                Autor = h.Autor,
                Mensaje = h.Mensaje,
                FechaHora = h.FechaHora
            })
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<Result> Eliminar(int eventoId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var eliminado = await contexto.HistorialOrdenEventos
            .Where(h => h.EventoId == eventoId)
            .ExecuteDeleteAsync() > 0;
        return Result.Success(eliminado);
    }

    public async Task<List<HistorialEventoDto>> Listar(Expression<Func<HistorialEventoDto, bool>> criterio)
    {
        var result = await GetList(criterio);
        return result.Value ?? [];
    }

    public async Task<List<HistorialEventoDto>> GetList()
    {
        var result = await GetList(h => true);
        return result.Value ?? [];
    }
}
