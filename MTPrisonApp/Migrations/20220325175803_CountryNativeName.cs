using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MTPrisonApp.Migrations
{
    public partial class CountryNativeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "Prison",
                table: "Countries",
                newName: "NativeName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NativeName",
                schema: "Prison",
                table: "Countries",
                newName: "Description");
        }
    }
}
