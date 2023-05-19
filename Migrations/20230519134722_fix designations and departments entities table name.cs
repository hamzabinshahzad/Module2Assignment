using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuleAssignment.Migrations
{
    /// <inheritdoc />
    public partial class fixdesignationsanddepartmentsentitiestablename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentDesignations",
                table: "DepartmentDesignations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.RenameTable(
                name: "DepartmentDesignations",
                newName: "Designations");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Designations",
                table: "Designations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Designations",
                table: "Designations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.RenameTable(
                name: "Designations",
                newName: "DepartmentDesignations");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentDesignations",
                table: "DepartmentDesignations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "Id");
        }
    }
}
