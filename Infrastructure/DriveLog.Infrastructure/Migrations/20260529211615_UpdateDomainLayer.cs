using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriveLog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDomainLayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.Id);
                    table.CheckConstraint("CK_car_number_positive", "\"Number\" > 0");
                });

            migrationBuilder.CreateTable(
                name: "drivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    Name_FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name_LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drivers", x => x.Id);
                    table.CheckConstraint("CK_driver_number_positive", "\"Number\" > 0");
                });

            migrationBuilder.CreateTable(
                name: "tracks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tracks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "races",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TrackId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    ActualStartTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ActualEndTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_races", x => x.Id);
                    table.ForeignKey(
                        name: "FK_races_tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "race_entries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DriverId = table.Column<Guid>(type: "uuid", nullable: false),
                    CarId = table.Column<Guid>(type: "uuid", nullable: false),
                    RaceId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_race_entries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_race_entries_cars_CarId",
                        column: x => x.CarId,
                        principalTable: "cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_race_entries_drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_race_entries_races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "race_laps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Time = table.Column<TimeSpan>(type: "interval", nullable: false),
                    RaceEntryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_race_laps", x => x.Id);
                    table.CheckConstraint("CK_lap_number_positive", "\"Id\" > 0");
                    table.ForeignKey(
                        name: "FK_race_laps_race_entries_RaceEntryId",
                        column: x => x.RaceEntryId,
                        principalTable: "race_entries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cars_Number",
                table: "cars",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_race_entries_CarId",
                table: "race_entries",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_race_entries_DriverId",
                table: "race_entries",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_unique_race_car",
                table: "race_entries",
                columns: new[] { "RaceId", "CarId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_unique_race_driver",
                table: "race_entries",
                columns: new[] { "RaceId", "DriverId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PK_race_entry_lap_number",
                table: "race_laps",
                columns: new[] { "RaceEntryId", "Id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_races_TrackId",
                table: "races",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_tracks_Name",
                table: "tracks",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "race_laps");

            migrationBuilder.DropTable(
                name: "race_entries");

            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "drivers");

            migrationBuilder.DropTable(
                name: "races");

            migrationBuilder.DropTable(
                name: "tracks");
        }
    }
}
