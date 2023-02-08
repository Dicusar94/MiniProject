using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mag.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitMigraiton : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AvailabilityProductionDate = table.Column<DateTime>(name: "Availability_ProductionDate", type: "datetime2", nullable: false),
                    AvailabilityExpirationDate = table.Column<DateTime>(name: "Availability_ExpirationDate", type: "datetime2", nullable: false),
                    AvailabilityDaysOfValidity = table.Column<int>(name: "Availability_DaysOfValidity", type: "int", nullable: false),
                    PricingStock = table.Column<double>(name: "Pricing_Stock", type: "float", nullable: false),
                    PricingSale = table.Column<double>(name: "Pricing_Sale", type: "float", nullable: false),
                    DiscountPercent = table.Column<double>(name: "Discount_Percent", type: "float", nullable: false),
                    DiscountIsTwentyPercent = table.Column<bool>(name: "Discount_IsTwentyPercent", type: "bit", nullable: false),
                    DiscountIsFiftyPercent = table.Column<bool>(name: "Discount_IsFiftyPercent", type: "bit", nullable: false),
                    DiscountIsOneHundredPercent = table.Column<bool>(name: "Discount_IsOneHundredPercent", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
