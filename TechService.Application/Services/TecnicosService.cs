using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using TechService.Application.Dtos;
using TechService.Infrastructure.Data;
using TechService.Infrastructure.Models;

namespace TechService.Application.Services;

public class TecnicosService(
    IDbContextFactory<TechServiceDbContext> contextFactory
) : IServiceResult<TecnicoDto, int>
{
    public async Task<Result> Guardar(TecnicoDto tecnico)
    {
        if (!await Existe(tecnico.TecnicoId))
        {
            var inserto = await Insertar(tecnico);
            return Result.Success(inserto);
        }
        else
        {
            var modifico = await Modificar(tecnico);
            return Result.Success(modifico);
        }
    }

    public async Task<bool> Existe(int tecnicoId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Tecnicos.AnyAsync(t => t.TecnicoId == tecnicoId);
    }

    public async Task<bool> Insertar(TecnicoDto tecnico)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var entidad = new Tecnico
        {
            TecnicoId = tecnico.TecnicoId,
            Nombre = tecnico.Nombre,
            Especialidad = string.IsNullOrWhiteSpace(tecnico.Especialidad) ? "General" : tecnico.Especialidad,
            PorcentajeComision = 10.0m,
            Activo = true
        };
        contexto.Tecnicos.Add(entidad);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(TecnicoDto tecnico)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();

        var entidad = await contexto.Tecnicos.FirstOrDefaultAsync(t => t.TecnicoId == tecnico.TecnicoId);
        if (entidad == null) return false;

        entidad.Nombre = tecnico.Nombre;
        entidad.Especialidad = tecnico.Especialidad;
        contexto.Tecnicos.Update(entidad);

        contexto.Update(tecnico);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Result<TecnicoDto?>> Buscar(int tecnicoId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();

        var tecnico = await contexto.Tecnicos
            .FirstOrDefaultAsync(d => d.TecnicoId == tecnicoId);

        if (tecnico == null)
            return default(TecnicoDto?);

        return new TecnicoDto
        {
            TecnicoId = tecnicoId,
            Nombre = tecnico.Nombre,
            Especialidad = tecnico.Especialidad
        };

    }

    public async Task<Result<List<TecnicoDto>>> GetList(Expression<Func<TecnicoDto, bool>> criterio)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Tecnicos
            .AsNoTracking()
            .Select(t => new TecnicoDto
            {
                TecnicoId = t.TecnicoId,
                Nombre = t.Nombre,
                Especialidad= t.Especialidad
            })
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<Result> Eliminar(int tecnicoId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var eliminado = await contexto.Tecnicos
            .Where(t => t.TecnicoId == tecnicoId)
            .ExecuteDeleteAsync() > 0;
        return Result.Success(eliminado);
    }

    public async Task<List<TecnicoDto>> Listar(Expression<Func<TecnicoDto, bool>> criterio)
    {
        var result = await GetList(criterio);
        return result.Value ?? [];
    }

    public async Task<List<TecnicoDto>> GetList()
    {
        var result = await GetList(t => true);
        return result.Value ?? [];
    }
}
