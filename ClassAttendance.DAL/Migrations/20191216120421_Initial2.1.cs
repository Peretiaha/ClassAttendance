using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassAttendance.DAL.Migrations
{
    public partial class Initial21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_EducationalInstitutions_EducationalInstitutionId",
                table: "Subjects");

            migrationBuilder.AlterColumn<Guid>(
                name: "EducationalInstitutionId",
                table: "Subjects",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name" },
                values: new object[] { new Guid("fcdce55a-1339-41aa-be14-7b72068f2fc0"), "Teacher" });

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_EducationalInstitutions_EducationalInstitutionId",
                table: "Subjects",
                column: "EducationalInstitutionId",
                principalTable: "EducationalInstitutions",
                principalColumn: "EducationalInstitutionId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_EducationalInstitutions_EducationalInstitutionId",
                table: "Subjects");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("fcdce55a-1339-41aa-be14-7b72068f2fc0"));

            migrationBuilder.AlterColumn<Guid>(
                name: "EducationalInstitutionId",
                table: "Subjects",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_EducationalInstitutions_EducationalInstitutionId",
                table: "Subjects",
                column: "EducationalInstitutionId",
                principalTable: "EducationalInstitutions",
                principalColumn: "EducationalInstitutionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
