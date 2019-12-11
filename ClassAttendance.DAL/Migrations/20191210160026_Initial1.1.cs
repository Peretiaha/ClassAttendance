using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassAttendance.DAL.Migrations
{
    public partial class Initial11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_EducationalInstitutions_EducationalInstitutionId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "EducationalInstitutionId",
                table: "Users",
                newName: "GroupeId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_EducationalInstitutionId",
                table: "Users",
                newName: "IX_Users_GroupeId");

            migrationBuilder.CreateTable(
                name: "Groupes",
                columns: table => new
                {
                    GroupeId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    EducationalInstitutionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupes", x => x.GroupeId);
                    table.ForeignKey(
                        name: "FK_Groupes_EducationalInstitutions_EducationalInstitutionId",
                        column: x => x.EducationalInstitutionId,
                        principalTable: "EducationalInstitutions",
                        principalColumn: "EducationalInstitutionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectsGroupes",
                columns: table => new
                {
                    SubjectId = table.Column<Guid>(nullable: false),
                    GroupeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectsGroupes", x => new { x.GroupeId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_SubjectsGroupes_Groupes_GroupeId",
                        column: x => x.GroupeId,
                        principalTable: "Groupes",
                        principalColumn: "GroupeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectsGroupes_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groupes_EducationalInstitutionId",
                table: "Groupes",
                column: "EducationalInstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsGroupes_SubjectId",
                table: "SubjectsGroupes",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Groupes_GroupeId",
                table: "Users",
                column: "GroupeId",
                principalTable: "Groupes",
                principalColumn: "GroupeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Groupes_GroupeId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "SubjectsGroupes");

            migrationBuilder.DropTable(
                name: "Groupes");

            migrationBuilder.RenameColumn(
                name: "GroupeId",
                table: "Users",
                newName: "EducationalInstitutionId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_GroupeId",
                table: "Users",
                newName: "IX_Users_EducationalInstitutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_EducationalInstitutions_EducationalInstitutionId",
                table: "Users",
                column: "EducationalInstitutionId",
                principalTable: "EducationalInstitutions",
                principalColumn: "EducationalInstitutionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
