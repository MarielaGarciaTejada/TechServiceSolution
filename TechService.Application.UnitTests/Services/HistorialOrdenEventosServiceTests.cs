using TechService.Application.Dtos;
using TechService.Application.Services;

namespace TechService.Application.UnitTests.Services;

public class HistorialOrdenEventosServiceTests
{
    [Fact]
    public async Task Guardar_CuandoNoExiste_InsertaEventoYAsignaId()
    {
        using var factory = new TestDbContextFactory();
        var service = new HistorialOrdenEventosService(factory);
        var dto = new HistorialEventoDto
        {
            OrdenId = 1,
            Origen = "Taller",
            Autor = "Tecnico Pedro",
            Mensaje = "Equipo ingresado a diagnostico"
        };

        var resultado = await service.Guardar(dto);

        Assert.True(resultado.IsSuccess);
        Assert.True(dto.EventoId > 0);
        Assert.True(await service.Existe(dto.EventoId));
    }

    [Fact]
    public async Task Guardar_CuandoExiste_ModificaEvento()
    {
        using var factory = new TestDbContextFactory();
        var service = new HistorialOrdenEventosService(factory);
        var dto = new HistorialEventoDto
        {
            OrdenId = 1,
            Origen = "Taller",
            Autor = "Tecnico Pedro",
            Mensaje = "Mensaje inicial"
        };
        await service.Guardar(dto);

        dto.Mensaje = "Mensaje corregido";
        var resultado = await service.Guardar(dto);

        Assert.True(resultado.IsSuccess);
        var buscado = await service.Buscar(dto.EventoId);
        Assert.NotNull(buscado.Value);
        Assert.Equal("Mensaje corregido", buscado.Value!.Mensaje);
    }

    [Fact]
    public async Task Buscar_ConIdInexistente_RetornaNull()
    {
        using var factory = new TestDbContextFactory();
        var service = new HistorialOrdenEventosService(factory);

        var resultado = await service.Buscar(999);

        Assert.Null(resultado.Value);
    }

    [Fact]
    public async Task GetList_ConCriterioPorOrden_RetornaEventosDeLaOrden()
    {
        using var factory = new TestDbContextFactory();
        var service = new HistorialOrdenEventosService(factory);
        await service.Guardar(new HistorialEventoDto { OrdenId = 10, Origen = "Sistema", Autor = "Admin", Mensaje = "Creada" });
        await service.Guardar(new HistorialEventoDto { OrdenId = 10, Origen = "Cliente", Autor = "Juan", Mensaje = "Gracias" });
        await service.Guardar(new HistorialEventoDto { OrdenId = 20, Origen = "Sistema", Autor = "Admin", Mensaje = "Otra orden" });

        var resultado = await service.GetList(h => h.OrdenId == 10);

        Assert.True(resultado.IsSuccess);
        Assert.Equal(2, resultado.Value!.Count);
    }

    [Fact]
    public async Task Eliminar_ConIdExistente_EliminaEvento()
    {
        using var factory = new TestDbContextFactory();
        var service = new HistorialOrdenEventosService(factory);
        var dto = new HistorialEventoDto
        {
            OrdenId = 1,
            Origen = "Taller",
            Autor = "Sistema",
            Mensaje = "Evento temporal"
        };
        await service.Guardar(dto);

        var resultado = await service.Eliminar(dto.EventoId);

        Assert.True(resultado.IsSuccess);
        Assert.False(await service.Existe(dto.EventoId));
    }
}
