using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GOP16APP.Migrations
{
    /// <inheritdoc />
    public partial class RequestedPavilionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApprequestedPavilions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsVisitorSpace = table.Column<bool>(type: "bit", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BriefPavilion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSigning = table.Column<bool>(type: "bit", nullable: false),
                    IsPrizes = table.Column<bool>(type: "bit", nullable: false),
                    CEOName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumberStandingPavilion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LevelRepresentation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprequestedPavilions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprequestedPavilions");
        }
    }
}
