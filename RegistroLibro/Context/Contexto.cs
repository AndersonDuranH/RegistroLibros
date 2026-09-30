using Microsoft.EntityFrameworkCore;
using RegistroLibro.Models;

namespace RegistroLibro.Context;

public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
{
    public DbSet<Libros> Libros { get; set; }
    public DbSet<Estudiante> Estudiantes { get; set; }
    public DbSet<Prestamos> Prestamos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Datos iniciales para pruebas
        modelBuilder.Entity<Libros>().HasData(
            new Libros { LibroId = 1, Titulo = "Cien años de soledad", Autor = "Gabriel García Márquez", AnoPublicacion = 1967 },
            new Libros { LibroId = 2, Titulo = "Don Quijote de la Mancha", Autor = "Miguel de Cervantes", AnoPublicacion = 1605 },
            new Libros { LibroId = 3, Titulo = "El Principito", Autor = "Antoine de Saint-Exupéry", AnoPublicacion = 1943 }
        );

        modelBuilder.Entity<Estudiante>().HasData(
            new Estudiante { EstudianteId = 1, Nombres = "Juan Pérez", Direccion = "Calle Central #12", Email = "juan.perez@email.com", FechaNacimiento = new DateOnly(2002, 5, 14) },
            new Estudiante { EstudianteId = 2, Nombres = "María Rodríguez", Direccion = "Av. Libertad #45", Email = "maria.rodriguez@email.com", FechaNacimiento = new DateOnly(2003, 8, 22) }
        );
    }
}