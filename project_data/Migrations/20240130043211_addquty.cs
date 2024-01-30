using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_data.Migrations
{
    public partial class addquty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Prdqty",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prdqty",
                table: "Products");
        }
    }
}
