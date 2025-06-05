using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbEntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AddloginTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPrices_currencies_CurrencyId",
                table: "BookPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_currencies_currencies_CurrencyId",
                table: "currencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_currencies",
                table: "currencies");

            migrationBuilder.RenameTable(
                name: "currencies",
                newName: "Currencies");

            migrationBuilder.RenameIndex(
                name: "IX_currencies_CurrencyId",
                table: "Currencies",
                newName: "IX_Currencies_CurrencyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BookPrices_Currencies_CurrencyId",
                table: "BookPrices",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_Currencies_CurrencyId",
                table: "Currencies",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPrices_Currencies_CurrencyId",
                table: "BookPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_Currencies_CurrencyId",
                table: "Currencies");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies");

            migrationBuilder.RenameTable(
                name: "Currencies",
                newName: "currencies");

            migrationBuilder.RenameIndex(
                name: "IX_Currencies_CurrencyId",
                table: "currencies",
                newName: "IX_currencies_CurrencyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_currencies",
                table: "currencies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookPrices_currencies_CurrencyId",
                table: "BookPrices",
                column: "CurrencyId",
                principalTable: "currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_currencies_currencies_CurrencyId",
                table: "currencies",
                column: "CurrencyId",
                principalTable: "currencies",
                principalColumn: "Id");
        }
    }
}
