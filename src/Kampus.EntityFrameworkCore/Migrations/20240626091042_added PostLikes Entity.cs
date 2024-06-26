using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kampus.Migrations
{
    /// <inheritdoc />
    public partial class addedPostLikesEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppPosts_AbpUsers_UserId",
                table: "AppPosts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "AbpUsers",
                type: "datetime2",
                maxLength: 11,
                nullable: false,
                defaultValue: new DateTime(2024, 6, 26, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 11,
                oldDefaultValue: new DateTime(2024, 6, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.CreateTable(
                name: "AppPostLikes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPostLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppPostLikes_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppPostLikes_AppPosts_PostId",
                        column: x => x.PostId,
                        principalTable: "AppPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppPostLikes_AppPosts_PostId1",
                        column: x => x.PostId1,
                        principalTable: "AppPosts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppPostLikes_PostId",
                table: "AppPostLikes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPostLikes_PostId1",
                table: "AppPostLikes",
                column: "PostId1");

            migrationBuilder.CreateIndex(
                name: "IX_AppPostLikes_UserId",
                table: "AppPostLikes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppPosts_AbpUsers_UserId",
                table: "AppPosts",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppPosts_AbpUsers_UserId",
                table: "AppPosts");

            migrationBuilder.DropTable(
                name: "AppPostLikes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "AbpUsers",
                type: "datetime2",
                maxLength: 11,
                nullable: false,
                defaultValue: new DateTime(2024, 6, 24, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 11,
                oldDefaultValue: new DateTime(2024, 6, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_AppPosts_AbpUsers_UserId",
                table: "AppPosts",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
