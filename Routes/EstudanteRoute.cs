using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Routes;
using WebApplication1.Data;
public static class EstudanteRoute
{
    public static void EstudanteRoutes(this WebApplication app)
    {
        var routes = app.MapGroup("estudante");

        routes.MapPost("",
            async (Context db, EstudanteModelDto dto) =>
        {
            var estudante= new EstudanteModel
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Idade = dto.Idade,
                CursoId = dto.CursoId
            };
            db.Estudantes.Add(estudante);
            await db.SaveChangesAsync();
            return Results.Ok(estudante);
        });

        routes.MapGet("",
            async (Context db) =>
            {
                var estudante = await db.Estudantes.ToListAsync();
                return estudante == null ? Results.NotFound("Nenhum estudante encontrado") : Results.Ok(estudante);
                
            });
        
        routes.MapGet("{id}",
            async (int id, Context db) =>
            {
                var estudante = await db.Estudantes.FindAsync(id);
                return estudante == null ? Results.NotFound("Nenhum estudante encontrado com esse Id") : Results.Ok(estudante);
            });

        routes.MapPut("{id}",
            async (int id, Context db, EstudanteModelDto dto) =>
            {
             var estudante = await db.Estudantes.FindAsync(id);
             if (estudante == null) return Results.NotFound("Nenhum estudante encontrado com esse Id");
             estudante.Nome = dto.Nome;
             estudante.Email = dto.Email;
             estudante.Idade = dto.Idade;
             estudante.CursoId = dto.CursoId;
             await db.SaveChangesAsync();
             return Results.Ok(estudante);
            });
        
        routes.MapDelete("{id}",
            async (Context db, int id) =>
        {
            var estudante = await db.Estudantes.FindAsync(id);
            if (estudante == null) return Results.NotFound("Nenhum estudante encontrado com esse Id");
            db.Estudantes.Remove(estudante);
            await db.SaveChangesAsync();
            return Results.Ok("Estudante removido com sucesso");
        });
    }
}