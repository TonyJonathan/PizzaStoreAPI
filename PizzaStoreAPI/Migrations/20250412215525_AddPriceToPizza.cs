using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceToPizza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Pizzas",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 10.00m); // ← ✅ valeur par défaut
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
