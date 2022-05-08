using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimeFlix.App.Data.Migrations
{
    public partial class IncludingSessions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentEp = table.Column<int>(type: "int", nullable: false),
                    CurrentTime = table.Column<int>(type: "int", nullable: false),
                    AnimeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sessions");
        }
    }
}
