using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoonlyBird.Poll.Admin.Database.Migration
{
    /// <inheritdoc />
    public partial class Unique_User_Name : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_Users_Name",
                table: "Users",
                newName: "UX_User_Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "UX_User_Name",
                table: "Users",
                newName: "IX_Users_Name");
        }
    }
}
