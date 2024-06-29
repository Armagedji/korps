using Microsoft.EntityFrameworkCore;
using Practice6.Models;


public class ModelContext: DbContext
{
    public ModelContext(DbContextOptions<ModelContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public ModelContext() { }

    public virtual DbSet<Achievement> Achievements { get; set; }
    public virtual DbSet<Achievement_type> Achievement_types { get; set; }
    public virtual DbSet<Department> Departments { get; set; }
    public virtual DbSet<Discipline> Disciplines { get; set; }
    public virtual DbSet<Performance> Performances { get; set; }
    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<Teacher> Teachers { get; set; }
}