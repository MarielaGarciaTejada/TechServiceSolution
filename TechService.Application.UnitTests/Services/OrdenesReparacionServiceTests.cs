using TechService.Application.Dtos;
using TechService.Application.Services;

namespace TechService.Application.UnitTests.Services;

public class OrdenesReparacionServiceTests
{
    private static async Task<(int Cliente1Id, int Cliente2Id)> SembrarClientesAsync(TestDbContextFactory factory)
    {
        var clientesService = new ClientesService(factory);
        var c1 = new ClienteDto { Nombre = "Cliente Uno" };
        var c2 = new ClienteDto { Nombre = "Cliente Dos" };
        await clientesService.Guardar(c1);
        await clientesService.Guardar(c2);
        return (c1.ClienteId, c2.ClienteId);
    }

    [Fact]
    public async Task Guardar_SinCodigoTracking_InsertaOrdenYGeneraCodigoTracking()
    {
        using var factory = new TestDbContextFactory();
        var service = new OrdenesReparacionService(factory);
        var dto = new OrdenDto
        {
            ClienteId = 1,
            TipoEquipoId = 1,
            EstadoId = 1,
            PrioridadId = 1,
            MarcaModelo = "iPhone 14 Pro",
            NumeroSerieImei = "IMEI123456789",
            FalloReportado = "No enciende",
            FechaEntregaEstimada = DateTime.UtcNow.AddDays(3),
            CostoManoObra = 1500m
        };

        var resultado = await service.Guardar(dto);

        Assert.True(resultado.IsSuccess);
        Assert.True(dto.OrdenId > 0);
        Assert.StartsWith("ORD-", dto.CodigoTracking);
        Assert.True(await service.Existe(dto.OrdenId));
    }

    [Fact]
    public async Task Guardar_CuandoExiste_ModificaOrden()
    {
        using var factory = new TestDbContextFactory();
        var (clienteId, _) = await SembrarClientesAsync(factory);
        var service = new OrdenesReparacionService(factory);
        var dto = new OrdenDto
        {
            CodigoTracking = "ORD-MOD01",
            ClienteId = clienteId,
            TipoEquipoId = 1,
            EstadoId = 1,
            PrioridadId = 1,
            MarcaModelo = "Samsung S23",
            NumeroSerieImei = "IMEI-999",
            FalloReportado = "Pantalla rota",
            FechaEntregaEstimada = DateTime.UtcNow.AddDays(2),
            CostoManoObra = 1000m
        };
        await service.Guardar(dto);

        dto.EstadoId = 2;
        dto.ObservacionTecnico = "Cambio de pantalla en curso";
        dto.CheckRevisionPlaca = true;
        var resultado = await service.Guardar(dto);

        Assert.True(resultado.IsSuccess);
        var buscado = await service.Buscar(dto.OrdenId);
        Assert.NotNull(buscado.Value);
        Assert.Equal(2, buscado.Value!.EstadoId);
        Assert.Equal("Cambio de pantalla en curso", buscado.Value.ObservacionTecnico);
        Assert.True(buscado.Value.CheckRevisionPlaca);
    }

    [Fact]
    public async Task Buscar_ConIdInexistente_RetornaNull()
    {
        using var factory = new TestDbContextFactory();
        var service = new OrdenesReparacionService(factory);

        var resultado = await service.Buscar(999);

        Assert.Null(resultado.Value);
    }

    [Fact]
    public async Task GetList_ConCriterio_RetornaOrdenesFiltradas()
    {
        using var factory = new TestDbContextFactory();
        var (cliente1Id, cliente2Id) = await SembrarClientesAsync(factory);
        var service = new OrdenesReparacionService(factory);
        await service.Guardar(new OrdenDto
        {
            CodigoTracking = "ORD-A1",
            ClienteId = cliente1Id,
            TipoEquipoId = 1,
            EstadoId = 1,
            PrioridadId = 1,
            MarcaModelo = "Dell XPS",
            NumeroSerieImei = "SN-01",
            FalloReportado = "Sobrecalentamiento",
            FechaEntregaEstimada = DateTime.UtcNow.AddDays(1)
        });
        await service.Guardar(new OrdenDto
        {
            CodigoTracking = "ORD-B2",
            ClienteId = cliente2Id,
            TipoEquipoId = 1,
            EstadoId = 2,
            PrioridadId = 1,
            MarcaModelo = "MacBook Air",
            NumeroSerieImei = "SN-02",
            FalloReportado = "Bateria dañada",
            FechaEntregaEstimada = DateTime.UtcNow.AddDays(2)
        });

        var resultado = await service.GetList(o => o.CodigoTracking == "ORD-B2");

        Assert.True(resultado.IsSuccess);
        Assert.Single(resultado.Value!);
        Assert.Equal("MacBook Air", resultado.Value![0].MarcaModelo);
    }

    [Fact]
    public async Task Eliminar_ConIdExistente_EliminaOrden()
    {
        using var factory = new TestDbContextFactory();
        var service = new OrdenesReparacionService(factory);
        var dto = new OrdenDto
        {
            CodigoTracking = "ORD-DEL1",
            ClienteId = 1,
            TipoEquipoId = 1,
            EstadoId = 1,
            PrioridadId = 1,
            MarcaModelo = "HP Pavilion",
            NumeroSerieImei = "SN-DEL",
            FalloReportado = "Teclado",
            FechaEntregaEstimada = DateTime.UtcNow.AddDays(1)
        };
        await service.Guardar(dto);

        var resultado = await service.Eliminar(dto.OrdenId);

        Assert.True(resultado.IsSuccess);
        Assert.False(await service.Existe(dto.OrdenId));
    }
}
