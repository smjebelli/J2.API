using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace J2.API.Migrations
{
    /// <inheritdoc />
    public partial class familyMemberModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMember_AspNetUsers_AppUserId",
                table: "FamilyMember");

            migrationBuilder.DropIndex(
                name: "IX_FamilyMember_AppUserId",
                table: "FamilyMember");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FamilyMember");

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserId",
                table: "FamilyMember",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "FamilyMember",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFamilyAdmin",
                table: "FamilyMember",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75b5fe28-7aac-4b20-b430-1d1a045b5afa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0da97503-ffb7-40fc-8c14-31d19e26e05a", "AQAAAAIAAYagAAAAEJeZZrgMT41ITv5Jwyv2xZl3JtZ+vykGo8vOd/xFJ7uY6NESbqLV1vi2H6qWjamx0g==", "35d14a49-eccd-4a15-96f3-f8cff4b6689c" });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 21, 12, 32, 14, 239, DateTimeKind.Local).AddTicks(8795));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 21, 12, 32, 14, 239, DateTimeKind.Local).AddTicks(8809));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 21, 12, 32, 14, 239, DateTimeKind.Local).AddTicks(8810));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 21, 12, 32, 14, 239, DateTimeKind.Local).AddTicks(8811));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 21, 12, 32, 14, 239, DateTimeKind.Local).AddTicks(8811));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 21, 12, 32, 14, 239, DateTimeKind.Local).AddTicks(8812));

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMember_AppUserId1",
                table: "FamilyMember",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMember_AspNetUsers_AppUserId1",
                table: "FamilyMember",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMember_AspNetUsers_AppUserId1",
                table: "FamilyMember");

            migrationBuilder.DropIndex(
                name: "IX_FamilyMember_AppUserId1",
                table: "FamilyMember");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "FamilyMember");

            migrationBuilder.DropColumn(
                name: "IsFamilyAdmin",
                table: "FamilyMember");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "FamilyMember",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "FamilyMember",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75b5fe28-7aac-4b20-b430-1d1a045b5afa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fcdfeb7-724d-453f-aad8-10c9152ecf42", "AQAAAAIAAYagAAAAEMD5h+jMo6bUofANVlx8evpZok5ImTsxnpNU3IcDF2wF9St0n4teRntonIe3pEUM+g==", "aa7ec11d-a997-4c41-8c3e-2bad9eb707e8" });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 21, 12, 16, 32, 70, DateTimeKind.Local).AddTicks(9258));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 21, 12, 16, 32, 70, DateTimeKind.Local).AddTicks(9274));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 21, 12, 16, 32, 70, DateTimeKind.Local).AddTicks(9274));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 21, 12, 16, 32, 70, DateTimeKind.Local).AddTicks(9275));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 21, 12, 16, 32, 70, DateTimeKind.Local).AddTicks(9276));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 21, 12, 16, 32, 70, DateTimeKind.Local).AddTicks(9277));

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
    }
}
