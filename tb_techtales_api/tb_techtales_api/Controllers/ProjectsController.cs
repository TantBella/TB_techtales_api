using Microsoft.AspNetCore.Mvc;
using tb_techtales_api.Data;
using tb_techtales_api.Models;
using Microsoft.EntityFrameworkCore;

namespace tb_techtales_api.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly TechTalesApiDbContext _context;

        public ProjectsController(TechTalesApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            return Ok(await _context.Projects.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProjects), new { id = project.Id }, project);
        }
    }
}
