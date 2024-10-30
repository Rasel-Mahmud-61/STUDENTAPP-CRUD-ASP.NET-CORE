using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDOFSTUDENT.Migrations
{
    /// <inheritdoc />
    public partial class crud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AllStudents",
                table: "AllStudents");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AllStudents");

            migrationBuilder.DropColumn(
                name: "Subscribed",
                table: "AllStudents");

            migrationBuilder.RenameTable(
                name: "AllStudents",
                newName: "HiAllStudents");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HiAllStudents",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HiAllStudents",
                table: "HiAllStudents",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HiAllStudents",
                table: "HiAllStudents");

            migrationBuilder.RenameTable(
                name: "HiAllStudents",
                newName: "AllStudents");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AllStudents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "AllStudents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Subscribed",
                table: "AllStudents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllStudents",
                table: "AllStudents",
                column: "Id");
        }
    }
}
