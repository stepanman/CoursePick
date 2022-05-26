using CoursePickData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursePickData.DbContextConfigurations
{
    public class CourseEntityTypeConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder
                .Property(nameof(Course.Title))
                .HasMaxLength(30)
                .IsRequired();
            builder
                .Property(nameof(Course.Description))
                .HasMaxLength(120)
                .IsRequired();
        }
    }
}
