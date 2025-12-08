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

public class TestDbCOntext : DbContext
{
    public DbSet<Name> Names { get; set; } = default!;

    public TestDbCOntext(DbContextOptions<TestDbCOntext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Name>().ToTable("Names");
        modelBuilder.Entity<Name>().HasIndex(x => x.FullName);
        // TODO: Decide collation
        modelBuilder.Entity<Name>().Property(x => x.FullName).UseCollation("nocase");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.LogTo(Console.WriteLine, LogLevel.Warning)
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging(true);
    }
}
