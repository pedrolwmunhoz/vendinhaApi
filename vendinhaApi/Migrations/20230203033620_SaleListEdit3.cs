using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vendinhaApi.Migrations
{
    /// <inheritdoc />
    public partial class SaleListEdit3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleList_Clients_ClientId",
                table: "SaleList");

            migrationBuilder.DropIndex(
                name: "IX_SaleList_ClientId",
                table: "SaleList");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SaleList_ClientId",
                table: "SaleList",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleList_Clients_ClientId",
                table: "SaleList",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
