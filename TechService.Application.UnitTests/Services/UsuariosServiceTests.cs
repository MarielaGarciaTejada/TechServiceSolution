using TechService.Application.Dtos;
using TechService.Application.Services;

namespace TechService.Application.UnitTests.Services;

public class UsuariosServiceTests
{
    [Fact]
    public async Task Guardar_CuandoNoExiste_InsertaUsuarioYAsignaId()
    {
        using var factory = new TestDbContextFactory();
        var service = new UsuariosService(factory);
        var dto = new UsuarioDto
        {
            NombreUsuario = "admin1",
            Contrasena = "Password123",
            NombreCompleto = "Administrador Principal",
            RolId = 1,
            Activo = true
        };

        var resultado = await service.Guardar(dto);

        Assert.True(resultado.IsSuccess);
        Assert.True(dto.UsuarioId > 0);
        Assert.True(await service.Existe(dto.UsuarioId));
    }

    [Fact]
    public async Task Guardar_CuandoExiste_ModificaUsuario()
    {
        using var factory = new TestDbContextFactory();
        var service = new UsuariosService(factory);
        var dto = new UsuarioDto
        {
            NombreUsuario = "user1",
            Contrasena = "123",
            NombreCompleto = "Usuario Original",
            RolId = 1,
            Activo = true
        };
        await service.Guardar(dto);

        dto.NombreCompleto = "Usuario Actualizado";
        dto.Email = "usuario@techservice.com";
        var resultado = await service.Guardar(dto);

        Assert.True(resultado.IsSuccess);
        var buscado = await service.Buscar(dto.UsuarioId);
        Assert.NotNull(buscado.Value);
        Assert.Equal("Usuario Actualizado", buscado.Value!.NombreCompleto);
        Assert.Equal("usuario@techservice.com", buscado.Value.Email);
    }

    [Fact]
    public async Task ExisteNombreUsuario_DetectaDuplicadosCorrectamente()
    {
        using var factory = new TestDbContextFactory();
        var service = new UsuariosService(factory);
        var dto = new UsuarioDto
        {
            NombreUsuario = "mariela",
            Contrasena = "secret",
            NombreCompleto = "Mariela Garcia",
            RolId = 1
        };
        await service.Guardar(dto);

        Assert.True(await service.ExisteNombreUsuario("MARIELA"));
        Assert.False(await service.ExisteNombreUsuario("mariela", dto.UsuarioId));
        Assert.False(await service.ExisteNombreUsuario("otro"));
    }

    [Fact]
    public async Task Buscar_ConIdInexistente_RetornaNull()
    {
        using var factory = new TestDbContextFactory();
        var service = new UsuariosService(factory);

        var resultado = await service.Buscar(999);

        Assert.Null(resultado.Value);
    }

    [Fact]
    public async Task GetList_ConCriterio_RetornaUsuariosFiltrados()
    {
        using var factory = new TestDbContextFactory();
        var service = new UsuariosService(factory);
        await service.Guardar(new UsuarioDto { NombreUsuario = "u1", Contrasena = "1", NombreCompleto = "Uno", RolId = 1, Activo = true });
        await service.Guardar(new UsuarioDto { NombreUsuario = "u2", Contrasena = "2", NombreCompleto = "Dos", RolId = 2, Activo = false });

        var resultado = await service.GetList(u => u.Activo);

        Assert.True(resultado.IsSuccess);
        Assert.Single(resultado.Value!);
        Assert.Equal("u1", resultado.Value![0].NombreUsuario);
    }

    [Fact]
    public async Task Login_ConCredencialesValidas_RetornaUsuarioDto()
    {
        using var factory = new TestDbContextFactory();
        var service = new UsuariosService(factory);
        await service.Guardar(new UsuarioDto
        {
            NombreUsuario = "tecnico1",
            Contrasena = "clave",
            NombreCompleto = "Tecnico Uno",
            RolId = 2,
            Activo = true
        });

        var loginExitoso = await service.Login("TECNICO1", "clave");
        var loginFallido = await service.Login("tecnico1", "incorrecta");

        Assert.NotNull(loginExitoso);
        Assert.Equal("Tecnico Uno", loginExitoso!.NombreCompleto);
        Assert.Null(loginFallido);
    }

    [Fact]
    public async Task GetRoles_RetornaRolesRegistrados()
    {
        using var factory = new TestDbContextFactory();

        var service = new UsuariosService(factory);
        var roles = await service.GetRoles();

        Assert.Equal(2, roles.Count);
        Assert.Contains(roles, r => r.Nombre == "Admin");
    }

    [Fact]
    public async Task Eliminar_DesactivaUsuarioLogicamente()
    {
        using var factory = new TestDbContextFactory();
        var service = new UsuariosService(factory);
        var dto = new UsuarioDto
        {
            NombreUsuario = "temporal",
            Contrasena = "123",
            NombreCompleto = "Temporal",
            RolId = 1,
            Activo = true
        };
        await service.Guardar(dto);

        var resultado = await service.Eliminar(dto.UsuarioId);

        Assert.True(resultado.IsSuccess);
        var buscado = await service.Buscar(dto.UsuarioId);
        Assert.NotNull(buscado.Value);
        Assert.False(buscado.Value!.Activo);
        Assert.Null(await service.Login("temporal", "123"));
    }
}
