using TechService.Application.Dtos;
using TechService.Application.Services;

namespace TechService.Application.UnitTests.Services;

public class CatalogoServiceTests
{
    [Fact]
    public async Task Guardar_CuandoNoExiste_InsertaItemYAsignaId()
    {
        using var factory = new TestDbContextFactory();
        var service = new CatalogoService(factory);
        var dto = new CatalogoItemDto
        {
            CodigoSku = "SKU-001",
            Nombre = "Pantalla iPhone 13",
            TipoItemId = 1,
            TipoEquipoId = 1,
            Precio = 4500m,
            Stock = 10,
            StockMinimoAlerta = 3
        };

        var resultado = await service.Guardar(dto);

        Assert.True(resultado.IsSuccess);
        Assert.True(dto.ItemId > 0);
        Assert.True(await service.Existe(dto.ItemId));
    }

    [Fact]
    public async Task Guardar_CuandoExiste_ModificaItem()
    {
        using var factory = new TestDbContextFactory();
        var service = new CatalogoService(factory);
        var dto = new CatalogoItemDto
        {
            CodigoSku = "SKU-002",
            Nombre = "Bateria Samsung",
            Precio = 1200m,
            Stock = 8,
            StockMinimoAlerta = 2
        };
        await service.Guardar(dto);

        dto.Nombre = "Bateria Samsung Original";
        dto.Precio = 1500m;
        dto.Stock = 5;
        var resultado = await service.Guardar(dto);

        Assert.True(resultado.IsSuccess);
        var buscado = await service.Buscar(dto.ItemId);
        Assert.NotNull(buscado.Value);
        Assert.Equal("Bateria Samsung Original", buscado.Value!.Nombre);
        Assert.Equal(1500m, buscado.Value.Precio);
        Assert.Equal(5, buscado.Value.Stock);
    }

    [Fact]
    public async Task Buscar_ConIdExistente_RetornaCatalogoItemDto()
    {
        using var factory = new TestDbContextFactory();
        var service = new CatalogoService(factory);
        var dto = new CatalogoItemDto
        {
            CodigoSku = "SKU-003",
            Nombre = "SSD 512GB",
            Precio = 2800m,
            Stock = 4,
            StockMinimoAlerta = 2
        };
        await service.Guardar(dto);

        var resultado = await service.Buscar(dto.ItemId);

        Assert.NotNull(resultado.Value);
        Assert.Equal("SKU-003", resultado.Value!.CodigoSku);
        Assert.Equal("SSD 512GB", resultado.Value.Nombre);
    }

    [Fact]
    public async Task Buscar_ConIdInexistente_RetornaNull()
    {
        using var factory = new TestDbContextFactory();
        var service = new CatalogoService(factory);

        var resultado = await service.Buscar(999);

        Assert.Null(resultado.Value);
    }

    [Fact]
    public async Task GetList_ConCriterio_RetornaItemsFiltrados()
    {
        using var factory = new TestDbContextFactory();
        var service = new CatalogoService(factory);
        await service.Guardar(new CatalogoItemDto { CodigoSku = "SKU-10", Nombre = "Teclado Dell", Precio = 900m, Stock = 6, StockMinimoAlerta = 2 });
        await service.Guardar(new CatalogoItemDto { CodigoSku = "SKU-11", Nombre = "Cargador HP", Precio = 1100m, Stock = 7, StockMinimoAlerta = 2 });

        var resultado = await service.GetList(i => i.CodigoSku == "SKU-11");

        Assert.True(resultado.IsSuccess);
        Assert.Single(resultado.Value!);
        Assert.Equal("Cargador HP", resultado.Value![0].Nombre);
    }

    [Fact]
    public async Task ListarStockBajo_RetornaSoloItemsConStockMenorOIgualAlMinimo()
    {
        using var factory = new TestDbContextFactory();
        var service = new CatalogoService(factory);
        await service.Guardar(new CatalogoItemDto { CodigoSku = "SKU-BAJO", Nombre = "Conector USB-C", Precio = 300m, Stock = 2, StockMinimoAlerta = 3 });
        await service.Guardar(new CatalogoItemDto { CodigoSku = "SKU-ALTO", Nombre = "Pasta Termica", Precio = 400m, Stock = 15, StockMinimoAlerta = 3 });

        var bajoStock = await service.ListarStockBajo();

        Assert.Single(bajoStock);
        Assert.Equal("SKU-BAJO", bajoStock[0].CodigoSku);
    }

    [Fact]
    public async Task Eliminar_ConIdExistente_EliminaItem()
    {
        using var factory = new TestDbContextFactory();
        var service = new CatalogoService(factory);
        var dto = new CatalogoItemDto { CodigoSku = "SKU-DEL", Nombre = "Item Temporal", Precio = 100m, Stock = 1, StockMinimoAlerta = 1 };
        await service.Guardar(dto);

        var resultado = await service.Eliminar(dto.ItemId);

        Assert.True(resultado.IsSuccess);
        Assert.False(await service.Existe(dto.ItemId));
    }
}
