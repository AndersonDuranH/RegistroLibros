using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RegistroLibro.Context;
using RegistroLibro.Models;
using RegistroLibro.Services;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace RegistroLibro.Tests;

public class PrestamosServicesTests : IDisposable
{
    private readonly SqliteConnection _connection;
    private readonly IDbContextFactory<Contexto> _dbFactory;

    public PrestamosServicesTests()
    {
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();

        var options = new DbContextOptionsBuilder<Contexto>()
            .UseSqlite(_connection)
            .Options;

        using var context = new Contexto(options);
        context.Database.EnsureCreated();

        _dbFactory = new TestDbContextFactory(options);
    }

    private class TestDbContextFactory(DbContextOptions<Contexto> options) : IDbContextFactory<Contexto>
    {
        public Contexto CreateDbContext() => new Contexto(options);
        public Task<Contexto> CreateDbContextAsync(CancellationToken cancellationToken = default) 
            => Task.FromResult(new Contexto(options));
    }

    [Fact]
    public async Task Guardar_PrestamoValido_DebeGuardarExitosamente()
    {
        var service = new PrestamosServices(_dbFactory);
        var prestamo = new Prestamos
        {
            EstudianteId = 1,
            LibroId = 1,
            FechaPrestamo = DateTime.Today,
            FechaDevolucion = DateTime.Today.AddDays(7),
            Concepto = "Préstamo para proyecto final"
        };

        var resultado = await service.Guardar(prestamo);

        Assert.True(resultado);
        Assert.True(prestamo.PrestamoId > 0);
    }

    [Fact]
    public async Task Buscar_PrestamoExistente_DebeRetornarPrestamoConRelaciones()
    {
        var service = new PrestamosServices(_dbFactory);
        var prestamo = new Prestamos
        {
            EstudianteId = 1,
            LibroId = 1,
            FechaPrestamo = DateTime.Today,
            FechaDevolucion = DateTime.Today.AddDays(7),
            Concepto = "Lectura obligatoria"
        };
        await service.Guardar(prestamo);

        var encontrado = await service.Buscar(prestamo.PrestamoId);

        Assert.NotNull(encontrado);
        Assert.Equal("Lectura obligatoria", encontrado.Concepto);
        Assert.NotNull(encontrado.Estudiante);
        Assert.NotNull(encontrado.Libro);
    }

    [Fact]
    public async Task Eliminar_PrestamoExistente_DebeEliminarlo()
    {
        var service = new PrestamosServices(_dbFactory);
        var prestamo = new Prestamos
        {
            EstudianteId = 2,
            LibroId = 2,
            FechaPrestamo = DateTime.Today,
            FechaDevolucion = DateTime.Today.AddDays(5),
            Concepto = "Eliminar de prueba"
        };
        await service.Guardar(prestamo);

        var eliminado = await service.Eliminar(prestamo.PrestamoId);
        var buscado = await service.Buscar(prestamo.PrestamoId);

        Assert.True(eliminado);
        Assert.Null(buscado);
    }

    public void Dispose()
    {
        _connection.Dispose();
    }
}
