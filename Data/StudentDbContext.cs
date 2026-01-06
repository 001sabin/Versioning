
using Microsoft.EntityFrameworkCore;
using Versioning.Model;

namespace Versioning.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) :base (options) { }
        public DbSet<Student> Students { get; set; }
    }
  
}
