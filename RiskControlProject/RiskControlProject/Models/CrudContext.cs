using Microsoft.EntityFrameworkCore;

namespace RiskControlProject.Models;

public class CrudContext : DbContext
{
    public CrudContext(DbContextOptions<CrudContext> options) : base(options)
    {
    }


    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Classroom> Classrooms { get; set; } = null!;
}