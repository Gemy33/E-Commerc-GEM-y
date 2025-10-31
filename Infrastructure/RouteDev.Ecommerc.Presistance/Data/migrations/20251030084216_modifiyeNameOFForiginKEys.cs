using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RouteDev.Ecommerc.Presistance.Data.migrations
{
    /// <inheritdoc />
    public partial class modifiyeNameOFForiginKEys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_productBrands_ProductBrandId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_productTypes_ProductTypeId",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "productTypes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ProductTypeId",
                table: "products",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "ProductBrandId",
                table: "products",
                newName: "BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_products_ProductTypeId",
                table: "products",
                newName: "IX_products_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_products_ProductBrandId",
                table: "products",
                newName: "IX_products_BrandId");

            migrationBuilder.RenameColumn(
                name: "Brand",
                table: "productBrands",
                newName: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_products_productBrands_BrandId",
                table: "products",
                column: "BrandId",
                principalTable: "productBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_products_productTypes_TypeId",
                table: "products",
                column: "TypeId",
                principalTable: "productTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_productBrands_BrandId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_productTypes_TypeId",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "productTypes",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "products",
                newName: "ProductTypeId");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "products",
                newName: "ProductBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_products_TypeId",
                table: "products",
                newName: "IX_products_ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_products_BrandId",
                table: "products",
                newName: "IX_products_ProductBrandId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "productBrands",
                newName: "Brand");

            migrationBuilder.AddForeignKey(
                name: "FK_products_productBrands_ProductBrandId",
                table: "products",
                column: "ProductBrandId",
                principalTable: "productBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_products_productTypes_ProductTypeId",
                table: "products",
                column: "ProductTypeId",
                principalTable: "productTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
