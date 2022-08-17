using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NcryptXAuthenticator.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "seed",
                table: "UsersMFA",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "seed",
                table: "UsersMFA");
        }
    }
}
