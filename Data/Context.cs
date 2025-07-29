using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    public DbSet<CursoModel> Cursos { get; set; }
    public DbSet<EstudanteModel> Estudantes { get; set; }
}