using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NcryptXAuthenticator.Migrations
{
    public partial class hhh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "smsConfig",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    headerkey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    targeturl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    port = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    body = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_smsConfig", x => x.Name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "smsConfig");
        }
    }
}
