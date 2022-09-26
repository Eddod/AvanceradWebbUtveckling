using Microsoft.EntityFrameworkCore.Migrations;

namespace AvanceradWebbUtveckling.Migrations
{
    public partial class ChangedLoanModelPropertiesToList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Books_BookID",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Customers_CustomerID",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_BookID",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_CustomerID",
                table: "Loans");

            migrationBuilder.AddColumn<int>(
                name: "LoanID",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoanID",
                table: "Books",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LoanID",
                table: "Customers",
                column: "LoanID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_LoanID",
                table: "Books",
                column: "LoanID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Loans_LoanID",
                table: "Books",
                column: "LoanID",
                principalTable: "Loans",
                principalColumn: "LoanID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Loans_LoanID",
                table: "Customers",
                column: "LoanID",
                principalTable: "Loans",
                principalColumn: "LoanID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Loans_LoanID",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Loans_LoanID",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_LoanID",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Books_LoanID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "LoanID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LoanID",
                table: "Books");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BookID",
                table: "Loans",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_CustomerID",
                table: "Loans",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Books_BookID",
                table: "Loans",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Customers_CustomerID",
                table: "Loans",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
