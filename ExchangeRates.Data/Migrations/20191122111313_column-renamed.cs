using Microsoft.EntityFrameworkCore.Migrations;

namespace ExchangeRates.Data.Migrations
{
    public partial class columnrenamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rates_Currency_CurrencyId",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Rates");

            migrationBuilder.AlterColumn<int>(
                name: "CurrencyId",
                table: "Rates",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_Currency_CurrencyId",
                table: "Rates",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "CurrencyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rates_Currency_CurrencyId",
                table: "Rates");

            migrationBuilder.AlterColumn<int>(
                name: "CurrencyId",
                table: "Rates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Rates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_Currency_CurrencyId",
                table: "Rates",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "CurrencyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
