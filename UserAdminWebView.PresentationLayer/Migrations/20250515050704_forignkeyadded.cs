using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserAdminWebView.PresentationLayer.Migrations
{
    /// <inheritdoc />
    public partial class forignkeyadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_Roleid",
                table: "UserDetails",
                column: "Roleid");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetails_Roles_Roleid",
                table: "UserDetails",
                column: "Roleid",
                principalTable: "Roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_Roles_Roleid",
                table: "UserDetails");

            migrationBuilder.DropIndex(
                name: "IX_UserDetails_Roleid",
                table: "UserDetails");
        }
    }
}
