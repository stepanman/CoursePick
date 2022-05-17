using CoursePickData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursePickData.DbContextConfigurations
{
    public class TutorEntityTypeConfiguration : IEntityTypeConfiguration<Tutor>
    {
        public void Configure(EntityTypeBuilder<Tutor> builder)
        {
            builder
                .Property(nameof(Tutor.Surname))
                .HasMaxLength(30)
                .IsRequired();
            builder
                .Property(nameof(Tutor.Name))
                .HasMaxLength(30)
                .IsRequired();
            builder
                .Property(nameof(Tutor.Email))
                .IsRequired();
            builder
                .Property(nameof(Tutor.Resume))
                .HasMaxLength(120)
                .IsRequired(false);
            builder
                .Property(nameof(Tutor.ImagePath))
                .IsRequired(false);
            builder
                .HasIndex(nameof(Tutor.Email))
                .IsUnique();
        }
    }
}
