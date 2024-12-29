using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class MakeEmployeeCollectionNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeInfos_Departments_DepartmentId",
                table: "EmployeeInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeInfos_Designations_DesignationId",
                table: "EmployeeInfos");

            migrationBuilder.AlterColumn<int>(
                name: "DesignationId",
                table: "EmployeeInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "EmployeeInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeInfos_Departments_DepartmentId",
                table: "EmployeeInfos",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeInfos_Designations_DesignationId",
                table: "EmployeeInfos",
                column: "DesignationId",
                principalTable: "Designations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeInfos_Departments_DepartmentId",
                table: "EmployeeInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeInfos_Designations_DesignationId",
                table: "EmployeeInfos");

            migrationBuilder.AlterColumn<int>(
                name: "DesignationId",
                table: "EmployeeInfos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "EmployeeInfos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeInfos_Departments_DepartmentId",
                table: "EmployeeInfos",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeInfos_Designations_DesignationId",
                table: "EmployeeInfos",
                column: "DesignationId",
                principalTable: "Designations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
