using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImageGallery.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_Friend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendUser_Users_FirstFriendId",
                table: "FriendUser");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendUser_Users_SecondFriendId",
                table: "FriendUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FriendUser",
                table: "FriendUser");

            migrationBuilder.RenameTable(
                name: "FriendUser",
                newName: "FriendUsers");

            migrationBuilder.RenameIndex(
                name: "IX_FriendUser_SecondFriendId",
                table: "FriendUsers",
                newName: "IX_FriendUsers_SecondFriendId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FriendUsers",
                table: "FriendUsers",
                columns: new[] { "FirstFriendId", "SecondFriendId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FriendUsers_Users_FirstFriendId",
                table: "FriendUsers",
                column: "FirstFriendId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendUsers_Users_SecondFriendId",
                table: "FriendUsers",
                column: "SecondFriendId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendUsers_Users_FirstFriendId",
                table: "FriendUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendUsers_Users_SecondFriendId",
                table: "FriendUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FriendUsers",
                table: "FriendUsers");

            migrationBuilder.RenameTable(
                name: "FriendUsers",
                newName: "FriendUser");

            migrationBuilder.RenameIndex(
                name: "IX_FriendUsers_SecondFriendId",
                table: "FriendUser",
                newName: "IX_FriendUser_SecondFriendId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FriendUser",
                table: "FriendUser",
                columns: new[] { "FirstFriendId", "SecondFriendId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FriendUser_Users_FirstFriendId",
                table: "FriendUser",
                column: "FirstFriendId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendUser_Users_SecondFriendId",
                table: "FriendUser",
                column: "SecondFriendId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
