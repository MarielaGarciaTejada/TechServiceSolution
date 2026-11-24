using TechService.Application.Dtos;
using TechService.Application.Services;
using TechService.Infrastructure.Models;

namespace TechService.Application.UnitTests.Services;

public class OrdenRepuestosServiceTests
{
    private static async Task<(int Item1Id, int Item2Id)> SembrarItemsAsync(TestDbContextFactory factory)
    {
        var catalogoService = new CatalogoService(factory);
        var item1 = new CatalogoItemDto { CodigoSku = "REP-01", Nombre = "Pantalla", TipoItemId = 1, TipoEquipoId = 1, Precio = 500m, Stock = 10, StockMinimoAlerta = 2 };
        var item2 = new CatalogoItemDto { CodigoSku = "REP-02", Nombre = "Bateria", TipoItemId = 1, TipoEquipoId = 1, Precio = 300m, Stock = 10, StockMinimoAlerta = 2 };
        await catalogoService.Guardar(item1);
        await catalogoService.Guardar(item2);
        return (item1.ItemId, item2.ItemId);
    }

    [Fact]
    public async Task Guardar_CuandoNoExiste_InsertaRepuestoYAsignaId()
    {
        using var factory = new TestDbContextFactory();
        var service = new OrdenRepuestosService(factory);
        var entidad = new OrdenRepuesto
        {
            OrdenId = 1,
            ItemId = 1,
            EstadoAprobacionId = 1,
            Cantidad = 2,
            PrecioUnitario = 850m
        };

        var resultado = await service.Guardar(entidad);

        Assert.True(resultado.IsSuccess);
        Assert.True(entidad.OrdenRepuestoId > 0);
        Assert.True(await service.Existe(entidad.OrdenRepuestoId));
    }

    [Fact]
    public async Task Guardar_CuandoExiste_ModificaRepuesto()
    {
        using var factory = new TestDbContextFactory();
        var (item1Id, _) = await SembrarItemsAsync(factory);
        var service = new OrdenRepuestosService(factory);
        var entidad = new OrdenRepuesto
        {
            OrdenId = 1,
            ItemId = item1Id,
            EstadoAprobacionId = 1,
            Cantidad = 1,
            PrecioUnitario = 500m
        };
        await service.Guardar(entidad);

        entidad.Cantidad = 3;
        entidad.EstadoAprobacionId = 2;
        var resultado = await service.Guardar(entidad);

        Assert.True(resultado.IsSuccess);
        var buscado = await service.Buscar(entidad.OrdenRepuestoId);
        Assert.NotNull(buscado.Value);
        Assert.Equal(3, buscado.Value!.Cantidad);
        Assert.Equal(2, buscado.Value.EstadoAprobacionId);
    }

    [Fact]
    public async Task Buscar_ConIdInexistente_RetornaNull()
    {
        using var factory = new TestDbContextFactory();
        var service = new OrdenRepuestosService(factory);

        var resultado = await service.Buscar(999);

        Assert.Null(resultado.Value);
    }

    [Fact]
    public async Task GetList_ConCriterio_RetornaRepuestosDeLaOrden()
    {
        using var factory = new TestDbContextFactory();
        var (item1Id, item2Id) = await SembrarItemsAsync(factory);
        var service = new OrdenRepuestosService(factory);
        await service.Guardar(new OrdenRepuesto { OrdenId = 5, ItemId = item1Id, EstadoAprobacionId = 1, Cantidad = 1, PrecioUnitario = 200m });
        await service.Guardar(new OrdenRepuesto { OrdenId = 6, ItemId = item2Id, EstadoAprobacionId = 1, Cantidad = 2, PrecioUnitario = 300m });

        var resultado = await service.GetList(r => r.OrdenId == 5);

        Assert.True(resultado.IsSuccess);
        Assert.Single(resultado.Value!);
        Assert.Equal(200m, resultado.Value![0].PrecioUnitario);
    }

    [Fact]
    public async Task Eliminar_ConIdExistente_EliminaRepuesto()
    {
        using var factory = new TestDbContextFactory();
        var service = new OrdenRepuestosService(factory);
        var entidad = new OrdenRepuesto
        {
            OrdenId = 1,
            ItemId = 1,
            EstadoAprobacionId = 1,
            Cantidad = 1,
            PrecioUnitario = 150m
        };
        await service.Guardar(entidad);

        var resultado = await service.Eliminar(entidad.OrdenRepuestoId);

        Assert.True(resultado.IsSuccess);
        Assert.False(await service.Existe(entidad.OrdenRepuestoId));
    }
}
