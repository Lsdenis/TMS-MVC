using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestMVCApplication.DAL.DataModels;

namespace TestMVCApplication.DAL.EntityTypeConfigurations;

public class UniversityEntityTypeConfiguration : IEntityTypeConfiguration<University>
{
    public void Configure(EntityTypeBuilder<University> builder)
    {
        builder.HasKey(university => university.Id);
    }
}