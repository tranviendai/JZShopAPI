using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JZeno.Migrations
{
    /// <inheritdoc />
    public partial class Database01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isChecked",
                table: "ProductColor");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "a79e98b4-d8a6-4640-98eb-5b417ffb2661",
                columns: new[] { "Birthday", "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2023, 6, 10, 18, 52, 15, 147, DateTimeKind.Local).AddTicks(949), "2f92cb75-a9d8-4f84-a391-67f3f8039953", new DateTime(2023, 6, 10, 18, 52, 15, 147, DateTimeKind.Local).AddTicks(961), "AQAAAAIAAYagAAAAEKy3IL/I6RkZ0WdH7hwwKxiaxl5rkZXsX6d58WOA6q68fjqwFLxd8/2CSInKdHfDRg==", "1d1f6e27-2a9d-44b5-a51c-d600d51f4dc0" });
        }
    }
}
