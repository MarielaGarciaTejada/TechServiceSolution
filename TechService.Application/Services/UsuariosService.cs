using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using TechService.Application.Dtos;
using TechService.Infrastructure.Data;
using TechService.Infrastructure.Models;

namespace TechService.Application.Services;

public class UsuariosService(
    IDbContextFactory<TechServiceDbContext> contextFactory
) : IServiceResult<UsuarioDto, int>
{
    public async Task<Result> Guardar(UsuarioDto usuario)
    {
        if (!await Existe(usuario.UsuarioId))
        {
            var inserto = await Insertar(usuario);
            return Result.Success(inserto);
        }
        else
        {
            var modifico = await Modificar(usuario);
            return Result.Success(modifico);
        }
    }

    public async Task<bool> Existe(int usuarioId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Usuarios.AnyAsync(u => u.UsuarioId == usuarioId);
    }

    public async Task<bool> ExisteNombreUsuario(string nombreUsuario, int excluirId = 0)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Usuarios.AnyAsync(u => u.NombreUsuario.ToLower() == nombreUsuario.ToLower() && u.UsuarioId != excluirId);
    }

    public async Task<bool> Insertar(UsuarioDto usuario)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var entidad = new Usuario
        {
            NombreUsuario = usuario.NombreUsuario,
            Contrasena = usuario.Contrasena ?? string.Empty,
            NombreCompleto = usuario.NombreCompleto,
            Email = usuario.Email,
            Telefono = usuario.Telefono,
            RolId = usuario.RolId,
            TecnicoId = usuario.TecnicoId,
            Activo = usuario.Activo,
            FechaRegistro = usuario.FechaRegistro ?? DateTime.UtcNow
        };

        contexto.Usuarios.Add(entidad);
        var guardar = await contexto.SaveChangesAsync() > 0;
        usuario.UsuarioId = entidad.UsuarioId;
        return guardar;
    }

    public async Task<bool> Modificar(UsuarioDto usuario)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var existing = await contexto.Usuarios.FindAsync(usuario.UsuarioId);
        if (existing == null) return false;

        existing.NombreUsuario = usuario.NombreUsuario;
        if (!string.IsNullOrWhiteSpace(usuario.Contrasena))
        {
            existing.Contrasena = usuario.Contrasena;
        }
        existing.NombreCompleto = usuario.NombreCompleto;
        existing.Email = usuario.Email;
        existing.Telefono = usuario.Telefono;
        existing.RolId = usuario.RolId;
        existing.TecnicoId = usuario.TecnicoId;
        existing.Activo = usuario.Activo;

        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Result<UsuarioDto?>> Buscar(int usuarioId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var usuario = await contexto.Usuarios
            .Where(u => u.UsuarioId == usuarioId)
            .Select(u => new UsuarioDto
            {
                UsuarioId = u.UsuarioId,
                NombreUsuario = u.NombreUsuario,
                Contrasena = u.Contrasena,
                NombreCompleto = u.NombreCompleto,
                Email = u.Email,
                Telefono = u.Telefono,
                RolId = u.RolId,
                RolNombre = u.Rol != null ? u.Rol.Nombre : "",
                TecnicoId = u.TecnicoId,
                TecnicoNombre = u.Tecnico != null ? u.Tecnico.Nombre : null,
                Activo = u.Activo,
                FechaRegistro = u.FechaRegistro
            })
            .FirstOrDefaultAsync();
        return usuario;
    }

    public async Task<Result<List<UsuarioDto>>> GetList(Expression<Func<UsuarioDto, bool>> criterio)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Usuarios
            .Select(u => new UsuarioDto
            {
                UsuarioId = u.UsuarioId,
                NombreUsuario = u.NombreUsuario,
                Contrasena = u.Contrasena,
                NombreCompleto = u.NombreCompleto,
                Email = u.Email,
                Telefono = u.Telefono,
                RolId = u.RolId,
                RolNombre = u.Rol != null ? u.Rol.Nombre : "",
                TecnicoId = u.TecnicoId,
                TecnicoNombre = u.Tecnico != null ? u.Tecnico.Nombre : null,
                Activo = u.Activo,
                FechaRegistro = u.FechaRegistro
            })
            .Where(criterio)
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<Result> Eliminar(int usuarioId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var usuario = await contexto.Usuarios.FirstOrDefaultAsync(u => u.UsuarioId == usuarioId);
        if (usuario == null)
            return Result.Failure(new Error("NotFound", "Usuario no encontrado."));

        // Soft-delete desactivando o eliminación directa
        usuario.Activo = false;
        var modificado = await contexto.SaveChangesAsync() > 0;
        return Result.Success(modificado);
    }

    public async Task<UsuarioDto?> Login(string nombreUsuario, string contrasena)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Usuarios
            .Where(u => u.NombreUsuario.ToLower() == nombreUsuario.ToLower()
                     && u.Contrasena == contrasena
                     && u.Activo)
            .Select(u => new UsuarioDto
            {
                UsuarioId = u.UsuarioId,
                NombreUsuario = u.NombreUsuario,
                NombreCompleto = u.NombreCompleto,
                Email = u.Email,
                Telefono = u.Telefono,
                RolId = u.RolId,
                RolNombre = u.Rol != null ? u.Rol.Nombre : "",
                TecnicoId = u.TecnicoId,
                TecnicoNombre = u.Tecnico != null ? u.Tecnico.Nombre : null,
                Activo = u.Activo,
                FechaRegistro = u.FechaRegistro
            })
            .FirstOrDefaultAsync();
    }

    public async Task<List<UsuarioDto>> GetList()
    {
        var result = await GetList(u => true);
        return result.Value ?? [];
    }

    public async Task<List<RolDto>> GetRoles()
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Roles
            .AsNoTracking()
            .Select(r => new RolDto
            {
                RolId = r.RolId,
                Nombre = r.Nombre,
                Descripcion = r.Descripcion
            })
            .ToListAsync();
    }
}
