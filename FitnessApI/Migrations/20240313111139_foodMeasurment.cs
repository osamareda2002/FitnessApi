using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApI.Migrations
{
    /// <inheritdoc />
    public partial class foodMeasurment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Foods");

            migrationBuilder.RenameColumn(
                name: "Vessel",
                table: "Foods",
                newName: "Measure");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Measure",
                table: "Foods",
                newName: "Vessel");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Foods",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
