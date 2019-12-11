using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassAttendance.DAL.Migrations
{
    public partial class AddNewReletionship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groupes_EducationalInstitutions_EducationalInstitutionId",
                table: "Groupes");

            migrationBuilder.AlterColumn<Guid>(
                name: "EducationalInstitutionId",
                table: "Groupes",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Groupes_EducationalInstitutions_EducationalInstitutionId",
                table: "Groupes",
                column: "EducationalInstitutionId",
                principalTable: "EducationalInstitutions",
                principalColumn: "EducationalInstitutionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groupes_EducationalInstitutions_EducationalInstitutionId",
                table: "Groupes");

            migrationBuilder.AlterColumn<Guid>(
                name: "EducationalInstitutionId",
                table: "Groupes",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Groupes_EducationalInstitutions_EducationalInstitutionId",
                table: "Groupes",
                column: "EducationalInstitutionId",
                principalTable: "EducationalInstitutions",
                principalColumn: "EducationalInstitutionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
