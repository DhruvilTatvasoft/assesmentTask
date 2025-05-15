using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserAdminWebView.PresentationLayer.Migrations
{
    /// <inheritdoc />
    public partial class bookanduserdetailscreatedddddddddddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "UserBooks",
                type: "boolean",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "UserBooks");
        }
    }
}
