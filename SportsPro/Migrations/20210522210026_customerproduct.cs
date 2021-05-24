using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsPro.Migrations
{
    public partial class customerproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CustomerProducts",
                columns: new[] { "CustomerID", "ProductID" },
                values: new object[,]
                {
                    { 1002, 2 },
                    { 1004, 2 },
                    { 1006, 2 },
                    { 1008, 2 },
                    { 1010, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomerProducts",
                keyColumns: new[] { "CustomerID", "ProductID" },
                keyValues: new object[] { 1002, 2 });

            migrationBuilder.DeleteData(
                table: "CustomerProducts",
                keyColumns: new[] { "CustomerID", "ProductID" },
                keyValues: new object[] { 1004, 2 });

            migrationBuilder.DeleteData(
                table: "CustomerProducts",
                keyColumns: new[] { "CustomerID", "ProductID" },
                keyValues: new object[] { 1006, 2 });

            migrationBuilder.DeleteData(
                table: "CustomerProducts",
                keyColumns: new[] { "CustomerID", "ProductID" },
                keyValues: new object[] { 1008, 2 });

            migrationBuilder.DeleteData(
                table: "CustomerProducts",
                keyColumns: new[] { "CustomerID", "ProductID" },
                keyValues: new object[] { 1010, 2 });
        }
    }
}
