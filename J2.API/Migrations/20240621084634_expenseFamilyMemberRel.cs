using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace J2.API.Migrations
{
    /// <inheritdoc />
    public partial class expenseFamilyMemberRel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Expenses",
                newName: "FamilyMemberId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75b5fe28-7aac-4b20-b430-1d1a045b5afa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fcdfeb7-724d-453f-aad8-10c9152ecf42", "AQAAAAIAAYagAAAAEMD5h+jMo6bUofANVlx8evpZok5ImTsxnpNU3IcDF2wF9St0n4teRntonIe3pEUM+g==", "aa7ec11d-a997-4c41-8c3e-2bad9eb707e8" });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 21, 12, 16, 32, 70, DateTimeKind.Local).AddTicks(9258));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 21, 12, 16, 32, 70, DateTimeKind.Local).AddTicks(9274));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 21, 12, 16, 32, 70, DateTimeKind.Local).AddTicks(9274));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 21, 12, 16, 32, 70, DateTimeKind.Local).AddTicks(9275));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 21, 12, 16, 32, 70, DateTimeKind.Local).AddTicks(9276));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 21, 12, 16, 32, 70, DateTimeKind.Local).AddTicks(9277));

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_FamilyMemberId",
                table: "Expenses",
                column: "FamilyMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_FamilyMember_FamilyMemberId",
                table: "Expenses",
                column: "FamilyMemberId",
                principalTable: "FamilyMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_FamilyMember_FamilyMemberId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_FamilyMemberId",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "FamilyMemberId",
                table: "Expenses",
                newName: "UserId");

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
    }
}
