using Microsoft.EntityFrameworkCore;

namespace UKParliament.CodeTest.Data;

public class PersonManagerContext : DbContext
{
    public PersonManagerContext(DbContextOptions<PersonManagerContext> options)
        : base(options)
    {
    }

    public DbSet<Person> People { get; set; }

    public DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().ToTable("People");
        modelBuilder.Entity<Department>().ToTable("Department");

        modelBuilder.Entity<Person>(b =>
        {
            b.Property(e => e.FirstName).HasMaxLength(500).IsRequired();
            b.Property(e => e.LastName).HasMaxLength(500).IsRequired();
            b.Property(e => e.DepartmentId).IsRequired();
            b.Property(e => e.DateOfBirth).IsRequired();
            b.Property(e => e.CreatedOn).IsRequired();
            b.Property(e => e.UpdatedOn).IsRequired();
        });

        modelBuilder.Entity<Person>()
                       .HasOne(p => p.Department)
                       .WithMany(d => d.People)
                       .HasForeignKey(p => p.DepartmentId)
                       .IsRequired(true);

        modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "Sales" },
            new Department { Id = 2, Name = "Marketing" },
            new Department { Id = 3, Name = "Finance" },
            new Department { Id = 4, Name = "HR" });

        modelBuilder.Entity<Person>().HasData(
           new Person { Id = 1, FirstName = "Sharath", LastName = "Thokala", DepartmentId = 1, DateOfBirth = new DateOnly(1986, 02, 12), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow });
    }
}