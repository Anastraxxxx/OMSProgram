using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMSProgram.Migrations
{
    /// <inheritdoc />
    public partial class NewUserAndProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AccountsIdToShop_AccountIdToShopId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "AccountsIdToShop");

            migrationBuilder.DropIndex(
                name: "IX_Products_AccountIdToShopId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AccountIdToShopId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "AccountIdToShopId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccountsIdToShop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountsIdToShop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountsIdToShop_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_AccountIdToShopId",
                table: "Products",
                column: "AccountIdToShopId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsIdToShop_UserId",
                table: "AccountsIdToShop",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AccountsIdToShop_AccountIdToShopId",
                table: "Products",
                column: "AccountIdToShopId",
                principalTable: "AccountsIdToShop",
                principalColumn: "Id");
        }
    }
}
