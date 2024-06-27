using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace J2.API.Migrations
{
    /// <inheritdoc />
    public partial class seedCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75b5fe28-7aac-4b20-b430-1d1a045b5afa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f87d68d0-3f5a-4305-882c-4eaa23eeabb4", "AQAAAAIAAYagAAAAEC2AMviU6HkJcTjf6OeH7e1S68VL+bCo7+jAuHCX24WhZiLcLzV3HQ7A8U6JT85vSA==", "4a4b26ee-21da-4ca3-a1d9-24553b2d685d" });

            migrationBuilder.InsertData(
                table: "ExpenseCategories",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 21, 11, 30, 19, 335, DateTimeKind.Local).AddTicks(721), "هزینه های جاری مانند خوارک و جابجایی و ...", null, null, "جاری" },
                    { 2, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 21, 11, 30, 19, 335, DateTimeKind.Local).AddTicks(745), "پزشکی و بهداشتی و بیمه", null, null, "درمانی و بیمه" },
                    { 3, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 21, 11, 30, 19, 335, DateTimeKind.Local).AddTicks(746), "تعمیر، سرویس و نگهداری", null, null, "خودرو" },
                    { 4, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 21, 11, 30, 19, 335, DateTimeKind.Local).AddTicks(747), "سفر، تفریح، ورزش و مرتبط با آن", null, null, "تفریح و سلامتی" },
                    { 5, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 21, 11, 30, 19, 335, DateTimeKind.Local).AddTicks(748), "اجاره، تعمیرات، خرجهای اساسی منزل", null, null, "خانه و نگهداری آن" },
                    { 6, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 21, 11, 30, 19, 335, DateTimeKind.Local).AddTicks(749), "هزینه های تحصیل، لوازم التحریر، اسباب بازی و ... کودکان", null, null, "کودکان" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75b5fe28-7aac-4b20-b430-1d1a045b5afa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59fca8b0-a465-4d80-b29c-1b6c3e05ef44", "AQAAAAIAAYagAAAAEIpwm43vMYb8eHWVaYRSLteFrv2nHvD5g+ED+t6/5zMy4VHv8zbgNuyYTY1mpnKENg==", "ecde092c-cf1a-41f6-93e4-bb26459a9c36" });
        }
    }
}
