using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mag.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeisExpiredcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Availability_IsExpired",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Availability_IsExpired",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
