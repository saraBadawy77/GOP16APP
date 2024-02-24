using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GOP16APP.Migrations
{
    /// <inheritdoc />
    public partial class EntityInformationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppentityInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityClassification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HeadQuarterCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sector = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Numberbranches = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Numberemployees = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Logos = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppentityInformation", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppentityInformation");
        }
    }
}
