using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PET.Migrations
{
    public partial class Addmapgroomingcoordinatesvalidationstodb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Grooming",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "30.014317");

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "Grooming",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "31.433173");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Grooming");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Grooming");
        }
    }
}
