using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Larproj.Migrations
{
    /// <inheritdoc />
    public partial class AddPartyIdAndCurrentScoreToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "UserHashPassword",
                table: "Users",
                newName: "HashPassword");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "CurrentScore",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PartyId",
                table: "Users",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentScore",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PartyId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "HashPassword",
                table: "Users",
                newName: "UserHashPassword");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "UserEmail");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");
        }
    }
}
