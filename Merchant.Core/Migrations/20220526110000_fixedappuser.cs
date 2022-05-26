using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merchant.Core.Migrations
{
    public partial class fixedappuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "MerchantUsers");

            migrationBuilder.AddColumn<string>(
                name: "AppUserName",
                table: "MerchantUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiresAt",
                table: "MerchantTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "MerchantTransactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppUserName",
                table: "MerchantUsers");

            migrationBuilder.DropColumn(
                name: "ExpiresAt",
                table: "MerchantTransactions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "MerchantTransactions");

            migrationBuilder.AddColumn<long>(
                name: "AppUserId",
                table: "MerchantUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
