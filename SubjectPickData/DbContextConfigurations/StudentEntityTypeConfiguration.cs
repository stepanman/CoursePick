using SubjectPickData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SubjectPickData.DbContextConfigurations
{
    public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .Property(nameof(Student.Resume))
                .IsRequired(false);
            builder
                .Property(nameof(Student.ImagePath))
                .IsRequired(false);
        }
    }
}
