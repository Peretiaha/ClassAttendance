using System;
using System.Collections.Generic;
using System.Text;
using ClassAttendance.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassAttendance.DAL.Configurations
{
    public class SubjectsGroupesConfiguration : IEntityTypeConfiguration<SubjectsGroupes>
    {
        public void Configure(EntityTypeBuilder<SubjectsGroupes> builder)
        {
            builder.HasOne(x => x.Subject).WithMany(x => x.SubjectsGroupes).HasForeignKey(x => x.SubjectId);
            builder.HasOne(x => x.Groupe).WithMany(x => x.SubjectsGroupes).HasForeignKey(x => x.GroupeId);
            builder.HasKey(x=> new {x.GroupeId, x.SubjectId});
        }
    }
}
