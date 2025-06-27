using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbEntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class login_JobApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "UserLogin",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MobileNo",
                table: "JobApply",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "JobApply",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "UserLogin");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "JobApply");

            migrationBuilder.AlterColumn<string>(
                name: "MobileNo",
                table: "JobApply",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
