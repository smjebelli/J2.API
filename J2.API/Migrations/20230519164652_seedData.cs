using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace J2.API.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "Authors",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "CreatedOn", "FirstName", "LastModifiedOn", "LastName" },
                values: new object[,]
                {
                    { new Guid("074d20a2-91b4-4920-a4e1-c3b0d6d6e0d8"), new DateTime(2023, 5, 19, 20, 16, 52, 272, DateTimeKind.Local).AddTicks(1270), "جورج", null, "اورول" },
                    { new Guid("f0189a83-960f-432b-b90e-faf807a7bf86"), new DateTime(2023, 5, 19, 20, 16, 52, 272, DateTimeKind.Local).AddTicks(1340), "جین", null, "آستن" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "DatePublished", "Genre", "Isbn", "Title" },
                values: new object[] { new Guid("a5e01212-2014-4d07-af07-d7fab460a404"), new Guid("074d20a2-91b4-4920-a4e1-c3b0d6d6e0d8"), new DateTime(1949, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "رمان", "12344", "1984" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("f0189a83-960f-432b-b90e-faf807a7bf86"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("a5e01212-2014-4d07-af07-d7fab460a404"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("074d20a2-91b4-4920-a4e1-c3b0d6d6e0d8"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "Authors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
