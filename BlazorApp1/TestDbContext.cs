using Microsoft.EntityFrameworkCore;

// Source - https://stackoverflow.com/a/71325939
// Posted by fingers10, modified by community. See post 'Timeline' for change history
// Retrieved 2025-12-08, License - CC BY-SA 4.0

public class Name
{
    public int Id { get; set; }
    public string FullName { get; set; }
}


// Source - https://stackoverflow.com/a/71325939
// Posted by fingers10, modified by community. See post 'Timeline' for change history
// Retrieved 2025-12-08, License - CC BY-SA 4.0

public class EmployeeDataContext : DbContext
{
    public DbSet<Name> Names { get; set; } = default!;

    protected readonly IConfiguration Configuration;

    // https://www.allhandsontech.com/programming/blazor/how-to-sqlite-blazor-2/
    public EmployeeDataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    //public TestDbCOntext(DbContextOptions<TestDbCOntext> options) : base(options)
    //{
    //}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(Configuration.GetConnectionString("Data Source=Employees.db"));
    }
}
