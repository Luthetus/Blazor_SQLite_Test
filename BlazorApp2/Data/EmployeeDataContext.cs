using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Data;

// https://www.allhandsontech.com/programming/blazor/how-to-sqlite-blazor-2/#creating-database-model
public class EmployeeDataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public EmployeeDataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Data\\Employees.db");
        //optionsBuilder.UseSqlite(Configuration.GetConnectionString("EmployeeDB"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .ToTable("Employee");

        modelBuilder.Entity<Employee>()
            .HasData(
                new Employee
                {
                    Id = 1,
                    FirstName = "Nonie",
                    LastName = "Morgue",
                    Email = "nmorgue0@disqus.com",
                    Department = "Research and Development",
                    Avatar = "https://robohash.org/autautea.png?size=100x100&set=set1"
                }
            );
    }

    public DbSet<Employee> Employees { get; set; }
}
