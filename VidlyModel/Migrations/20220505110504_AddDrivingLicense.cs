using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VidlyModel.Migrations
{
    public partial class AddDrivingLicense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DrivingLicense",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DrivingLicense",
                table: "AspNetUsers");
        }
    }
}
