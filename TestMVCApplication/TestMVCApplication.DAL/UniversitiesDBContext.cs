using Microsoft.EntityFrameworkCore;
using TestMVCApplication.DAL.DataModels;
using TestMVCApplication.DAL.EntityTypeConfigurations;

namespace TestMVCApplication.DAL;

public class UniversitiesDBContext : DbContext
{
    public UniversitiesDBContext()
    {
    }

    public UniversitiesDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<Student> Students { get; set; }

    public DbSet<University> Universities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UniversitiesDBContext).Assembly);

        // modelBuilder.Entity<Student>()
        //     .HasOne<University>()
        //     .WithMany()
        //     .HasForeignKey(p => p.UniversityId);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder
            .EnableSensitiveDataLogging()
            .UseSqlServer(
                @"Server=tcp:bits-bi.database.windows.net,1433;Initial Catalog=TestDBYouCanDropByDenisP;Persist Security Info=False;User ID=bits-bi-admin;Password=Kozlova7;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    }
}