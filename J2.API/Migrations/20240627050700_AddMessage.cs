using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace J2.API.Migrations
{
    /// <inheritdoc />
    public partial class AddMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "FamilyMember",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Expenses",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75b5fe28-7aac-4b20-b430-1d1a045b5afa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "085f4ac0-3f03-4c49-9202-fe8483a6500d", "AQAAAAIAAYagAAAAEKNKL7wug8AeQ+J+riahpIltQIKDq46Oc7p6pp69N9cHo8HV3yGVAqbFijI3GQzDlQ==", "dcabeaa5-8640-4d9b-abeb-b5c9847d0a5b" });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 27, 8, 36, 59, 717, DateTimeKind.Local).AddTicks(101));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 27, 8, 36, 59, 717, DateTimeKind.Local).AddTicks(109));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 27, 8, 36, 59, 717, DateTimeKind.Local).AddTicks(110));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 27, 8, 36, 59, 717, DateTimeKind.Local).AddTicks(111));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 27, 8, 36, 59, 717, DateTimeKind.Local).AddTicks(113));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 27, 8, 36, 59, 717, DateTimeKind.Local).AddTicks(114));

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

            migrationBuilder.AlterColumn<long>(
                name: "Amount",
                table: "Expenses",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

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
    }
}
