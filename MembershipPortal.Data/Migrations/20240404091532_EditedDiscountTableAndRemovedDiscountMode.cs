using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MembershipPortal.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditedDiscountTableAndRemovedDiscountMode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_DiscountModes_DiscountModeId",
                table: "Discounts");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_DiscountModeId",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "DiscountModeId",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "DiscountModeType",
                table: "DiscountModes");

            migrationBuilder.AddColumn<bool>(
                name: "IsDiscountInPercentage",
                table: "Discounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDiscountInPercentage",
                table: "DiscountModes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDiscountInPercentage",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "IsDiscountInPercentage",
                table: "DiscountModes");

            migrationBuilder.AddColumn<long>(
                name: "DiscountModeId",
                table: "Discounts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "DiscountModeType",
                table: "DiscountModes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_DiscountModeId",
                table: "Discounts",
                column: "DiscountModeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_DiscountModes_DiscountModeId",
                table: "Discounts",
                column: "DiscountModeId",
                principalTable: "DiscountModes",
                principalColumn: "DiscountModeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
