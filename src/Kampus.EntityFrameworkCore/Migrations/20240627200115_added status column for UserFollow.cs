using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kampus.Migrations
{
    /// <inheritdoc />
    public partial class addedstatuscolumnforUserFollow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AppUserFollows",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "AppUserFollows");
        }
    }
}
