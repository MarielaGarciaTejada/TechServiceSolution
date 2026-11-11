using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TechService.Infrastructure.Data;
using TechService.Infrastructure.Models;
using TechService.Application.Dtos;

namespace TechService.Application.Services;

public class ClientesService(
    IDbContextFactory<TechServiceDbContext> contextFactory
) : IServiceResult<ClienteDto, int>
{
    public async Task<Result> Guardar(ClienteDto cliente)
    {
        if (!await Existe(cliente.ClienteId))
        {
            var inserto = await Insertar(cliente);
            return Result.Success(inserto);
        }
        else
        {
            var modifico = await Modificar(cliente);
            return Result.Success(modifico);
        }
    }

    public async Task<bool> Existe(int clienteId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Clientes
            .AnyAsync(c => c.ClienteId == clienteId);
    }

    public async Task<bool> Insertar(ClienteDto cliente)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var entidad = new Cliente
        {
            ClienteId = cliente.ClienteId,
            Nombre = cliente.Nombre,
            DocumentoIdentidad = "N/A", // Valores por defecto para que SQL no de un error
            Telefono = "N/A",
            Email = "cliente@correo.com",
            FechaRegistro = DateTime.UtcNow
        };
        contexto.Clientes.Add(entidad);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(ClienteDto cliente)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var entidad = await contexto.Clientes.FirstOrDefaultAsync(c => c.ClienteId == cliente.ClienteId);
        if (entidad == null) return false;
        entidad.Nombre = cliente.Nombre;
        contexto.Clientes.Update(entidad);
        return await contexto.SaveChangesAsync() > 0;

        //await using var contexto = await contextFactory.CreateDbContextAsync();
        //contexto.Update(cliente);
        //return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Result<ClienteDto?>> Buscar(int clienteId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();

        var cliente = await contexto.Clientes
            .FirstOrDefaultAsync(d => d.ClienteId == clienteId);
        if(cliente == null)
            return default(ClienteDto?);

        return new ClienteDto
        {
            ClienteId = clienteId,
            Nombre = cliente.Nombre
        };

        //return await contexto.Clientes
        //    .AsNoTracking()
        //    .FirstOrDefaultAsync(c => c.ClienteId == clienteId);
    }

    public async Task<Result<List<ClienteDto>>> GetList(Expression<Func<ClienteDto, bool>> criterio)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Clientes
            .AsNoTracking()
            .Select(c => new ClienteDto
            {
                ClienteId = c.ClienteId,
                Nombre = c.Nombre
            })
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<Result> Eliminar(int clienteId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var eliminado = await contexto.Clientes
            .Where(c => c.ClienteId == clienteId)
            .ExecuteDeleteAsync() > 0;
        return Result.Success(eliminado);
    }

    public async Task<List<ClienteDto>> Listar(Expression<Func<ClienteDto, bool>> criterio)
    {
        var result = await GetList(criterio);
        return result.Value ?? [];
    }

    public async Task<List<ClienteDto>> GetList()
    {
        var result = await GetList(c => true);
        return result.Value ?? [];
    }
}
