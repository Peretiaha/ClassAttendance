﻿using Microsoft.EntityFrameworkCore;
using ClassAttendance.Models.Models;
using ClassAttendance.DAL.Configurations;

namespace ClassAttendance.DAL.Context
{
    public class ClassAttendanceContext : DbContext
    {
        public ClassAttendanceContext(DbContextOptions<ClassAttendanceContext> options) : base(options)
        {
        }

        public DbSet<EducationalInstitution> EducationalInstitutions { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UsersRoles> UsersRoles { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<UsersSubjects> SubjectsGroups { get; set; }

        public  DbSet<Group> Groups { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UsersRolesConfiguration());
            modelBuilder.ApplyConfiguration(new UsersSubjectsConfiguration());
        }
    }
}
