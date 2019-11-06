using System;
using System.Collections.Generic;
using System.Text;
using ClassAttendance.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassAttendance.DAL.Configurations
{
    class EducationalInstitutionFacultyConfiguration : IEntityTypeConfiguration<EducationalInstitutionFaculty>
    {
        public void Configure(EntityTypeBuilder<EducationalInstitutionFaculty> builder)
        {
            builder.HasOne(s => s.EducationalInstitution).WithMany(sc => sc.EducationalInstitutionFaculty)
                .HasForeignKey(s => s.EducationalInstitutionId);
            builder.HasOne(s => s.Faculty).WithMany(sc => sc.EducationalInstitutionFaculty)
                .HasForeignKey(s => s.FacultyId);
            builder.HasKey(sc => new { sc.FacultyId, sc.EducationalInstitutionId});
        }
    }
}
