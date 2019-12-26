﻿// <auto-generated />
using System;
using ClassAttendance.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClassAttendance.DAL.Migrations
{
    [DbContext(typeof(ClassAttendanceContext))]
    partial class ClassAttendanceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClassAttendance.Models.Models.EducationalInstitution", b =>
                {
                    b.Property<Guid>("EducationalInstitutionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<int>("Country");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<int>("Type");

                    b.HasKey("EducationalInstitutionId");

                    b.ToTable("EducationalInstitutions");
                });

            modelBuilder.Entity("ClassAttendance.Models.Models.Group", b =>
                {
                    b.Property<Guid>("GroupId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("EducationalInstitutionId");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.HasKey("GroupId");

                    b.HasIndex("EducationalInstitutionId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("ClassAttendance.Models.Models.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new { RoleId = new Guid("88b510f1-ce1f-48ec-a39c-c2da62b41e51"), Name = "AdminGlobal" },
                        new { RoleId = new Guid("b3de9a30-ec07-4f1b-80ee-fc14892e0182"), Name = "AdminLocal" },
                        new { RoleId = new Guid("f4be7c9d-8999-40c6-9dbd-1e7341ebaad6"), Name = "Student" },
                        new { RoleId = new Guid("19a770f7-0128-4674-a99a-da2a9fda5fb4"), Name = "Headman" },
                        new { RoleId = new Guid("fcdce55a-1339-41aa-be14-7b72068f2fc0"), Name = "Teacher" }
                    );
                });

            modelBuilder.Entity("ClassAttendance.Models.Models.Subject", b =>
                {
                    b.Property<Guid>("SubjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("EducationalInstitutionId");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<int>("NumberOfLessons");

                    b.Property<Guid>("TeacherId");

                    b.HasKey("SubjectId");

                    b.HasIndex("EducationalInstitutionId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("ClassAttendance.Models.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("Email");

                    b.Property<Guid>("GroupId");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<byte[]>("Photo");

                    b.HasKey("UserId");

                    b.HasIndex("GroupId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ClassAttendance.Models.Models.UsersRoles", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UsersRoles");
                });

            modelBuilder.Entity("ClassAttendance.Models.Models.UsersSubjects", b =>
                {
                    b.Property<Guid>("SubjectId");

                    b.Property<Guid>("UserId");

                    b.Property<int>("NumberOfVisits");

                    b.Property<int>("PassesForGoodReason");

                    b.HasKey("SubjectId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersSubjects");
                });

            modelBuilder.Entity("ClassAttendance.Models.Models.Group", b =>
                {
                    b.HasOne("ClassAttendance.Models.Models.EducationalInstitution", "EducationalInstitution")
                        .WithMany("Groups")
                        .HasForeignKey("EducationalInstitutionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ClassAttendance.Models.Models.Subject", b =>
                {
                    b.HasOne("ClassAttendance.Models.Models.EducationalInstitution", "EducationalInstitution")
                        .WithMany("Subjects")
                        .HasForeignKey("EducationalInstitutionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ClassAttendance.Models.Models.User", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ClassAttendance.Models.Models.User", b =>
                {
                    b.HasOne("ClassAttendance.Models.Models.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ClassAttendance.Models.Models.UsersRoles", b =>
                {
                    b.HasOne("ClassAttendance.Models.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ClassAttendance.Models.Models.User", "User")
                        .WithMany("UsersRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ClassAttendance.Models.Models.UsersSubjects", b =>
                {
                    b.HasOne("ClassAttendance.Models.Models.Subject", "Subject")
                        .WithMany("UsersSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ClassAttendance.Models.Models.User", "User")
                        .WithMany("UsersSubjects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
