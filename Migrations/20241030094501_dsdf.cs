using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDOFSTUDENT.Migrations
{
    /// <inheritdoc />
    public partial class dsdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HiAllStudents",
                table: "HiAllStudents");

            migrationBuilder.RenameTable(
                name: "HiAllStudents",
                newName: "HELLOAllStudents");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HELLOAllStudents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "HELLOAllStudents",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HELLOAllStudents",
                table: "HELLOAllStudents",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HELLOAllStudents",
                table: "HELLOAllStudents");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "HELLOAllStudents");

            migrationBuilder.RenameTable(
                name: "HELLOAllStudents",
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
    }
}
