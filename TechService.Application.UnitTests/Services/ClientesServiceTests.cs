using TechService.Application.Dtos;
using TechService.Application.Services;

namespace TechService.Application.UnitTests.Services;

public class ClientesServiceTests
{
    [Fact]
    public async Task Guardar_CuandoNoExiste_InsertaClienteYAsignaId()
    {
        using var factory = new TestDbContextFactory();
        var service = new ClientesService(factory);
        var dto = new ClienteDto { Nombre = "Juan Perez" };

        var resultado = await service.Guardar(dto);

        Assert.True(resultado.IsSuccess);
        Assert.True(dto.ClienteId > 0);
        Assert.True(await service.Existe(dto.ClienteId));
    }

    [Fact]
    public async Task Guardar_CuandoExiste_ModificaCliente()
    {
        using var factory = new TestDbContextFactory();
        var service = new ClientesService(factory);
        var dto = new ClienteDto { Nombre = "Juan Perez" };
        await service.Guardar(dto);

        dto.Nombre = "Juan Perez Modificado";
        var resultado = await service.Guardar(dto);

        Assert.True(resultado.IsSuccess);
        var buscado = await service.Buscar(dto.ClienteId);
        Assert.NotNull(buscado.Value);
        Assert.Equal("Juan Perez Modificado", buscado.Value!.Nombre);
    }

    [Fact]
    public async Task Buscar_ConIdExistente_RetornaClienteDto()
    {
        using var factory = new TestDbContextFactory();
        var service = new ClientesService(factory);
        var dto = new ClienteDto { Nombre = "Maria Lopez" };
        await service.Guardar(dto);

        var resultado = await service.Buscar(dto.ClienteId);

        Assert.NotNull(resultado.Value);
        Assert.Equal(dto.ClienteId, resultado.Value!.ClienteId);
        Assert.Equal("Maria Lopez", resultado.Value.Nombre);
    }

    [Fact]
    public async Task Buscar_ConIdInexistente_RetornaNull()
    {
        using var factory = new TestDbContextFactory();
        var service = new ClientesService(factory);

        var resultado = await service.Buscar(999);

        Assert.Null(resultado.Value);
    }

    [Fact]
    public async Task GetList_ConCriterio_RetornaClientesFiltrados()
    {
        using var factory = new TestDbContextFactory();
        var service = new ClientesService(factory);
        await service.Guardar(new ClienteDto { Nombre = "Carlos Gomez" });
        await service.Guardar(new ClienteDto { Nombre = "Ana Torres" });

        var resultado = await service.GetList(c => c.Nombre.Contains("Carlos"));

        Assert.True(resultado.IsSuccess);
        Assert.Single(resultado.Value!);
        Assert.Equal("Carlos Gomez", resultado.Value![0].Nombre);
    }

    [Fact]
    public async Task Eliminar_ConIdExistente_EliminaCliente()
    {
        using var factory = new TestDbContextFactory();
        var service = new ClientesService(factory);
        var dto = new ClienteDto { Nombre = "Cliente Temporal" };
        await service.Guardar(dto);

        var resultado = await service.Eliminar(dto.ClienteId);

        Assert.True(resultado.IsSuccess);
        Assert.False(await service.Existe(dto.ClienteId));
    }
}
