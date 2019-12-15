using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ClassAttendance.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassAttendance.DAL.Configurations
{
    public class UsersSubjectsConfiguration : IEntityTypeConfiguration<UsersSubjects>
    {
        public void Configure(EntityTypeBuilder<UsersSubjects> builder)
        {
            builder.ToTable("UsersSubjects");
            builder.HasOne(x => x.Subject).WithMany(x => x.UsersSubjects).HasForeignKey(x => x.SubjectId);
            builder.HasOne(x => x.User).WithMany(x => x.UsersSubjects).HasForeignKey(x => x.UserId);
            builder.HasKey(x=> new {x.SubjectId, x.UserId});
        }
    }
}
