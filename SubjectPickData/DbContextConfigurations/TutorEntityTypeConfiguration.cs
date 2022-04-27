using SubjectPickData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SubjectPickData.DbContextConfigurations
{
    public class TutorEntityTypeConfiguration : IEntityTypeConfiguration<Tutor>
    {
        public void Configure(EntityTypeBuilder<Tutor> builder)
        {
            builder
                .Property(nameof(Tutor.Surname))
                .IsRequired();
            builder
                .Property(nameof(Tutor.Name))
                .IsRequired();
            builder
                .Property(nameof(Tutor.Email))
                .IsRequired();
            builder
                .Property(nameof(Tutor.Resume))
                .IsRequired(false);
            builder
                .Property(nameof(Tutor.ImagePath))
                .IsRequired(false);
        }
    }
}
