using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace J2.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFamilyMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "FamilyMember");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "FamilyMember");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "FamilyMember",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75b5fe28-7aac-4b20-b430-1d1a045b5afa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "8c2c25a0-5bb1-4fb4-8063-13a442a8c130", "AQAAAAIAAYagAAAAEEx1Khk9TV2rQzo0WsmrENwWJZEFt9XZYEwJEuY42v3J/Md8ZMIXeI9GmcaJECKvxw==", "79684d61-1ddd-4490-a786-fa0f5f05d043", "09355270270" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FamilyMember");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "FamilyMember",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "FamilyMember",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75b5fe28-7aac-4b20-b430-1d1a045b5afa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "ac62dd21-1f44-4b6c-b9f8-643de0eef757", "AQAAAAIAAYagAAAAEORScuw372rD1o8282umNt4nOncn7/zEBJ9s0aAqsl8FTqVbTcAQxHf2xaFTTS5mYg==", "efcefb73-1b23-4878-ae7c-816848124791", "s.m.jebelli@gmail.com" });
        }
    }
}
