using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace J2.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFamilyMember2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FamilyMemberId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75b5fe28-7aac-4b20-b430-1d1a045b5afa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c2c25a0-5bb1-4fb4-8063-13a442a8c130", "AQAAAAIAAYagAAAAEEx1Khk9TV2rQzo0WsmrENwWJZEFt9XZYEwJEuY42v3J/Md8ZMIXeI9GmcaJECKvxw==", "79684d61-1ddd-4490-a786-fa0f5f05d043" });
        }
    }
}
