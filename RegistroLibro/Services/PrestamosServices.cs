using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using RegistroLibro.Context;
using RegistroLibro.Models;
using System.Linq.Expressions;

namespace RegistroLibro.Services;

public class PrestamosServices(IDbContextFactory<Contexto> dbFactory) : IService<Prestamos, int>
{
    private async Task<bool> Existe(int id)
    {
        await using var contexto = await dbFactory.CreateDbContextAsync();
        return await contexto.Prestamos.AnyAsync(p => p.PrestamoId == id);
    }

    public async Task<bool> Guardar(Prestamos prestamo)
    {
        await using var contexto = await dbFactory.CreateDbContextAsync();
        if (await Existe(prestamo.PrestamoId))
            contexto.Prestamos.Update(prestamo);
        else
            contexto.Prestamos.Add(prestamo);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Prestamos?> Buscar(int id)
    {
        await using var contexto = await dbFactory.CreateDbContextAsync();
        return await contexto.Prestamos
            .Include(p => p.Estudiante)
            .Include(p => p.Libro)
            .FirstOrDefaultAsync(p => p.PrestamoId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await dbFactory.CreateDbContextAsync();
        return await contexto.Prestamos
            .Where(p => p.PrestamoId == id)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Prestamos>> GetList(Expression<Func<Prestamos, bool>> criterio)
    {
        await using var contexto = await dbFactory.CreateDbContextAsync();
        return await contexto.Prestamos
            .Include(p => p.Estudiante)
            .Include(p => p.Libro)
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}
