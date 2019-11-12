using ClassAttendance.Models.Models.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAttendance.DAL.Configurations
{
    public class SpecialtyTranslateConfiguration : IEntityTypeConfiguration<SpecialtyTranslate>
    {
        public void Configure(EntityTypeBuilder<SpecialtyTranslate> builder)
        {
            builder.HasOne(s => s.Specialty).WithMany(sc => sc.SpecialtyTranslates)
                           .HasForeignKey(s => s.SpecialtyId);
            builder.HasOne(s => s.Language).WithMany(sc => sc.SpecialtyTranslates)
                .HasForeignKey(s => s.Lang);
            builder.HasKey(sc => new { sc.SpecialtyId, sc.Lang});
        }
    }
}
