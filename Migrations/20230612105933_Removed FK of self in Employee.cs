using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuleAssignment.Migrations
{
    /// <inheritdoc />
    public partial class RemovedFKofselfinEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_ReportsToEmployeeId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ReportsToEmployeeId",
                table: "Employees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Employees_ReportsToEmployeeId",
                table: "Employees",
                column: "ReportsToEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_ReportsToEmployeeId",
                table: "Employees",
                column: "ReportsToEmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
