
using Microsoft.EntityFrameworkCore;
using tb_techtales_api.Data;
using tb_techtales_api.Models;

namespace tb_techtales_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<TechTalesApiDbContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



            builder.Services.AddAuthorization();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();
     
            var app = builder.Build();

     
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            //app.MapGet("/skills", async (TechTalesApiDbContext db) =>
            //    Results.Ok(await db.Skills.ToListAsync()));

            //app.MapPost("/skills", async (Skill skill, TechTalesApiDbContext db) =>
            //{
            //    db.Skills.Add(skill);
            //    await db.SaveChangesAsync();
            //    return Results.Created($"/skills/{skill.Id}", skill);
            //});

            //app.MapGet("/projects", async (TechTalesApiDbContext db) =>
            //    Results.Ok(await db.Projects.ToListAsync()));

            //app.MapPost("/projects", async (Project project, TechTalesApiDbContext db) =>
            //{
            //    db.Projects.Add(project);
            //    await db.SaveChangesAsync();
            //    return Results.Created($"/projects/{project.Id}", project);
            //});

            app.MapControllers();

            app.Run();
        }
    }
}
