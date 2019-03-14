using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSM.Bataan.School.WebSite.Migrations
{
    public partial class SchoolFacility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SchoolFacilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    TemplateName = table.Column<string>(nullable: true),
                    IsPublished = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PostExpiry = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolFacilities", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchoolFacilities");
        }
    }
}
