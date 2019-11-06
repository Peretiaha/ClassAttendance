using System;
using System.Collections.Generic;
using System.Text;
using ClassAttendance.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassAttendance.DAL.Configurations
{
    class UsersRolesConfiguration : IEntityTypeConfiguration<UsersRoles>
    {
        public void Configure(EntityTypeBuilder<UsersRoles> builder)
        {
            builder.HasOne(s => s.User).WithMany(sc => sc.UsersRoles)
                .HasForeignKey(s => s.UserId);
            builder.HasOne(s => s.Role).WithMany(sc => sc.UserRoles)
                .HasForeignKey(s => s.RoleId);
            builder.HasKey(sc => new { sc.UserId, sc.RoleId });
        }
    }
}
