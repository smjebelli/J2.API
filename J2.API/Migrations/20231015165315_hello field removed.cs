using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace J2.API.Migrations
{
    /// <inheritdoc />
    public partial class hellofieldremoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hello",
                table: "Families");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75b5fe28-7aac-4b20-b430-1d1a045b5afa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f124e806-5f79-4792-ab84-311a8cd7ac93", "AQAAAAIAAYagAAAAEEzzDNayDjgLDG3sDjqkNc7MRe1rgw2r5JBB3S8LSY127L0dNeHv8t8JjmW7pQSEKQ==", "b7a56257-d936-47c5-88a3-b7bcd4cc9ae7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "hello",
                table: "Families",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75b5fe28-7aac-4b20-b430-1d1a045b5afa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9546256-a775-4b88-97fe-43ec62107014", "AQAAAAIAAYagAAAAEIcBp5OYiAAGEpe3aFyujLDl+7oNHyJm+WXFaW0Xsb6gLI7zNyXtg0gyDDvW6lI5Bg==", "147148a6-47a4-457d-8098-c08e7cf3de30" });
        }
    }
}
