using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyDay2.Migrations
{
    /// <inheritdoc />
    public partial class Fix_Names : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentsInfo",
                table: "StudentsInfo");

            migrationBuilder.RenameTable(
                name: "StudentsInfo",
                newName: "Products");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Products",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "StudentsInfo");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "StudentsInfo",
                newName: "FirstName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentsInfo",
                table: "StudentsInfo",
                column: "Id");
        }
    }
}
