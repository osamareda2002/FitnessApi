using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApI.Migrations
{
    /// <inheritdoc />
    public partial class addDailyActivity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyActivities",
                columns: table => new
                {
                    traineeId = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyActivities", x => new { x.traineeId, x.date });
                });

            migrationBuilder.CreateTable(
                name: "DailyActivityFood",
                columns: table => new
                {
                    foodsFoodId = table.Column<int>(type: "int", nullable: false),
                    ActivitiestraineeId = table.Column<int>(type: "int", nullable: false),
                    Activitiesdate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyActivityFood", x => new { x.foodsFoodId, x.ActivitiestraineeId, x.Activitiesdate });
                    table.ForeignKey(
                        name: "FK_DailyActivityFood_DailyActivities_ActivitiestraineeId_Activitiesdate",
                        columns: x => new { x.ActivitiestraineeId, x.Activitiesdate },
                        principalTable: "DailyActivities",
                        principalColumns: new[] { "traineeId", "date" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyActivityFood_Foods_foodsFoodId",
                        column: x => x.foodsFoodId,
                        principalTable: "Foods",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyActivitySport",
                columns: table => new
                {
                    sportsSportId = table.Column<int>(type: "int", nullable: false),
                    ActivitiestraineeId = table.Column<int>(type: "int", nullable: false),
                    Activitiesdate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyActivitySport", x => new { x.sportsSportId, x.ActivitiestraineeId, x.Activitiesdate });
                    table.ForeignKey(
                        name: "FK_DailyActivitySport_DailyActivities_ActivitiestraineeId_Activitiesdate",
                        columns: x => new { x.ActivitiestraineeId, x.Activitiesdate },
                        principalTable: "DailyActivities",
                        principalColumns: new[] { "traineeId", "date" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyActivitySport_Sports_sportsSportId",
                        column: x => x.sportsSportId,
                        principalTable: "Sports",
                        principalColumn: "SportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyActivityFood_ActivitiestraineeId_Activitiesdate",
                table: "DailyActivityFood",
                columns: new[] { "ActivitiestraineeId", "Activitiesdate" });

            migrationBuilder.CreateIndex(
                name: "IX_DailyActivitySport_ActivitiestraineeId_Activitiesdate",
                table: "DailyActivitySport",
                columns: new[] { "ActivitiestraineeId", "Activitiesdate" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyActivityFood");

            migrationBuilder.DropTable(
                name: "DailyActivitySport");

            migrationBuilder.DropTable(
                name: "DailyActivities");
        }
    }
}
