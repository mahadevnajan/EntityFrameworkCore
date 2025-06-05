using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DbEntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class masterDataLanguage : Migration
    {
        /// <inheritdoc />
        /// 
        // 
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "India Mostly Used Language", "Hindi" },
                    { 2, "Tamil", "Tamil" },
                    { 3, "Hindu Marashtra Language", "Marathi" },
                    { 4, "Professional Language", "English" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
