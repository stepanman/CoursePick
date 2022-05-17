using CoursePickData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursePickData.DbContextConfigurations
{
    public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .Property(nameof(Student.Surname))
                .HasMaxLength(30)
                .IsRequired();
            builder
                .Property(nameof(Student.Name))
                .HasMaxLength(30)
                .IsRequired();
            builder
                .Property(nameof(Student.Email))
                .IsRequired();
            builder
                .Property(nameof(Student.Resume))
                .HasMaxLength(120)
                .IsRequired(false);
            builder
                .Property(nameof(Student.ImagePath))
                .IsRequired(false);
            builder
                .HasIndex(nameof(Student.Email))
                .IsUnique();
        }
    }
}
