﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuleAssignment.Migrations
{
    /// <inheritdoc />
    public partial class EntityModelEmailAddresspropertyadditio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Employees");
        }
    }
}