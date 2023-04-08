using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class Imagenes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Comanda",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 1,
                column: "Imagen",
                value: "https://drive.google.com/file/d/1xPKcmbPTsvVBwaNx37xEzp6gtbfT1WtJ/view");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 2,
                column: "Imagen",
                value: "https://drive.google.com/file/d/1E91-s9vzk17FGJGSVIyqGVH5kVTeQzb9/view");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 3,
                column: "Imagen",
                value: "https://drive.google.com/file/d/1kL9nMYb3wTNWri2N099LhZoYoJp1btXP/view");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 4,
                column: "Imagen",
                value: "https://drive.google.com/file/d/1tSMAO2-yZoDM3z3O4QkNzj25FLj-ovqp/view");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 5,
                column: "Imagen",
                value: "https://drive.google.com/file/d/1ZsYM1Y84JPPyznF3OmV8km5AJqxIr-Lh/view");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 6,
                column: "Imagen",
                value: "https://drive.google.com/file/d/1daQZfHgmK-P_1qd_qn_Odk766IkoI3Al/view");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 7,
                columns: new[] { "Imagen", "Preparacion" },
                values: new object[] { "https://drive.google.com/file/d/1g1yLG9S4vDO5WVKoTGcXjByr21UbUZ4K/view", "P1: Hacer un volcan con la harina,agregar la levadura e integrar.\nP2: Ir agregando el agua con el aceite y amasar.\nP3: Estirar en forma de pizza, agregar la salsa y condimentos.\nP4: Cocinar agregarndo los quesos encima de la masa." });

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 8,
                column: "Imagen",
                value: "https://drive.google.com/file/d/1wSuSxZfzGAOYLujShTfxaYhWK0R0EPt5/view");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 9,
                column: "Imagen",
                value: "https://drive.google.com/file/d/1Gzg_rCtYUffWPqRYRuKVTH9MS4zEsayC/view");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 10,
                column: "Imagen",
                value: "https://drive.google.com/file/d/1PCI5E0wW1ZpTCi8n5gzu93S3op_dXfE0/view");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 11,
                column: "Imagen",
                value: "https://drive.google.com/file/d/1SmWW3AYClTQjWSrcFtx6igYroIjiGmRa/view");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 12,
                column: "Imagen",
                value: "https://drive.google.com/file/d/1X6FHcKRVqgIO9SpY0Wb4-jDdspCLfgyj/view");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 13,
                column: "Imagen",
                value: "https://drive.google.com/file/d/1jjtoaOMDfmhtxlJIgCGtzmTV8Z-mGxCc/view");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 14,
                column: "Imagen",
                value: "https://drive.google.com/file/d/1UhYg6vNMURHFWhJnbwevTPEHH8uBXbmE/view");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 15,
                column: "Imagen",
                value: "https://drive.google.com/file/d/1K5Q9JrEa1lRHSH23gDM0ZR2HCFWaBRv6/view");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 16,
                column: "Imagen",
                value: "https://drive.google.com/file/d/1rGKWzKEpi2JInh7v6ht3i8mlTOPh96sl/view");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 17,
                columns: new[] { "Imagen", "Nombre" },
                values: new object[] { "https://drive.google.com/file/d/13TRC10uTERzdzHUzKYXkf-4PKjfTngLK/view", "Bife Americano" });

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 18,
                column: "Imagen",
                value: "https://drive.google.com/file/d/1nXp9l_8pvU3VGgL7VSZF49n7ym4_0Br5/view");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 19,
                column: "Imagen",
                value: "https://drive.google.com/file/d/1lD0i_VwhuPpYXEvrNvCxpPVwQTNP1YUe/view");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 20,
                column: "Imagen",
                value: "https://drive.google.com/file/d/1Gzlx8q0NKQLfUEILZKFxsD6xoqDX17gF/view");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Comanda",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 1,
                column: "Imagen",
                value: "");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 2,
                column: "Imagen",
                value: "");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 3,
                column: "Imagen",
                value: "");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 4,
                column: "Imagen",
                value: "");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 5,
                column: "Imagen",
                value: "");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 6,
                column: "Imagen",
                value: "");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 7,
                columns: new[] { "Imagen", "Preparacion" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 8,
                column: "Imagen",
                value: "");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 9,
                column: "Imagen",
                value: "");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 10,
                column: "Imagen",
                value: "");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 11,
                column: "Imagen",
                value: "");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 12,
                column: "Imagen",
                value: "");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 13,
                column: "Imagen",
                value: "");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 14,
                column: "Imagen",
                value: "");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 15,
                column: "Imagen",
                value: "");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 16,
                column: "Imagen",
                value: "");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 17,
                columns: new[] { "Imagen", "Nombre" },
                values: new object[] { "", "Bife Americano " });

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 18,
                column: "Imagen",
                value: "");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 19,
                column: "Imagen",
                value: "");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 20,
                column: "Imagen",
                value: "");
        }
    }
}
