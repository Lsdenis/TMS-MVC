using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestMVCApplication.DAL.DataModels;

namespace TestMVCApplication.DAL.EntityTypeConfigurations;

public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(student => student.Id);

        builder.HasOne<University>().WithMany().HasForeignKey(student => student.UniversityId);
    }
}