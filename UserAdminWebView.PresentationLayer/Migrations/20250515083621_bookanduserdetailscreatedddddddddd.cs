using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserAdminWebView.PresentationLayer.Migrations
{
    /// <inheritdoc />
    public partial class bookanduserdetailscreatedddddddddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "year",
                table: "BookDetails",
                type: "text",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "BookDetails",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "BookDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "year",
                table: "BookDetails",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
