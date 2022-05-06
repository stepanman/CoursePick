using SubjectPickData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SubjectPickData.DbContextConfigurations
{
    public class SubjectEntityTypeConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder
                .Property(nameof(Subject.Title))
                .HasMaxLength(30)
                .IsRequired();
            builder
                .Property(nameof(Subject.Description))
                .HasMaxLength(120)
                .IsRequired();
            builder
                .Property(nameof(Subject.ImagePath))
                .IsRequired(false);
        }
    }
}
