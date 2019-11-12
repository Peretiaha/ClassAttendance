using ClassAttendance.Models.Models.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAttendance.DAL.Configurations
{
    class EducationalInstitutionTranslateConfiguration : IEntityTypeConfiguration<EducationalInstitutionTranslate>
    {
        public void Configure(EntityTypeBuilder<EducationalInstitutionTranslate> builder)
        {
            builder.HasOne(s => s.EducationalInstitution).WithMany(sc => sc.EducationalInstitutionTranslates)
                          .HasForeignKey(s => s.EducationalInstitutionId);
            builder.HasOne(s => s.Language).WithMany(sc => sc.EducationalInstitutionTranslates)
                .HasForeignKey(s => s.Lang);
            builder.HasKey(sc => new { sc.EducationalInstitutionId, sc.Lang }); ;
        }
    }
}
