using ClassAttendance.Models.Models.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAttendance.DAL.Configurations
{
    public class FacultyTranslateConfiguration : IEntityTypeConfiguration<FacultyTranslate>
    {
        public void Configure(EntityTypeBuilder<FacultyTranslate> builder)
        {
            builder.HasOne(s => s.Faculty).WithMany(sc => sc.FacultyTranslates)
                           .HasForeignKey(s => s.FacultyId);
            builder.HasOne(s => s.Language).WithMany(sc => sc.FacultyTranslates)
                .HasForeignKey(s => s.Lang);
            builder.HasKey(sc => new { sc.FacultyId, sc.Lang }); 
        }
    }
}
