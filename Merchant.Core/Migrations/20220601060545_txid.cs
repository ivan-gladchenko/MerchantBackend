using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merchant.Core.Migrations
{
    public partial class txid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Txid",
                table: "MerchantTransactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Txid",
                table: "MerchantTransactions");
        }
    }
}
