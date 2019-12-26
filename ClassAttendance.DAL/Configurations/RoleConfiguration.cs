using System;
using System.Collections.Generic;
using System.Text;
using ClassAttendance.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassAttendance.DAL.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role
                {RoleId = Guid.Parse("88b510f1-ce1f-48ec-a39c-c2da62b41e51"), Name = "AdminGlobal"});
            builder.HasData(new Role
                { RoleId = Guid.Parse("b3de9a30-ec07-4f1b-80ee-fc14892e0182"), Name = "AdminLocal" });
            builder.HasData(new Role
                { RoleId = Guid.Parse("f4be7c9d-8999-40c6-9dbd-1e7341ebaad6"), Name = "Student" });
            builder.HasData(new Role
                { RoleId = Guid.Parse("19a770f7-0128-4674-a99a-da2a9fda5fb4"), Name = "Headman" });
            builder.HasData(new Role
                { RoleId = Guid.Parse("fcdce55a-1339-41aa-be14-7b72068f2fc0"), Name = "Teacher" });
        }
    }
}
