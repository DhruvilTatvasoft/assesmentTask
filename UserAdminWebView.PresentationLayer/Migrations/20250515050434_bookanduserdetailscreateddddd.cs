using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserAdminWebView.PresentationLayer.Migrations
{
    /// <inheritdoc />
    public partial class bookanduserdetailscreateddddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "UserDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "UserDetails",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "UserDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "UserDetails",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
