using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AvanceradWebbUtveckling.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookID", "Author", "BookDescription", "BookName", "IsAvailable" },
                values: new object[] { 2, "Anas", "Awesome adventure book", "Sagan om ringen 1", true });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookID", "Author", "BookDescription", "BookName", "IsAvailable" },
                values: new object[] { 3, "Anas", "Awesome adventure book sequel", "Sagan om ringen 2", true });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "LoanID", "BookID", "CustomerID", "Date", "IsReturned" },
                values: new object[] { 1, 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 1);
        }
    }
}
