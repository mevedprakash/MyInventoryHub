using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class updateschema1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "ProductSupply",
                newName: "SubAmount");

            migrationBuilder.RenameColumn(
                name: "SubTotalAmount",
                table: "ProductSupply",
                newName: "NetAmount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubAmount",
                table: "ProductSupply",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "NetAmount",
                table: "ProductSupply",
                newName: "SubTotalAmount");
        }
    }
}
