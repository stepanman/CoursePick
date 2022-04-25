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
                .Property(nameof(Tutor.Resume))
                .IsRequired(false);
            builder
                .Property(nameof(Tutor.ImagePath))
                .IsRequired(false);
        }
    }
}
