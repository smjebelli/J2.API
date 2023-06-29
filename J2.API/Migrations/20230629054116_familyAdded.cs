using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace J2.API.Migrations
{
    /// <inheritdoc />
    public partial class familyAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FamilyId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FamilyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Families",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "FamilyName", "LastModifiedBy", "LastModifiedOn" },
                values: new object[] { new Guid("79b20623-afc5-48b8-aeb1-6bd1f1738054"), new Guid("e57ba91b-7559-413d-b0df-b7fbcc69f29c"), new DateTime(2023, 6, 29, 9, 11, 16, 175, DateTimeKind.Local).AddTicks(888), "Test", null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Email", "FamilyId", "FirstName", "LastModifiedBy", "LastModifiedOn", "LastName", "MobileNumber", "UserName" },
                values: new object[] { new Guid("e57ba91b-7559-413d-b0df-b7fbcc69f29c"), new Guid("e57ba91b-7559-413d-b0df-b7fbcc69f29c"), new DateTime(2023, 6, 29, 9, 11, 16, 175, DateTimeKind.Local).AddTicks(866), "s.m.jebelli@gmail.com", new Guid("79b20623-afc5-48b8-aeb1-6bd1f1738054"), "admin", null, null, "admin", "09355270270", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_FamilyId",
                table: "Users",
                column: "FamilyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Families_FamilyId",
                table: "Users",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Families_FamilyId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Families");

            migrationBuilder.DropIndex(
                name: "IX_Users_FamilyId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e57ba91b-7559-413d-b0df-b7fbcc69f29c"));

            migrationBuilder.DropColumn(
                name: "FamilyId",
                table: "Users");
        }
    }
}
