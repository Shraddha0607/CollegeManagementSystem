using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeApp.Migrations
{
    /// <inheritdoc />
    public partial class transaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transactions_ApplicantId",
                table: "Transactions");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ApplicantId",
                table: "Transactions",
                column: "ApplicantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transactions_ApplicantId",
                table: "Transactions");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ApplicantId",
                table: "Transactions",
                column: "ApplicantId",
                unique: true);
        }
    }
}