using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace J2.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFamilyMember3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FamilyMemberId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "FamilyMember",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75b5fe28-7aac-4b20-b430-1d1a045b5afa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59fca8b0-a465-4d80-b29c-1b6c3e05ef44", "AQAAAAIAAYagAAAAEIpwm43vMYb8eHWVaYRSLteFrv2nHvD5g+ED+t6/5zMy4VHv8zbgNuyYTY1mpnKENg==", "ecde092c-cf1a-41f6-93e4-bb26459a9c36" });

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMember_AppUserId",
                table: "FamilyMember",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMember_AspNetUsers_AppUserId",
                table: "FamilyMember",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMember_AspNetUsers_AppUserId",
                table: "FamilyMember");

            migrationBuilder.DropIndex(
                name: "IX_FamilyMember_AppUserId",
                table: "FamilyMember");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "FamilyMember");

            migrationBuilder.AddColumn<Guid>(
                name: "FamilyMemberId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75b5fe28-7aac-4b20-b430-1d1a045b5afa",
                columns: new[] { "ConcurrencyStamp", "FamilyMemberId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31b0fd15-5f25-4424-9432-9a595cf6b57b", null, "AQAAAAIAAYagAAAAEIoedElaSRRK7LIAOgm6hC0TJ3mvS7O96yxvYdQ/jKJnhG2TAHsyW1jvz2Ofp7S1tg==", "6199d919-1f7f-4d3c-877b-ccda2855933c" });
        }
    }
}
