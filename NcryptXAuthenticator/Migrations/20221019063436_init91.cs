using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NcryptXAuthenticator.Migrations
{
    public partial class init91 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deviceid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    devicetype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    startdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    enddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    connectionString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    randomNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_deviceid",
                table: "users",
                column: "deviceid",
                unique: true,
                filter: "[deviceid] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
