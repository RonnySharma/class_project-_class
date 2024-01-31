using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_data.Migrations
{
    public partial class dropproductQunt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prdqty",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Prdqty",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
