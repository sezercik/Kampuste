using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kampus.Migrations
{
    /// <inheritdoc />
    public partial class Datas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppPostQuotes_AppPosts_PostId",
                table: "AppPostQuotes");

            migrationBuilder.DropForeignKey(
                name: "FK_AppPostReplies_AppPosts_PostId",
                table: "AppPostReplies");

            migrationBuilder.DropIndex(
                name: "IX_AppPostReplies_PostId",
                table: "AppPostReplies");

            migrationBuilder.DropIndex(
                name: "IX_AppPostQuotes_PostId",
                table: "AppPostQuotes");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AppPosts");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "AppPostReplies");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "AppPostQuotes");

            migrationBuilder.AlterColumn<Guid>(
                name: "RepliedPostId",
                table: "AppPostReplies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "QuotedPostId",
                table: "AppPostQuotes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AppPosts",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "RepliedPostId",
                table: "AppPostReplies",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "PostId",
                table: "AppPostReplies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "QuotedPostId",
                table: "AppPostQuotes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "PostId",
                table: "AppPostQuotes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppPostReplies_PostId",
                table: "AppPostReplies",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPostQuotes_PostId",
                table: "AppPostQuotes",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppPostQuotes_AppPosts_PostId",
                table: "AppPostQuotes",
                column: "PostId",
                principalTable: "AppPosts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppPostReplies_AppPosts_PostId",
                table: "AppPostReplies",
                column: "PostId",
                principalTable: "AppPosts",
                principalColumn: "Id");
        }
    }
}
