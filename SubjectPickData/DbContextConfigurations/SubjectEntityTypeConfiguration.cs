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
                .IsRequired();
            builder
                .Property(nameof(Subject.Description))
                .IsRequired();
            builder
                .Property(nameof(Subject.ImagePath))
                .IsRequired(false);
        }
    }
}
