using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using RegistroLibro.Context;
using RegistroLibro.Models;
using System.Linq.Expressions;

namespace RegistroLibro.Services;

public class EstudiantesServices(IDbContextFactory<Contexto> dbFactory) : IService<Estudiante, int>
{
    private async Task<bool> Existe(int id)
    {
        await using var contexto = await dbFactory.CreateDbContextAsync();
        return await contexto.Estudiantes.AnyAsync(p => p.EstudianteId == id);
    }
    public async Task<bool> Guardar(Estudiante estudiante)
    {
        await using var contexto = await dbFactory.CreateDbContextAsync();
        if (await Existe(estudiante.EstudianteId)) contexto.Update(estudiante);
        else contexto.Estudiantes.Add(estudiante);
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<Estudiante?> Buscar(int id)
    {
        await using var contexto = await dbFactory.CreateDbContextAsync();
        return await contexto.Estudiantes.FirstOrDefaultAsync(p => p.EstudianteId == id);
    }
    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await dbFactory.CreateDbContextAsync();
        return await contexto.Estudiantes.Where(p => p.EstudianteId == id).ExecuteDeleteAsync() > 0;
    }
    public async Task<List<Estudiante>> GetList(Expression<Func<Estudiante, bool>> criterio)
    {
        await using var contexto = await dbFactory.CreateDbContextAsync();
        return await contexto.Estudiantes.Where(criterio).AsNoTracking().ToListAsync();
    }
}