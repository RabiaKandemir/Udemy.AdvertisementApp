using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Udemy.AdvertisementApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AppRoleUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Definiton",
                table: "AppRoles",
                newName: "Definition");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Definition",
                table: "AppRoles",
                newName: "Definiton");
        }
    }
}
