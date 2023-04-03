using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormaEntrega",
                columns: table => new
                {
                    FormaEntregaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaEntrega", x => x.FormaEntregaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoMercaderia",
                columns: table => new
                {
                    TipoMercaderiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMercaderia", x => x.TipoMercaderiaId);
                });

            migrationBuilder.CreateTable(
                name: "Comanda",
                columns: table => new
                {
                    ComandaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormaEntregaId = table.Column<int>(type: "int", nullable: false),
                    PrecioTotal = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comanda", x => x.ComandaId);
                    table.ForeignKey(
                        name: "FK_Comanda_FormaEntrega_FormaEntregaId",
                        column: x => x.FormaEntregaId,
                        principalTable: "FormaEntrega",
                        principalColumn: "FormaEntregaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mercaderia",
                columns: table => new
                {
                    MercaderiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TipoMercaderiaId = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Ingredientes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Preparacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercaderia", x => x.MercaderiaId);
                    table.ForeignKey(
                        name: "FK_Mercaderia_TipoMercaderia_TipoMercaderiaId",
                        column: x => x.TipoMercaderiaId,
                        principalTable: "TipoMercaderia",
                        principalColumn: "TipoMercaderiaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComandaMercaderia",
                columns: table => new
                {
                    ComandaMercaderiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MercaderiaId = table.Column<int>(type: "int", nullable: false),
                    ComandaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComandaMercaderia", x => x.ComandaMercaderiaId);
                    table.ForeignKey(
                        name: "FK_ComandaMercaderia_Comanda_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comanda",
                        principalColumn: "ComandaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComandaMercaderia_Mercaderia_MercaderiaId",
                        column: x => x.MercaderiaId,
                        principalTable: "Mercaderia",
                        principalColumn: "MercaderiaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FormaEntrega",
                columns: new[] { "FormaEntregaId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Salon" },
                    { 2, "Delivery" },
                    { 3, "Pedidos Ya" }
                });

            migrationBuilder.InsertData(
                table: "TipoMercaderia",
                columns: new[] { "TipoMercaderiaId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Entrada" },
                    { 2, "Minutas" },
                    { 3, "Pastas" },
                    { 4, "Parrilla" },
                    { 5, "Pizzas" },
                    { 6, "Sandwich" },
                    { 7, "Ensaladas" },
                    { 8, "Bebidas" },
                    { 9, "Cerveza Artesanal" },
                    { 10, "Postres" }
                });

            migrationBuilder.InsertData(
                table: "Mercaderia",
                columns: new[] { "MercaderiaId", "Imagen", "Ingredientes", "Nombre", "Precio", "Preparacion", "TipoMercaderiaId" },
                values: new object[,]
                {
                    { 1, "", "500gr Bondiola de cerdo / 500gr Carne roast beef / 100gr Panceta salada / Mostaza / Condimentos a elección y sal / Cebolla morada tomates / Queso", "Hamburguesas de Carne y Cerdo", 2500, "P1: Picar las carnes en pedacitos y la panceta\nP2: Poner a procesar, mezclarlas bien.\nP3: Incorporar la mostaza y los condimentos más la sal, mezclar bien.\nP4: Preparar hamburguesas.\nP5: Cocinar y agregar el queso. A un lado puse las cebollas.", 6 },
                    { 2, "", "2 tazas soja texturizada en crudo / Agua / Puñado perejil / 1 cebolla mediana / 3 dientes ajo / Pedazo morrón rojo  / 6 cucharadas soperas harina integral/ 2 cucharadas soperas avena instantánea/ Harina para rebozar ", "Hamburguesas de soja VEGANAS", 2800, "P1: Remojar la soja por 20 minutos.\nP2: Picar ajo y cebolla, y cocinar con aceite de oliva. Añadir morron luego de estar dorados y cocinar 5 minutos mas.\nP3: Vamos a colar y sacar del remojo a la soja texturizada.", 6 },
                    { 3, "", "6 rapiditas/ 4 bifes de carne magra / 1 cebolla mediana / 1 cebolla morada mediana / Morrones (rojo, verde y amarillo) / 4dientes ajo / Poquito pimentón dulce/ Queso crema (opcional)", "Tacos de Carne", 4200, "P1: Saltear verduras en aceite de oliva.\nP2: Quitar la grasa a la carne, cortarla en cubos y saltearla con las verduras.\nP3: Cuando la carne ya esté lista condimentamos con el pimentón dulce y mezclamos muy bien.\nP4: Armar las tortillas.", 6 },
                    { 4, "", "Pechugas de pollo/ Mitad cebolla/ Ajo cantidad a gusto/ 1 cuarto morrón rojo/ 1 zanahoria/ 1 puñado Queso mozza rallado/ Sal,Pimienta y perejil a gusto/ Cebolla de verdeo a gusto/ 1 cucharada Mayonesa/ 1 cucharaditaMostaza/ Pan de hamburguesas", "Sandwich de pollo y verduras", 2200, "P1: Cocinar pechugas, agregar pimienta, sal y ajo.\nP2: Cortar la pechuga en cubos.\nP3: Agregar verduras y condimentos.\nP4: Armar sandwich.", 6 },
                    { 5, "", "1 calabaza mediana/ 2 huevos/ 100 gr queso rallado/ Hierbas secas o frescas a elección/ Orégano/ Romero/ Tomillo/ Albahaca/ Sal/ Aceite de oliva/ 12 tapas de empanadas chicas", "Canastitas de calabaza asada con finas hierbas", 4300, "P1: Asar la calabaza con aceite de oliva.\nP2: Agregar 2 huevos, queso rallado, sal y pimienta.\nP3: Armar canastitas y cocinar por 20 minutos.", 2 },
                    { 6, "", "1 kilo harina 000 / 1/2 taza aceite / 600 cc agua hirviendo / 10 hojas espinacas bien lavadas / 1 cucharada sal ", "Ñoquis soufflé de espinacas", 3100, "P1: Poner a calentar agua. Revolver la harina con sal en un bowl.\nP2: Mixear el aceite y las hojas de espinaca.\nP3: Mezclar lo mixeado con la harian y sal.\nP4: amasar la harina y la pasta de espinacas con el agua caliente.\n", 3 },
                    { 7, "", "200 g harina 0000 / 80 ml agua / 10 ml aceite de girasol / 7 g levadura seca / 30 ml salsa de tomate / 1 pizca sal, pimienta blanca, pizca orégano / 1 chorrito aceite de oliva / 75 g queso porsalut /1/2 tomate redondo un huevo/ 6 fetas jamón cocido", "Pizza de Jamon y morron", 2100, "", 5 },
                    { 8, "", "5 papás / 200 gr panceta / Queso cheddar / Crema de leche", "Papas con Cheddar y Panceta", 1900, "P1: Costamos las papas en bastón\nP2: Luego cortamos la panceta en tiras\nP3: Calentamos la plancha y cocinamos la panceta sin ninguna materia grasa. Una vez que está dorada ya está lista", 1 },
                    { 9, "", "Ron Havana 3 años, Menta, Limón, Almíbar, Soda", "MOJITO", 900, "P1: En un vaso agregar decorar con almibar y limon\nP2: Agregar el ron y Soda\nP3: Decorar con menta", 8 },
                    { 10, "", "Cachaza, Lima, Azúcar", "CAIPIRINHA", 900, "P1: Decorar el borde de un vaso con lima y azucar.\nP2: Agregar Cachaza hasta llenar y agregar jugo de Lima ", 8 },
                    { 11, "", "Campari, Agua tónica", "CAMPARI TONIC", 900, "P1: En una copa, agregar campari y agua tonica 30/70.", 8 },
                    { 12, "", "Gin Brighton, Campari, Carpano Rosso", "NEGRONI", 1000, "P1: Agregar en un vaso campari y Gin a gusto.\nP2: Salpicar el trago con Carpano Rosso", 8 },
                    { 13, "", "Gancia, Limón, Azúcar", "GANCIA BATIDO", 800, "P1: Agregar Gancia y jugo de limon en un vaso.\nP2: Batir y decorar con azucar.", 8 },
                    { 14, "", "Chorizo - Carne de vaca", "Chorizo", 500, "P1: Calentar la parrilla y cocinar el chorizo por 40 minutos a fuego lento.", 4 },
                    { 15, "", "Chinchulines de vaca", "Chinchulines", 700, "P1: Lavar los chinchulines y dejar en remojo en agua salada.\nP2: Cortar en rodajas\nP3: Cocinar a fuego lento por 60 minutos.", 4 },
                    { 16, "", "Asado de vaca", "Tira de Asado", 800, "P1: Calentar la parrilla por 20 minutos.\nP2: Poner la tira de asado a fuego lento sobre la parrilla para su cocción.\nP3: Cocinar por 90 minutos.", 4 },
                    { 17, "", "Bife Americano de Vaca", "Bife Americano ", 1200, "P1: Calentar la parrilla por 20 minutos.\nP2: Poner el bife americano a fuego lento sobre la parrilla para su cocción.\nP3: Cocinar por 75 minutos.", 4 },
                    { 18, "", "Helado de Vainilla / Dulce de leche , Crema dulce, obleas Opera", "Helado en copa", 1800, "P1: En una copa servir  bochas de helado de cada gusto.\nP2: Decorar con crema y una oblea de galleta Opera", 10 },
                    { 19, "", "80gr de azucar, 700cc de leche, 1 pote de leche condensada, 10 huevos, esencia de vainilla", "Flan casero", 900, "P1: Poner los 10 huevos en un bol y agregar el azucar con el pote de leche condensada y esencia de vainilla.\nP2: Mezclar hasta integrar todo.\nP3: Meter al horno por 90 minutos a baño maria", 10 },
                    { 20, "", "400gr de pan, 1 litro de leche, 425g de azucar, 6 huevos, esencia de vainilla", "Budin de Pan", 850, "P1: Cortar el pan en trozos y dejarlos en remojo con leche.\nP2: Licuar la mezcla y agregar la esencia con el azucar y los huevos.\nP3: Cocinar a fuego lento en el horno a baño maria por 90 minutos.", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comanda_FormaEntregaId",
                table: "Comanda",
                column: "FormaEntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_ComandaMercaderia_ComandaId",
                table: "ComandaMercaderia",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_ComandaMercaderia_MercaderiaId",
                table: "ComandaMercaderia",
                column: "MercaderiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercaderia_TipoMercaderiaId",
                table: "Mercaderia",
                column: "TipoMercaderiaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComandaMercaderia");

            migrationBuilder.DropTable(
                name: "Comanda");

            migrationBuilder.DropTable(
                name: "Mercaderia");

            migrationBuilder.DropTable(
                name: "FormaEntrega");

            migrationBuilder.DropTable(
                name: "TipoMercaderia");
        }
    }
}
