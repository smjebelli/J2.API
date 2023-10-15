using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace J2.API.Migrations
{
    /// <inheritdoc />
    public partial class familymembermodified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMember_Families_FamilyId",
                table: "FamilyMember");

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

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "FamilyMember",
                newName: "NickName");

            migrationBuilder.AlterColumn<Guid>(
                name: "FamilyId",
                table: "FamilyMember",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMember_Families_FamilyId",
                table: "FamilyMember",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMember_Families_FamilyId",
                table: "FamilyMember");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "FamilyMember");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "FamilyMember");

            migrationBuilder.DropColumn(
                name: "hello",
                table: "Families");

            migrationBuilder.RenameColumn(
                name: "NickName",
                table: "FamilyMember",
                newName: "Name");

            migrationBuilder.AlterColumn<Guid>(
                name: "FamilyId",
                table: "FamilyMember",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75b5fe28-7aac-4b20-b430-1d1a045b5afa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3cc92dc2-9ccc-4c88-9419-5f28296b1b1e", "AQAAAAIAAYagAAAAEImk+c+IpXct3LawkJHy0CFNKUgqTBghCObBHmsxFn3SBPlSWlCnrmxF48QV/OEoeA==", "d322bb0f-7f97-416c-8e6f-d27a2f0bacfa" });

            migrationBuilder.InsertData(
                table: "ExpenseCategories",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 9, 7, 10, 45, 32, 35, DateTimeKind.Local).AddTicks(202), "هزینه های جاری مانند خوارک و جابجایی و ...", null, null, "جاری" },
                    { 2, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 9, 7, 10, 45, 32, 35, DateTimeKind.Local).AddTicks(230), "پزشکی و بهداشتی و بیمه", null, null, "درمانی و بیمه" },
                    { 3, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 9, 7, 10, 45, 32, 35, DateTimeKind.Local).AddTicks(234), "تعمیر، سرویس و نگهداری", null, null, "خودرو" },
                    { 4, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 9, 7, 10, 45, 32, 35, DateTimeKind.Local).AddTicks(234), "سفر، تفریح، ورزش و مرتبط با آن", null, null, "تفریح و سلامتی" },
                    { 5, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 9, 7, 10, 45, 32, 35, DateTimeKind.Local).AddTicks(237), "اجاره، تعمیرات، خرجهای اساسی منزل", null, null, "خانه و نگهداری آن" },
                    { 6, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 9, 7, 10, 45, 32, 35, DateTimeKind.Local).AddTicks(238), "هزینه های تحصیل، لوازم التحریر، اسباب بازی و ... کودکان", null, null, "کودکان" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMember_Families_FamilyId",
                table: "FamilyMember",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id");
        }
    }
}
