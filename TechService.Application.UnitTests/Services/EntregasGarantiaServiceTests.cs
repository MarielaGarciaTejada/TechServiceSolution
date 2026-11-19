using TechService.Application.Dtos;
using TechService.Application.Services;
using TechService.Infrastructure.Models;

namespace TechService.Application.UnitTests.Services;

public class EntregasGarantiaServiceTests
{
    private static async Task<int> SembrarOrdenBaseAsync(TestDbContextFactory factory, decimal costoManoObra = 1500m)
    {
        await using var contexto = await factory.CreateDbContextAsync();
        var orden = new OrdenesReparacion
        {
            CodigoTracking = $"ORD-{Guid.NewGuid():N}"[..12],
            ClienteId = 1,
            TipoEquipoId = 1,
            EstadoId = 1,
            PrioridadId = 1,
            MarcaModelo = "Laptop Lenovo",
            NumeroSerieImei = "SN-TEST-01",
            FalloReportado = "No carga",
            FechaEntregaEstimada = DateTime.UtcNow.AddDays(2),
            CostoManoObra = costoManoObra
        };
        contexto.OrdenesReparacions.Add(orden);
        await contexto.SaveChangesAsync();
        return orden.OrdenId;
    }

    [Fact]
    public async Task Guardar_ConOrdenValida_InsertaEntregaYAsignaId()
    {
        using var factory = new TestDbContextFactory();
        var ordenId = await SembrarOrdenBaseAsync(factory);
        var service = new EntregasGarantiaService(factory);
        var dto = new EntregaGarantiaDto
        {
            OrdenId = ordenId,
            MetodoPagoId = 1,
            DiaGarantia = 90,
            TotalManoObra = 1500m,
            TotalRepuesto = 500m,
            TotalCobrado = 2000m,
            ObservacionFinal = "Entregado funcionando correctamente"
        };

        var resultado = await service.Guardar(dto);

        Assert.True(resultado.IsSuccess);
        Assert.True(dto.EntregaId > 0);
        Assert.True(await service.Existe(dto.EntregaId));
    }

    [Fact]
    public async Task Guardar_CuandoExiste_ModificaEntrega()
    {
        using var factory = new TestDbContextFactory();
        var ordenId = await SembrarOrdenBaseAsync(factory);
        var service = new EntregasGarantiaService(factory);
        var dto = new EntregaGarantiaDto
        {
            OrdenId = ordenId,
            MetodoPagoId = 1,
            DiaGarantia = 30,
            TotalManoObra = 1000m,
            TotalRepuesto = 0m,
            TotalCobrado = 1000m,
            ObservacionFinal = "Observacion inicial"
        };
        await service.Guardar(dto);

        dto.DiaGarantia = 60;
        dto.ObservacionFinal = "Garantia extendida a 60 dias";
        var resultado = await service.Guardar(dto);

        Assert.True(resultado.IsSuccess);
        var buscado = await service.Buscar(dto.EntregaId);
        Assert.NotNull(buscado.Value);
        Assert.Equal(60, buscado.Value!.DiaGarantia);
        Assert.Equal("Garantia extendida a 60 dias", buscado.Value.ObservacionFinal);
    }

    [Fact]
    public async Task Buscar_ConIdInexistente_RetornaNull()
    {
        using var factory = new TestDbContextFactory();
        var service = new EntregasGarantiaService(factory);

        var resultado = await service.Buscar(999);

        Assert.Null(resultado.Value);
    }

    [Fact]
    public async Task GetList_ConCriterio_RetornaEntregasFiltradas()
    {
        using var factory = new TestDbContextFactory();
        var orden1 = await SembrarOrdenBaseAsync(factory);
        var orden2 = await SembrarOrdenBaseAsync(factory);
        var service = new EntregasGarantiaService(factory);

        await service.Guardar(new EntregaGarantiaDto
        {
            OrdenId = orden1,
            MetodoPagoId = 1,
            DiaGarantia = 30,
            TotalManoObra = 1000m,
            TotalRepuesto = 0m,
            TotalCobrado = 1000m,
            ObservacionFinal = "Entrega 1"
        });
        await service.Guardar(new EntregaGarantiaDto
        {
            OrdenId = orden2,
            MetodoPagoId = 2,
            DiaGarantia = 90,
            TotalManoObra = 2000m,
            TotalRepuesto = 500m,
            TotalCobrado = 2500m,
            ObservacionFinal = "Entrega 2"
        });

        var resultado = await service.GetList(e => e.OrdenId == orden2);

        Assert.True(resultado.IsSuccess);
        Assert.Single(resultado.Value!);
        Assert.Equal(2500m, resultado.Value![0].TotalCobrado);
    }

    [Fact]
    public async Task ObtenerEstadoId_ConNombreExistente_RetornaIdDelEstado()
    {
        using var factory = new TestDbContextFactory();

        var service = new EntregasGarantiaService(factory);
        var estadoId = await service.ObtenerEstadoId("entregado");

        Assert.NotNull(estadoId);
        Assert.True(estadoId > 0);
    }

    [Fact]
    public async Task Eliminar_ConIdExistente_EliminaEntrega()
    {
        using var factory = new TestDbContextFactory();
        var ordenId = await SembrarOrdenBaseAsync(factory);
        var service = new EntregasGarantiaService(factory);
        var dto = new EntregaGarantiaDto
        {
            OrdenId = ordenId,
            MetodoPagoId = 1,
            DiaGarantia = 30,
            TotalManoObra = 800m,
            TotalRepuesto = 0m,
            TotalCobrado = 800m,
            ObservacionFinal = "Temporal"
        };
        await service.Guardar(dto);

        var resultado = await service.Eliminar(dto.EntregaId);

        Assert.True(resultado.IsSuccess);
        Assert.False(await service.Existe(dto.EntregaId));
    }
}
