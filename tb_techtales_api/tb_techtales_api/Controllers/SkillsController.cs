using Microsoft.AspNetCore.Mvc;
using tb_techtales_api.Models;
using Microsoft.EntityFrameworkCore;
using tb_techtales;

namespace tb_techtales_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SkillsController(ApplicationDbContext context)
        { 
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetSkills()
        {
            var skills = await _context.Skills.ToListAsync();
            return Ok(skills);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSkill(Skill skill)
        {
            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSkills), new { id = skill.Id }, skill);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSkill(Guid id, [FromBody] Skill updatedSkill)
        {
            var skill = await _context.Skills.FirstOrDefaultAsync(s => s.Id == id);

            if (skill == null)
            {
                return NotFound($"Skill med id '{id}' hittades inte.");
            }

            skill.Technology = updatedSkill.Technology;
            skill.YearsOfExperience = updatedSkill.YearsOfExperience;
            skill.Level = updatedSkill.Level;

            _context.Skills.Update(skill);
            await _context.SaveChangesAsync();

            return Ok($"Skill med id '{id}' har uppdaterats.");
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
