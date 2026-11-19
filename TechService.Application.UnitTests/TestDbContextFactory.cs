using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using TechService.Infrastructure.Data;
using TechService.Infrastructure.Models;

namespace TechService.Application.UnitTests;

public sealed class TestDbContextFactory : IDbContextFactory<TechServiceDbContext>, IDisposable
{
    private readonly SqliteConnection _connection;
    private readonly DbContextOptions<TechServiceDbContext> _options;

    public TestDbContextFactory()
    {
        _connection = new SqliteConnection("DataSource=:memory:;Foreign Keys=False");
        _connection.Open();

        _options = new DbContextOptionsBuilder<TechServiceDbContext>()
            .UseSqlite(_connection)
            .ReplaceService<IModelCustomizer, SqliteModelCustomizer>()
            .Options;

        using var context = CreateDbContext();
        context.Database.EnsureCreated();
        SembrarCatalogosBase(context);
    }

    private static void SembrarCatalogosBase(TechServiceDbContext context)
    {
        context.TiposItems.AddRange(
            new TiposItem { Nombre = "Repuesto" },
            new TiposItem { Nombre = "Accesorio" }
        );
        context.TiposEquipos.AddRange(
            new TiposEquipo { Nombre = "Smartphone" },
            new TiposEquipo { Nombre = "Laptop" }
        );
        context.Roles.AddRange(
            new Rol { Nombre = "Admin", Descripcion = "Administrador" },
            new Rol { Nombre = "Tecnico", Descripcion = "Tecnico de taller" }
        );
        context.Estados.AddRange(
            new Estado { Nombre = "Recibido" },
            new Estado { Nombre = "En Reparacion" },
            new Estado { Nombre = "Entregado" }
        );
        context.Prioridades.AddRange(
            new Prioridade { Nombre = "Normal" },
            new Prioridade { Nombre = "Alta" }
        );
        context.MetodosPagos.AddRange(
            new MetodosPago { Nombre = "Efectivo" },
            new MetodosPago { Nombre = "Tarjeta" }
        );
        context.EstadosAprobacions.AddRange(
            new EstadosAprobacion { Nombre = "Pendiente" },
            new EstadosAprobacion { Nombre = "Aprobado" }
        );
        context.SaveChanges();
    }

    public TechServiceDbContext CreateDbContext() => new(_options);

    public Task<TechServiceDbContext> CreateDbContextAsync(CancellationToken cancellationToken = default) =>
        Task.FromResult(CreateDbContext());

    public void Dispose()
    {
        _connection.Dispose();
    }

    private sealed class SqliteModelCustomizer(ModelCustomizerDependencies dependencies)
        : RelationalModelCustomizer(dependencies)
    {
        public override void Customize(ModelBuilder modelBuilder, DbContext context)
        {
            base.Customize(modelBuilder, context);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.GetDefaultValueSql() != null)
                    {
                        property.SetDefaultValueSql(null);
                    }

                    if (property.GetComputedColumnSql() != null)
                    {
                        property.SetComputedColumnSql(null);
                        if (!property.IsPrimaryKey())
                        {
                            property.ValueGenerated = ValueGenerated.Never;
                        }
                    }
                }
            }
        }
    }
}
