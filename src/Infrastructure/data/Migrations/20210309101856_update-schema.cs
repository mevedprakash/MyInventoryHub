using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class updateschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Brand_BrandId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSupply_Supplier_SupplierId",
                table: "ProductSupply");

            migrationBuilder.DropForeignKey(
                name: "FK_User_FileStore_ProfileImageId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ProfileImageId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ProfileImageId",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "MRP",
                table: "ProductSupply",
                newName: "SellingPrice");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "OrderItem",
                newName: "SubAmount");

            migrationBuilder.RenameColumn(
                name: "SubTotalAmount",
                table: "OrderItem",
                newName: "PriceRate");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "OrderItem",
                newName: "NetAmount");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Order",
                newName: "SubAmount");

            migrationBuilder.RenameColumn(
                name: "SubTotalAmount",
                table: "Order",
                newName: "NetAmount");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "ProductSupply",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "PurchasPrice",
                table: "ProductSupply",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AvaiableQuantity",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Product",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "Product",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Order",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "OrderNo",
                table: "Order",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Brand",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Brand",
                type: "bit(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_User_ImageId",
                table: "User",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ImageId",
                table: "Product",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Brand_ImageId",
                table: "Brand",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brand_FileStore_ImageId",
                table: "Brand",
                column: "ImageId",
                principalTable: "FileStore",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brand_BrandId",
                table: "Product",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_FileStore_ImageId",
                table: "Product",
                column: "ImageId",
                principalTable: "FileStore",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSupply_Supplier_SupplierId",
                table: "ProductSupply",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_FileStore_ImageId",
                table: "User",
                column: "ImageId",
                principalTable: "FileStore",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brand_FileStore_ImageId",
                table: "Brand");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Brand_BrandId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_FileStore_ImageId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSupply_Supplier_SupplierId",
                table: "ProductSupply");

            migrationBuilder.DropForeignKey(
                name: "FK_User_FileStore_ImageId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ImageId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Product_ImageId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Brand_ImageId",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PurchasPrice",
                table: "ProductSupply");

            migrationBuilder.DropColumn(
                name: "AvaiableQuantity",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SKU",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OrderNo",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Brand");

            migrationBuilder.RenameColumn(
                name: "SellingPrice",
                table: "ProductSupply",
                newName: "MRP");

            migrationBuilder.RenameColumn(
                name: "SubAmount",
                table: "OrderItem",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "PriceRate",
                table: "OrderItem",
                newName: "SubTotalAmount");

            migrationBuilder.RenameColumn(
                name: "NetAmount",
                table: "OrderItem",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "SubAmount",
                table: "Order",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "NetAmount",
                table: "Order",
                newName: "SubTotalAmount");

            migrationBuilder.AddColumn<int>(
                name: "ProfileImageId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "ProductSupply",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_ProfileImageId",
                table: "User",
                column: "ProfileImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brand_BrandId",
                table: "Product",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSupply_Supplier_SupplierId",
                table: "ProductSupply",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_FileStore_ProfileImageId",
                table: "User",
                column: "ProfileImageId",
                principalTable: "FileStore",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
