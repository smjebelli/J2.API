using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace J2.API.Migrations
{
    /// <inheritdoc />
    public partial class seedsChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Authors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifiedBy",
                table: "Authors",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MembershipNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "FirstName", "LastModifiedBy", "LastModifiedOn", "LastName" },
                values: new object[,]
                {
                    { new Guid("2b80bfa8-ce9c-4d35-842d-a2dc1698b410"), new Guid("54a0b7e7-f4dd-47f3-89b0-b12752578ccc"), new DateTime(2023, 5, 19, 20, 39, 45, 520, DateTimeKind.Local).AddTicks(2406), "جورج", null, null, "اورول" },
                    { new Guid("3a08bfd7-7ceb-4797-8ff0-940f3a669fd0"), new Guid("54a0b7e7-f4dd-47f3-89b0-b12752578ccc"), new DateTime(2023, 5, 19, 20, 39, 45, 520, DateTimeKind.Local).AddTicks(2592), "جین", null, null, "آستن" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "MembershipNumber", "PhoneNumber", "UserName" },
                values: new object[] { new Guid("54a0b7e7-f4dd-47f3-89b0-b12752578ccc"), null, "admin@example.com", "admin", "admin", "1", "1213", "admin" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "DatePublished", "Genre", "Isbn", "Title" },
                values: new object[,]
                {
                    { new Guid("27220a7d-abab-40d8-9882-77f55f80e497"), new Guid("2b80bfa8-ce9c-4d35-842d-a2dc1698b410"), new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "رمان", "12344", "1984" },
                    { new Guid("4f9cfc10-a5a4-4ddc-9f77-6e214699fe6f"), new Guid("3a08bfd7-7ceb-4797-8ff0-940f3a669fd0"), new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "رمان", "38298329", "غرور و تعصب" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("27220a7d-abab-40d8-9882-77f55f80e497"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("4f9cfc10-a5a4-4ddc-9f77-6e214699fe6f"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("2b80bfa8-ce9c-4d35-842d-a2dc1698b410"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("3a08bfd7-7ceb-4797-8ff0-940f3a669fd0"));

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Authors");

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
    }
}
