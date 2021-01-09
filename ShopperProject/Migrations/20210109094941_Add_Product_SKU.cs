using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopperProject.Migrations
{
    public partial class Add_Product_SKU : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "HangHoa",
                maxLength: 7,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SKU",
                table: "HangHoa");
        }
    }
}
