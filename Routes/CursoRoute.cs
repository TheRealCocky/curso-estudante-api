using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Routes;
using WebApplication1.Data;
public static class CursoRoute
{
    public static void CursoRoutes(this WebApplication app)
    {
        var routes = app.MapGroup("curso");
        
        routes.MapPost("", 
            async (Context db, CursoModelDto dto) =>
        {
            var curso = new CursoModel
            {
               Nome = dto.Nome,
               Descricao = dto.Descricao,
               DuracaoMeses = dto.DuracaoMeses
            };
            
            db.Cursos.Add(curso);
            await db.SaveChangesAsync();
            return Results.Ok(curso);
        });

        routes.MapGet("",
            async (Context db) =>
            {
                var cursos = await db.Cursos.ToListAsync();
             return   cursos == null  ? Results.NotFound("Nenhum curso encontrado"):  Results.Ok(cursos);
            });

        routes.MapGet("{id}",
            async (int id, Context db) =>
            {
                var curso = await db.Cursos.FindAsync(id);
                return curso == null ? Results.NotFound("Nenhum curso encontrado com esse Id") : Results.Ok(curso);
            });
        
        routes.MapPut("{id}",
            async (Context db, int id, CursoModelDto dto)=>
            {
               var curso = await db.Cursos.FindAsync(id);
               if (curso == null) return Results.NotFound("Nenhum curso encontrado com esse Id");
               curso.Nome = dto.Nome;
               curso.Descricao = dto.Descricao;
               curso.DuracaoMeses = dto.DuracaoMeses;
               await db.SaveChangesAsync();
               return Results.Ok(curso);
                
            });

        routes.MapDelete("{id}",
            async (int id, Context db) =>
            {
             var curso = await db.Cursos.FindAsync(id);
             if (curso == null) return Results.NotFound("Nenhum curso encontrado com esse Id");
             db.Cursos.Remove(curso);
             await db.SaveChangesAsync();
             return Results.Ok("Curso removido com sucesso");
            });
    }
}