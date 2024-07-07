using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kampus.Migrations
{
    /// <inheritdoc />
    public partial class fixreplyandquotemodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppPostQuotes_AppPosts_Id",
                table: "AppPostQuotes");

            migrationBuilder.DropForeignKey(
                name: "FK_AppPostReplies_AppPosts_Id",
                table: "AppPostReplies");

            migrationBuilder.AddColumn<string>(
                name: "BlobNames",
                table: "AppPostReplies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "AppPostReplies",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "AppPostReplies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "AppPostReplies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "AppPostReplies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "AppPostReplies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "AppPostReplies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "AppPostReplies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppPostReplies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "AppPostReplies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "AppPostReplies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "AppPostReplies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "BlobNames",
                table: "AppPostQuotes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "AppPostQuotes",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "AppPostQuotes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "AppPostQuotes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "AppPostQuotes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "AppPostQuotes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "AppPostQuotes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "AppPostQuotes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppPostQuotes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "AppPostQuotes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "AppPostQuotes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "AppPostQuotes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PostQuoteId",
                table: "AppPostLikes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PostReplyId",
                table: "AppPostLikes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppPostReplies_UserId",
                table: "AppPostReplies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPostQuotes_UserId",
                table: "AppPostQuotes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPostLikes_PostQuoteId",
                table: "AppPostLikes",
                column: "PostQuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPostLikes_PostReplyId",
                table: "AppPostLikes",
                column: "PostReplyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppPostLikes_AppPostQuotes_PostQuoteId",
                table: "AppPostLikes",
                column: "PostQuoteId",
                principalTable: "AppPostQuotes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppPostLikes_AppPostReplies_PostReplyId",
                table: "AppPostLikes",
                column: "PostReplyId",
                principalTable: "AppPostReplies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppPostQuotes_AbpUsers_UserId",
                table: "AppPostQuotes",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppPostReplies_AbpUsers_UserId",
                table: "AppPostReplies",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppPostLikes_AppPostQuotes_PostQuoteId",
                table: "AppPostLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_AppPostLikes_AppPostReplies_PostReplyId",
                table: "AppPostLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_AppPostQuotes_AbpUsers_UserId",
                table: "AppPostQuotes");

            migrationBuilder.DropForeignKey(
                name: "FK_AppPostReplies_AbpUsers_UserId",
                table: "AppPostReplies");

            migrationBuilder.DropIndex(
                name: "IX_AppPostReplies_UserId",
                table: "AppPostReplies");

            migrationBuilder.DropIndex(
                name: "IX_AppPostQuotes_UserId",
                table: "AppPostQuotes");

            migrationBuilder.DropIndex(
                name: "IX_AppPostLikes_PostQuoteId",
                table: "AppPostLikes");

            migrationBuilder.DropIndex(
                name: "IX_AppPostLikes_PostReplyId",
                table: "AppPostLikes");

            migrationBuilder.DropColumn(
                name: "BlobNames",
                table: "AppPostReplies");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "AppPostReplies");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "AppPostReplies");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "AppPostReplies");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "AppPostReplies");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "AppPostReplies");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AppPostReplies");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "AppPostReplies");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppPostReplies");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "AppPostReplies");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "AppPostReplies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AppPostReplies");

            migrationBuilder.DropColumn(
                name: "BlobNames",
                table: "AppPostQuotes");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "AppPostQuotes");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "AppPostQuotes");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "AppPostQuotes");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "AppPostQuotes");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "AppPostQuotes");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AppPostQuotes");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "AppPostQuotes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppPostQuotes");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "AppPostQuotes");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "AppPostQuotes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AppPostQuotes");

            migrationBuilder.DropColumn(
                name: "PostQuoteId",
                table: "AppPostLikes");

            migrationBuilder.DropColumn(
                name: "PostReplyId",
                table: "AppPostLikes");

            migrationBuilder.AddForeignKey(
                name: "FK_AppPostQuotes_AppPosts_Id",
                table: "AppPostQuotes",
                column: "Id",
                principalTable: "AppPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppPostReplies_AppPosts_Id",
                table: "AppPostReplies",
                column: "Id",
                principalTable: "AppPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
