using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tb_techtales_api.Models;

namespace tb_techtales_api.Data
{
    public class TechTalesApiDbContext : DbContext
    {
        public TechTalesApiDbContext(DbContextOptions<TechTalesApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
