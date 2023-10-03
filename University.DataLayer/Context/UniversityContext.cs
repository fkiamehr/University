using Microsoft.EntityFrameworkCore;
using University.DataLayer.Entities;

namespace University.DataLayer.Context
{
    public class UniversityContext:DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentLevel> StudentLevels { get; set; }
    }
}
