using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace J2.API.Migrations
{
    /// <inheritdoc />
    public partial class confFromAssembley : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75b5fe28-7aac-4b20-b430-1d1a045b5afa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "900df5d5-1ece-4297-9295-49decb114901", "AQAAAAIAAYagAAAAEKenk4+Ds7AsO9VRcruvZixupCo51ZCp6Q8/WIcwsUQtS1bHFu8HDpDzbUXmdsKslw==", "6d1f2170-5c21-4386-9e99-b1a81f634f87" });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 21, 11, 36, 7, 326, DateTimeKind.Local).AddTicks(2693));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 21, 11, 36, 7, 326, DateTimeKind.Local).AddTicks(2703));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 21, 11, 36, 7, 326, DateTimeKind.Local).AddTicks(2704));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 21, 11, 36, 7, 326, DateTimeKind.Local).AddTicks(2705));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 21, 11, 36, 7, 326, DateTimeKind.Local).AddTicks(2706));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 21, 11, 36, 7, 326, DateTimeKind.Local).AddTicks(2711));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75b5fe28-7aac-4b20-b430-1d1a045b5afa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f87d68d0-3f5a-4305-882c-4eaa23eeabb4", "AQAAAAIAAYagAAAAEC2AMviU6HkJcTjf6OeH7e1S68VL+bCo7+jAuHCX24WhZiLcLzV3HQ7A8U6JT85vSA==", "4a4b26ee-21da-4ca3-a1d9-24553b2d685d" });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 21, 11, 30, 19, 335, DateTimeKind.Local).AddTicks(721));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 21, 11, 30, 19, 335, DateTimeKind.Local).AddTicks(745));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 21, 11, 30, 19, 335, DateTimeKind.Local).AddTicks(746));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 21, 11, 30, 19, 335, DateTimeKind.Local).AddTicks(747));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 21, 11, 30, 19, 335, DateTimeKind.Local).AddTicks(748));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 21, 11, 30, 19, 335, DateTimeKind.Local).AddTicks(749));
        }
    }
}
