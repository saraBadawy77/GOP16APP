using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GOP16APP.Migrations
{
    /// <inheritdoc />
    public partial class ContactDetailsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppcontactDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LinkedIn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OfficialEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OfficialWebsite = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FocalPointName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FocalPointTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FocalPointMobile = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FocalPointEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SpecificRequests = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppcontactDetails", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppcontactDetails");
        }
    }
}
