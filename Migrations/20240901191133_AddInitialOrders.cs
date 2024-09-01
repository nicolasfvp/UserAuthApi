using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserAuthApi.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Metrics",
                columns: new[] { "id", "orders", "stock", "total", "users" },
                values: new object[] { 1, 100, 2, 100, 10 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "id", "date", "paymentMethod", "status", "value" },
                values: new object[,]
                {
                    { 1, "31/08/2024", "Dinheiro", "Em Preparação", "200" },
                    { 2, "28/08/2024", "Pix", "Em preparação", "200" },
                    { 3, "28/08/2024", "Cartão de crédito", "Em entrega", "200" },
                    { 4, "27/08/2024", "Cartão de crédito", "Entregue", "200" },
                    { 5, "24/08/2024", "Dinheiro", "Em entrega", "200" },
                    { 6, "22/08/2024", "Cartão de Débito", "Entregue", "200" },
                    { 7, "15/08/2024", "Cartão de crédito", "Entregue", "200" },
                    { 8, "14/08/2024", "Cartão de Débito", "Entregue", "200" },
                    { 9, "08/08/2024", "Pix", "Entregue", "200" },
                    { 10, "15/07/2024", "Pix", "Entregue", "200" },
                    { 11, "02/07/2024", "Cartão de Débito", "Entregue", "200" },
                    { 12, "24/04/2024", "Dinheiro", "Entregue", "200" },
                    { 13, "01/01/2024", "Dinheiro", "Inativo", "200" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Metrics",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "id",
                keyValue: 13);
        }
    }
}
