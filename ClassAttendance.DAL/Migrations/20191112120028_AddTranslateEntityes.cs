using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassAttendance.DAL.Migrations
{
    public partial class AddTranslateEntityes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Specialties");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "EducationalInstitutions");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Specialties",
                newName: "SpecialityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Roles",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Faculties",
                newName: "FacultyId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EducationalInstitutions",
                newName: "EducationalInstitutionId");

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Lang = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Lang);
                });

            migrationBuilder.CreateTable(
                name: "EducationalInstitutionTranslates",
                columns: table => new
                {
                    EducationalInstitutionId = table.Column<Guid>(nullable: false),
                    Lang = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalInstitutionTranslates", x => new { x.EducationalInstitutionId, x.Lang });
                    table.ForeignKey(
                        name: "FK_EducationalInstitutionTranslates_EducationalInstitutions_EducationalInstitutionId",
                        column: x => x.EducationalInstitutionId,
                        principalTable: "EducationalInstitutions",
                        principalColumn: "EducationalInstitutionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EducationalInstitutionTranslates_Languages_Lang",
                        column: x => x.Lang,
                        principalTable: "Languages",
                        principalColumn: "Lang",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacultyTranslates",
                columns: table => new
                {
                    FacultyId = table.Column<Guid>(nullable: false),
                    Lang = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyTranslates", x => new { x.FacultyId, x.Lang });
                    table.ForeignKey(
                        name: "FK_FacultyTranslates_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "FacultyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacultyTranslates_Languages_Lang",
                        column: x => x.Lang,
                        principalTable: "Languages",
                        principalColumn: "Lang",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialtyTranslates",
                columns: table => new
                {
                    SpecialtyId = table.Column<Guid>(nullable: false),
                    Lang = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialtyTranslates", x => new { x.SpecialtyId, x.Lang });
                    table.ForeignKey(
                        name: "FK_SpecialtyTranslates_Languages_Lang",
                        column: x => x.Lang,
                        principalTable: "Languages",
                        principalColumn: "Lang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialtyTranslates_Specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "SpecialityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EducationalInstitutionTranslates_Lang",
                table: "EducationalInstitutionTranslates",
                column: "Lang");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyTranslates_Lang",
                table: "FacultyTranslates",
                column: "Lang");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialtyTranslates_Lang",
                table: "SpecialtyTranslates",
                column: "Lang");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EducationalInstitutionTranslates");

            migrationBuilder.DropTable(
                name: "FacultyTranslates");

            migrationBuilder.DropTable(
                name: "SpecialtyTranslates");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SpecialityId",
                table: "Specialties",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Roles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "FacultyId",
                table: "Faculties",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EducationalInstitutionId",
                table: "EducationalInstitutions",
                newName: "Id");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Specialties",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Roles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Faculties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "EducationalInstitutions",
                nullable: true);
        }
    }
}
