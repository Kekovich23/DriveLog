using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriveLog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRacingNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Drivers",
                newName: "Number_Value");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Cars",
                newName: "Number_Value");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number_Value",
                table: "Drivers",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "Number_Value",
                table: "Cars",
                newName: "Number");
        }
    }
}
