using Jose_Estrella_P1_AP1.DAL;
using Jose_Estrella_P1_AP1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Jose_Estrella_P1_AP1.Services;

public class IngresosService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Ingresos.AnyAsync(c => c.IngresoId == id);
    }
    private async Task<bool> Insertar(Ingresos Ingreso)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Ingresos.Add(Ingreso);
        return await contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(Ingresos ingreso)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var local = _context.Ingresos.Local
            .FirstOrDefault(i => i.IngresoId == ingreso.IngresoId);
        _context.Entry(ingreso).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<bool> Guardar(Ingresos ingreso)
    {
        if (!await Existe(ingreso.IngresoId))
            return await Insertar(ingreso);
        else
            return await Modificar(ingreso);
    }
    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var Ingreso = await contexto.Ingresos
            .Where(i => i.IngresoId == id).ExecuteDeleteAsync();
        return Ingreso > 0;
    }
    public async Task<Ingresos?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Ingresos.AsNoTracking().
            FirstOrDefaultAsync(i => i.IngresoId == id);
    }
    public async Task<List<Ingresos>> Listar(Expression<Func<Ingresos, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Ingresos.AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}

   

