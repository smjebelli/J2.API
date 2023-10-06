using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace J2.API.Migrations
{
    /// <inheritdoc />
    public partial class familyMembers_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Families_FamilyId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FamilyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FamilyId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "FamilyMember",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FamilyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyMember_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75b5fe28-7aac-4b20-b430-1d1a045b5afa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3cc92dc2-9ccc-4c88-9419-5f28296b1b1e", "AQAAAAIAAYagAAAAEImk+c+IpXct3LawkJHy0CFNKUgqTBghCObBHmsxFn3SBPlSWlCnrmxF48QV/OEoeA==", "d322bb0f-7f97-416c-8e6f-d27a2f0bacfa" });

            migrationBuilder.InsertData(
                table: "ExpenseCategories",
                columns: new[] { "CreatedBy", "CreatedOn", "Description", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    {  new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 9, 7, 10, 45, 32, 35, DateTimeKind.Local).AddTicks(202), "هزینه های جاری مانند خوارک و جابجایی و ...", null, null, "جاری" },
                    {  new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 9, 7, 10, 45, 32, 35, DateTimeKind.Local).AddTicks(230), "پزشکی و بهداشتی و بیمه", null, null, "درمانی و بیمه" },
                    {  new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 9, 7, 10, 45, 32, 35, DateTimeKind.Local).AddTicks(234), "تعمیر، سرویس و نگهداری", null, null, "خودرو" },
                    {  new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 9, 7, 10, 45, 32, 35, DateTimeKind.Local).AddTicks(234), "سفر، تفریح، ورزش و مرتبط با آن", null, null, "تفریح و سلامتی" },
                    {  new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 9, 7, 10, 45, 32, 35, DateTimeKind.Local).AddTicks(237), "اجاره، تعمیرات، خرجهای اساسی منزل", null, null, "خانه و نگهداری آن" },
                    {  new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 9, 7, 10, 45, 32, 35, DateTimeKind.Local).AddTicks(238), "هزینه های تحصیل، لوازم التحریر، اسباب بازی و ... کودکان", null, null, "کودکان" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMember_FamilyId",
                table: "FamilyMember",
                column: "FamilyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FamilyMember");

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

            migrationBuilder.AddColumn<Guid>(
                name: "FamilyId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75b5fe28-7aac-4b20-b430-1d1a045b5afa",
                columns: new[] { "ConcurrencyStamp", "FamilyId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01f23c1f-40fd-45fa-ab92-b53dead3720e", null, "AQAAAAIAAYagAAAAEFwz6/VqGTpUQKU9IuQvvYJoVFj+5Mb3iZMYNqFMGRr+a0thS+Yyxp4WtwgW/cEY+A==", "85287cbf-d752-4255-867d-60b35f3f758e" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FamilyId",
                table: "AspNetUsers",
                column: "FamilyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Families_FamilyId",
                table: "AspNetUsers",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id");
        }
    }
}
