using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using RegistroLibro.Context;
using RegistroLibro.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RegistroLibro.Services;

public class LibrosServices(IDbContextFactory<Contexto>
    DbFactory) : IService<Libros, int>
{
    private async Task<bool> Existe(int libroId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Libros
            .AnyAsync(p => p.LibroId == libroId);
    }

    private async Task<bool> Insertar(Libros libro)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Libros.Add(libro);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Libros libro)
    {
        if (!await Existe(libro.LibroId))
        {
            return await Insertar(libro);
        }
        else
        {
            return await Modificar(libro);
        }
    }

    private async Task<bool> Modificar(Libros libro)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(libro);
        return await contexto
            .SaveChangesAsync() > 0;
    }

    public async Task<Libros?> Buscar(int libroId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Libros
            .FirstOrDefaultAsync(p => p.LibroId == libroId);
    }

    public async Task<bool> Eliminar(int libroId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Libros
            .Where(p => p.LibroId == libroId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Libros>> GetList(Expression<Func<Libros, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Libros
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}
