using Jose_Estrella_P1_AP1.Models;
using Microsoft.EntityFrameworkCore;

namespace Jose_Estrella_P1_AP1.DAL;

public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
{
    public DbSet<Modelo> Modelos { get; set; }
}
