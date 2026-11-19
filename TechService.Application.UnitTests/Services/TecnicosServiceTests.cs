using TechService.Application.Dtos;
using TechService.Application.Services;

namespace TechService.Application.UnitTests.Services;

public class TecnicosServiceTests
{
    [Fact]
    public async Task Guardar_CuandoNoExiste_InsertaTecnicoYAsignaId()
    {
        using var factory = new TestDbContextFactory();
        var service = new TecnicosService(factory);
        var dto = new TecnicoDto { Nombre = "Pedro Ramirez", Especialidad = "Microsoldadura" };

        var resultado = await service.Guardar(dto);

        Assert.True(resultado.IsSuccess);
        Assert.True(dto.TecnicoId > 0);
        Assert.True(await service.Existe(dto.TecnicoId));
    }

    [Fact]
    public async Task Guardar_CuandoExiste_ModificaTecnico()
    {
        using var factory = new TestDbContextFactory();
        var service = new TecnicosService(factory);
        var dto = new TecnicoDto { Nombre = "Luis Diaz", Especialidad = "Software" };
        await service.Guardar(dto);

        dto.Nombre = "Luis Diaz Senior";
        dto.Especialidad = "Hardware y Software";
        var resultado = await service.Guardar(dto);

        Assert.True(resultado.IsSuccess);
        var buscado = await service.Buscar(dto.TecnicoId);
        Assert.NotNull(buscado.Value);
        Assert.Equal("Luis Diaz Senior", buscado.Value!.Nombre);
        Assert.Equal("Hardware y Software", buscado.Value.Especialidad);
    }

    [Fact]
    public async Task Buscar_ConIdExistente_RetornaTecnicoDto()
    {
        using var factory = new TestDbContextFactory();
        var service = new TecnicosService(factory);
        var dto = new TecnicoDto { Nombre = "Ana Marte", Especialidad = "Laptops" };
        await service.Guardar(dto);

        var resultado = await service.Buscar(dto.TecnicoId);

        Assert.NotNull(resultado.Value);
        Assert.Equal(dto.TecnicoId, resultado.Value!.TecnicoId);
        Assert.Equal("Ana Marte", resultado.Value.Nombre);
        Assert.Equal("Laptops", resultado.Value.Especialidad);
    }

    [Fact]
    public async Task Buscar_ConIdInexistente_RetornaNull()
    {
        using var factory = new TestDbContextFactory();
        var service = new TecnicosService(factory);

        var resultado = await service.Buscar(999);

        Assert.Null(resultado.Value);
    }

    [Fact]
    public async Task GetList_ConCriterio_RetornaTecnicosFiltrados()
    {
        using var factory = new TestDbContextFactory();
        var service = new TecnicosService(factory);
        await service.Guardar(new TecnicoDto { Nombre = "Tecnico A", Especialidad = "Pantallas" });
        await service.Guardar(new TecnicoDto { Nombre = "Tecnico B", Especialidad = "Placas" });

        var resultado = await service.GetList(t => t.Especialidad == "Placas");

        Assert.True(resultado.IsSuccess);
        Assert.Single(resultado.Value!);
        Assert.Equal("Tecnico B", resultado.Value![0].Nombre);
    }

    [Fact]
    public async Task Eliminar_ConIdExistente_EliminaTecnico()
    {
        using var factory = new TestDbContextFactory();
        var service = new TecnicosService(factory);
        var dto = new TecnicoDto { Nombre = "Tecnico Temporal", Especialidad = "General" };
        await service.Guardar(dto);

        var resultado = await service.Eliminar(dto.TecnicoId);

        Assert.True(resultado.IsSuccess);
        Assert.False(await service.Existe(dto.TecnicoId));
    }
}
