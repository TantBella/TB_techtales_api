using Microsoft.AspNetCore.Mvc;
using tb_techtales_api.Data;
using tb_techtales_api.Models;
using Microsoft.EntityFrameworkCore;

namespace tb_techtales_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillsController : ControllerBase
    {
        private readonly TechTalesApiDbContext _context;

        public SkillsController(TechTalesApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetSkills()
        {
            return Ok(await _context.Skills.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateSkill(Skill skill)
        {
            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSkills), new { id = skill.Id }, skill);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteSkillByName([FromQuery] string name)
        {
            var skill = await _context.Skills
                .FirstOrDefaultAsync(s => s.Technology.ToLower() == name.ToLower());

            if (skill == null)
            {
                return NotFound($"Skill with name '{name}' not found.");
            }

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
            return Ok("Skillen raderades");
        }
    }
}
