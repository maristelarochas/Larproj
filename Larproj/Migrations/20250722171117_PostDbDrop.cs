using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Larproj.Migrations
{
    /// <inheritdoc />
    public partial class PostDbDrop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "LarTasks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "LarTasks",
                type: "TEXT",
                nullable: true);
        }
    }
}
