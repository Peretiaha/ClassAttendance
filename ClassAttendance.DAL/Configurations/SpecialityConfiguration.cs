using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClassAttendance.Models.Models;

namespace ClassAttendance.DAL.Configurations
{
    public class SpecialityConfiguration : IEntityTypeConfiguration<Specialty>
    {
        public void Configure(EntityTypeBuilder<Specialty> builder)
        {
            builder.HasIndex(x => x.Number).IsUnique();
            builder.HasKey(x=>x.SpecialityId);
        }
    }
}
