using Microsoft.EntityFrameworkCore;
using ClassAttendance.Models.Models;
using ClassAttendance.Models.Models.Localization;
using ClassAttendance.DAL.Configurations;

namespace ClassAttendance.DAL.Context
{
    public class ClassAttendanceContext : DbContext
    {
        public ClassAttendanceContext(DbContextOptions<ClassAttendanceContext> options) : base(options)
        {
        }

        public DbSet<EducationalInstitution> EducationalInstitutions { get; set; }

        public DbSet<EducationalInstitutionFaculty> EducationalInstitutionFaculty { get; set; }

        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<Specialty> Specialties { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UsersRoles> UsersRoles { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<EducationalInstitutionTranslate> EducationalInstitutionTranslates { get; set; }

        public DbSet<SpecialtyTranslate> SpecialtyTranslates { get; set; }

        public DbSet<FacultyTranslate> FacultyTranslates { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SpecialityConfiguration());
            modelBuilder.ApplyConfiguration(new EducationalInstitutionFacultyConfiguration());
            modelBuilder.ApplyConfiguration(new UsersRolesConfiguration());
            modelBuilder.ApplyConfiguration(new EducationalInstitutionTranslateConfiguration());
            modelBuilder.ApplyConfiguration(new SpecialtyTranslateConfiguration());
            modelBuilder.ApplyConfiguration(new FacultyTranslateConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
        }
    }
}
