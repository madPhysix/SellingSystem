using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellingSystem.Migrations
{
    public partial class ReturningInvoiceAddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReturningInvoiceId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReturningInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoicesId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturningInvoices", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ReturningInvoiceId",
                table: "Orders",
                column: "ReturningInvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ReturningInvoices_ReturningInvoiceId",
                table: "Orders",
                column: "ReturningInvoiceId",
                principalTable: "ReturningInvoices",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ReturningInvoices_ReturningInvoiceId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "ReturningInvoices");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ReturningInvoiceId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ReturningInvoiceId",
                table: "Orders");
        }
    }
}
