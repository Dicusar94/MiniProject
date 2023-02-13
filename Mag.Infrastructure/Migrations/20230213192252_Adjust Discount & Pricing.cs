using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mag.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdjustDiscountPricing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount_IsFiftyPercent",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Discount_IsOneHundredPercent",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Discount_IsTwentyPercent",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Discount_Percent",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Pricing_Sale",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Discount_IsFiftyPercent",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Discount_IsOneHundredPercent",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Discount_IsTwentyPercent",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Discount_Percent",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Pricing_Sale",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
