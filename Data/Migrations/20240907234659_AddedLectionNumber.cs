using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedLectionNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Lectures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 1,
                column: "Number",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 2,
                column: "Number",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 3,
                column: "Number",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 4,
                column: "Number",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 5,
                column: "Number",
                value: 5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Lectures");
        }
    }
}
