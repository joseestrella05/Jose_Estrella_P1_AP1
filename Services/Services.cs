using Jose_Estrella_P1_AP1.DAL;
using Jose_Estrella_P1_AP1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Jose_Estrella_P1_AP1.Services;

public class Services(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Modelos.AnyAsync(x => x.Id == id);
    }
    private async Task<bool> Insertar()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
     
        return await contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar()
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
       
        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<bool> Guardar()
    {
        return await Insertar();
    }
    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
       
        return true ;
    }
    public async Task<Modelo?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return null;

    }
    public async Task<Modelo?> BuscarDescripcion(string descripcion)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return null;
    }

    //public async Task<List<Modelo>> Listar(Expression<Func<Modelo, bool>> criterio)
   // {
        //await using var contexto = await DbFactory.CreateDbContextAsync();

        
        
   // }
}
