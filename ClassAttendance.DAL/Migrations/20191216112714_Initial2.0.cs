using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassAttendance.DAL.Migrations
{
    public partial class Initial20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EducationalInstitutionId",
                table: "Subjects",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_EducationalInstitutionId",
                table: "Subjects",
                column: "EducationalInstitutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_EducationalInstitutions_EducationalInstitutionId",
                table: "Subjects",
                column: "EducationalInstitutionId",
                principalTable: "EducationalInstitutions",
                principalColumn: "EducationalInstitutionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_EducationalInstitutions_EducationalInstitutionId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_EducationalInstitutionId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "EducationalInstitutionId",
                table: "Subjects");
        }
    }
}
