using Microsoft.EntityFrameworkCore;
using RegistroLibro.Models;

namespace RegistroLibro.Context;

public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
{
    public DbSet<Estudiante> Estudiantes { get; set; }
}