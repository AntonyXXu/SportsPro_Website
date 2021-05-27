using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsPro.Migrations
{
    public partial class thursdayam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Name", "ProductCode", "ReleaseDate", "YearlyPrice" },
                values: new object[,]
                {
                    { 1, "Draft Manager 1.0", "DRAFT10", new DateTime(2017, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.99m },
                    { 2, "Draft Manager 2.0", "DRAFT20", new DateTime(2019, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.99m },
                    { 3, "League Scheduler 1.0", "LEAG10", new DateTime(2016, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.99m },
                    { 4, "League Scheduler Deluxe 1.0", "LEAGD10", new DateTime(2016, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.99m },
                    { 5, "Team Manager 1.0", "TEAM10", new DateTime(2017, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.99m },
                    { 6, "Tournament Master 1.0", "TRNY10", new DateTime(2015, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.99m },
                    { 7, "Tournament Master 2.0", "TRNY20", new DateTime(2018, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.99m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomerProducts",
                keyColumns: new[] { "ProductID", "CustomerID" },
                keyValues: new object[] { 3, 1010 });

            migrationBuilder.DeleteData(
                table: "CustomerProducts",
                keyColumns: new[] { "ProductID", "CustomerID" },
                keyValues: new object[] { 4, 1002 });

            migrationBuilder.DeleteData(
                table: "Incidents",
                keyColumn: "IncidentID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Incidents",
                keyColumn: "IncidentID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Incidents",
                keyColumn: "IncidentID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Incidents",
                keyColumn: "IncidentID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "CustomerProducts",
                columns: new[] { "ProductID", "CustomerID" },
                values: new object[,]
                {
                    { 3, 1010 },
                    { 4, 1002 }
                });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "IncidentID", "CustomerID", "DateClosed", "DateOpened", "Description", "ProductID", "TechnicianID", "Title" },
                values: new object[,]
                {
                    { 4, 1010, null, new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Program fails with error code 510, unable to open database.", 3, null, "Error launching program" },
                    { 3, 1015, new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Setup failed with code 104.", 6, 15, "Could not install" },
                    { 2, 1002, null, new DateTime(2020, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Received error message 415 while trying to import data from previous version.", 4, 14, "Error importing data" },
                    { 1, 1010, new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Media appears to be bad.", 1, 11, "Could not install" }
                });
        }
    }
}
