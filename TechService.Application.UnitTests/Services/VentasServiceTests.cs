using TechService.Application.Dtos;
using TechService.Application.Services;

namespace TechService.Application.UnitTests.Services;

public class VentasServiceTests
{
    [Fact]
    public async Task Guardar_CuandoNoExiste_InsertaVentaConDetallesYAsignaId()
    {
        using var factory = new TestDbContextFactory();
        var service = new VentasService(factory);
        var dto = new VentaDto
        {
            ClienteId = 1,
            MetodoPagoId = 1,
            Subtotal = 1000m,
            Itbis = 180m,
            TotalVenta = 1180m,
            Detalles =
            [
                new DetalleVentaDto { ItemId = 1, Cantidad = 2, PrecioUnitario = 500m }
            ]
        };

        var resultado = await service.Guardar(dto);

        Assert.True(resultado.IsSuccess);
        Assert.True(dto.VentaId > 0);
        Assert.True(await service.Existe(dto.VentaId));
    }

    [Fact]
    public async Task Guardar_CuandoExiste_ModificaVenta()
    {
        using var factory = new TestDbContextFactory();
        var service = new VentasService(factory);
        var dto = new VentaDto
        {
            ClienteId = 1,
            MetodoPagoId = 1,
            Subtotal = 500m,
            Itbis = 90m,
            TotalVenta = 590m,
            Detalles = [new DetalleVentaDto { ItemId = 1, Cantidad = 1, PrecioUnitario = 500m }]
        };
        await service.Guardar(dto);

        dto.MetodoPagoId = 2;
        dto.Subtotal = 1000m;
        dto.Itbis = 180m;
        dto.TotalVenta = 1180m;
        var resultado = await service.Guardar(dto);

        Assert.True(resultado.IsSuccess);
        var buscado = await service.Buscar(dto.VentaId);
        Assert.NotNull(buscado.Value);
        Assert.Equal(2, buscado.Value!.MetodoPagoId);
        Assert.Equal(1180m, buscado.Value.TotalVenta);
    }

    [Fact]
    public async Task Buscar_ConIdExistente_RetornaVentaConSusDetalles()
    {
        using var factory = new TestDbContextFactory();
        var service = new VentasService(factory);
        var dto = new VentaDto
        {
            ClienteId = 1,
            MetodoPagoId = 1,
            Subtotal = 1500m,
            Itbis = 270m,
            TotalVenta = 1770m,
            Detalles =
            [
                new DetalleVentaDto { ItemId = 1, Cantidad = 1, PrecioUnitario = 500m },
                new DetalleVentaDto { ItemId = 2, Cantidad = 2, PrecioUnitario = 500m }
            ]
        };
        await service.Guardar(dto);

        var resultado = await service.Buscar(dto.VentaId);

        Assert.NotNull(resultado.Value);
        Assert.Equal(2, resultado.Value!.Detalles.Count);
        Assert.Equal(1770m, resultado.Value.TotalVenta);
    }

    [Fact]
    public async Task Buscar_ConIdInexistente_RetornaNull()
    {
        using var factory = new TestDbContextFactory();
        var service = new VentasService(factory);

        var resultado = await service.Buscar(999);

        Assert.Null(resultado.Value);
    }

    [Fact]
    public async Task GetList_ConCriterio_RetornaVentasFiltradasConDetalles()
    {
        using var factory = new TestDbContextFactory();
        var service = new VentasService(factory);
        await service.Guardar(new VentaDto
        {
            ClienteId = 1,
            MetodoPagoId = 1,
            Subtotal = 100m,
            Itbis = 18m,
            TotalVenta = 118m,
            Detalles = [new DetalleVentaDto { ItemId = 1, Cantidad = 1, PrecioUnitario = 100m }]
        });
        await service.Guardar(new VentaDto
        {
            ClienteId = 2,
            MetodoPagoId = 2,
            Subtotal = 200m,
            Itbis = 36m,
            TotalVenta = 236m,
            Detalles = [new DetalleVentaDto { ItemId = 2, Cantidad = 1, PrecioUnitario = 200m }]
        });

        var resultado = await service.GetList(v => v.MetodoPagoId == 2);

        Assert.True(resultado.IsSuccess);
        Assert.Single(resultado.Value!);
        Assert.Single(resultado.Value![0].Detalles);
        Assert.Equal(236m, resultado.Value![0].TotalVenta);
    }

    [Fact]
    public async Task Eliminar_ConIdExistente_EliminaVentaYDetalles()
    {
        using var factory = new TestDbContextFactory();
        var service = new VentasService(factory);
        var dto = new VentaDto
        {
            ClienteId = 1,
            MetodoPagoId = 1,
            Subtotal = 300m,
            Itbis = 54m,
            TotalVenta = 354m,
            Detalles = [new DetalleVentaDto { ItemId = 1, Cantidad = 1, PrecioUnitario = 300m }]
        };
        await service.Guardar(dto);

        var resultado = await service.Eliminar(dto.VentaId);

        Assert.True(resultado.IsSuccess);
        Assert.False(await service.Existe(dto.VentaId));
    }
}
