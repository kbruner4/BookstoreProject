using Microsoft.EntityFrameworkCore.Migrations;

namespace BookstoreProject.Migrations
{
    public partial class AddRecievedField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BookReceived",
                table: "Checkouts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Checkouts",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookReceived",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Checkouts");
        }
    }
}
