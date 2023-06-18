using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JZeno.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isChecked",
                table: "ProductColor");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "a79e98b4-d8a6-4640-98eb-5b417ffb2661",
                columns: new[] { "Birthday", "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2023, 6, 13, 18, 55, 57, 558, DateTimeKind.Local).AddTicks(5757), "b33ae734-2939-429f-95b2-9bde4d6deaa6", new DateTime(2023, 6, 13, 18, 55, 57, 558, DateTimeKind.Local).AddTicks(5773), "AQAAAAIAAYagAAAAEEcx4Az4Uw5Rv+xPhy/1VxhsB1dD12gwwdE2nd5FmynwfyPHXGmfy7i4Xd+FWsod1g==", "de7fbb24-760a-4ea4-bd6b-3bc007f1a7c8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isChecked",
                table: "ProductColor",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "a79e98b4-d8a6-4640-98eb-5b417ffb2661",
                columns: new[] { "Birthday", "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2023, 6, 10, 23, 36, 58, 254, DateTimeKind.Local).AddTicks(9070), "5ab193e7-5ebc-4946-a5f2-87f86ad6cf92", new DateTime(2023, 6, 10, 23, 36, 58, 254, DateTimeKind.Local).AddTicks(9083), "AQAAAAIAAYagAAAAEG/7Rm2QrTRxi7EPhN2jXcsvRjrkRz44T8BsXzdIt7/JQPEcE2v2Tyr7yEcYu8NDlQ==", "023f4e89-77cc-4e70-912f-4d6aca263546" });
        }
    }
}
