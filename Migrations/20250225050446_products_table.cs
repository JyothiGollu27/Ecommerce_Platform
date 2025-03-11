using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_Platform.Migrations
{
    /// <inheritdoc />
    public partial class products_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Users",
                newName: "ShippingAddress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShippingAddress",
                table: "Users",
                newName: "EmailAddress");
        }
    }
}
