using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockTrackingApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarModelId",
                table: "Parts",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Parts_CarModelId",
                table: "Parts",
                column: "CarModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_CarModels_CarModelId",
                table: "Parts",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_CarModels_CarModelId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_CarModelId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "CarModelId",
                table: "Parts");
        }
    }
}
