using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCore.Data.Migrations
{
    public partial class ExtendedUserDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Property2",
                table: "UserProperties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "UserProperties",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Property2",
                table: "UserProperties");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "UserProperties");
        }
    }
}
