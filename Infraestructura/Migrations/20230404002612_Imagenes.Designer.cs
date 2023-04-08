﻿// <auto-generated />
using System;
using Infraestructura;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructura.Migrations
{
    [DbContext(typeof(RestoDbContext))]
    [Migration("20230404002612_Imagenes")]
    partial class Imagenes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Dominio.Entidades.Comanda", b =>
                {
                    b.Property<Guid>("ComandaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("date");

                    b.Property<int>("FormaEntregaId")
                        .HasColumnType("int");

                    b.Property<int>("PrecioTotal")
                        .HasColumnType("int");

                    b.HasKey("ComandaId");

                    b.HasIndex("FormaEntregaId");

                    b.ToTable("Comanda");
                });

            modelBuilder.Entity("Dominio.Entidades.ComandaMercaderia", b =>
                {
                    b.Property<int>("ComandaMercaderiaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComandaMercaderiaId"));

                    b.Property<Guid>("ComandaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MercaderiaId")
                        .HasColumnType("int");

                    b.HasKey("ComandaMercaderiaId");

                    b.HasIndex("ComandaId");

                    b.HasIndex("MercaderiaId");

                    b.ToTable("ComandaMercaderia");
                });

            modelBuilder.Entity("Dominio.Entidades.FormaEntrega", b =>
                {
                    b.Property<int>("FormaEntregaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FormaEntregaId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("FormaEntregaId");

                    b.ToTable("FormaEntrega");

                    b.HasData(
                        new
                        {
                            FormaEntregaId = 1,
                            Descripcion = "Salon"
                        },
                        new
                        {
                            FormaEntregaId = 2,
                            Descripcion = "Delivery"
                        },
                        new
                        {
                            FormaEntregaId = 3,
                            Descripcion = "Pedidos Ya"
                        });
                });

            modelBuilder.Entity("Dominio.Entidades.Mercaderia", b =>
                {
                    b.Property<int>("MercaderiaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MercaderiaId"));

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Ingredientes")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.Property<string>("Preparacion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("TipoMercaderiaId")
                        .HasColumnType("int");

                    b.HasKey("MercaderiaId");

                    b.HasIndex("TipoMercaderiaId");

                    b.ToTable("Mercaderia");

                    b.HasData(
                        new
                        {
                            MercaderiaId = 1,
                            Imagen = "https://drive.google.com/file/d/1xPKcmbPTsvVBwaNx37xEzp6gtbfT1WtJ/view",
                            Ingredientes = "500gr Bondiola de cerdo / 500gr Carne roast beef / 100gr Panceta salada / Mostaza / Condimentos a elección y sal / Cebolla morada tomates / Queso",
                            Nombre = "Hamburguesas de Carne y Cerdo",
                            Precio = 2500,
                            Preparacion = "P1: Picar las carnes en pedacitos y la panceta\nP2: Poner a procesar, mezclarlas bien.\nP3: Incorporar la mostaza y los condimentos más la sal, mezclar bien.\nP4: Preparar hamburguesas.\nP5: Cocinar y agregar el queso. A un lado puse las cebollas.",
                            TipoMercaderiaId = 6
                        },
                        new
                        {
                            MercaderiaId = 2,
                            Imagen = "https://drive.google.com/file/d/1E91-s9vzk17FGJGSVIyqGVH5kVTeQzb9/view",
                            Ingredientes = "2 tazas soja texturizada en crudo / Agua / Puñado perejil / 1 cebolla mediana / 3 dientes ajo / Pedazo morrón rojo  / 6 cucharadas soperas harina integral/ 2 cucharadas soperas avena instantánea/ Harina para rebozar ",
                            Nombre = "Hamburguesas de soja VEGANAS",
                            Precio = 2800,
                            Preparacion = "P1: Remojar la soja por 20 minutos.\nP2: Picar ajo y cebolla, y cocinar con aceite de oliva. Añadir morron luego de estar dorados y cocinar 5 minutos mas.\nP3: Vamos a colar y sacar del remojo a la soja texturizada.",
                            TipoMercaderiaId = 6
                        },
                        new
                        {
                            MercaderiaId = 3,
                            Imagen = "https://drive.google.com/file/d/1kL9nMYb3wTNWri2N099LhZoYoJp1btXP/view",
                            Ingredientes = "6 rapiditas/ 4 bifes de carne magra / 1 cebolla mediana / 1 cebolla morada mediana / Morrones (rojo, verde y amarillo) / 4dientes ajo / Poquito pimentón dulce/ Queso crema (opcional)",
                            Nombre = "Tacos de Carne",
                            Precio = 4200,
                            Preparacion = "P1: Saltear verduras en aceite de oliva.\nP2: Quitar la grasa a la carne, cortarla en cubos y saltearla con las verduras.\nP3: Cuando la carne ya esté lista condimentamos con el pimentón dulce y mezclamos muy bien.\nP4: Armar las tortillas.",
                            TipoMercaderiaId = 6
                        },
                        new
                        {
                            MercaderiaId = 4,
                            Imagen = "https://drive.google.com/file/d/1tSMAO2-yZoDM3z3O4QkNzj25FLj-ovqp/view",
                            Ingredientes = "Pechugas de pollo/ Mitad cebolla/ Ajo cantidad a gusto/ 1 cuarto morrón rojo/ 1 zanahoria/ 1 puñado Queso mozza rallado/ Sal,Pimienta y perejil a gusto/ Cebolla de verdeo a gusto/ 1 cucharada Mayonesa/ 1 cucharaditaMostaza/ Pan de hamburguesas",
                            Nombre = "Sandwich de pollo y verduras",
                            Precio = 2200,
                            Preparacion = "P1: Cocinar pechugas, agregar pimienta, sal y ajo.\nP2: Cortar la pechuga en cubos.\nP3: Agregar verduras y condimentos.\nP4: Armar sandwich.",
                            TipoMercaderiaId = 6
                        },
                        new
                        {
                            MercaderiaId = 5,
                            Imagen = "https://drive.google.com/file/d/1ZsYM1Y84JPPyznF3OmV8km5AJqxIr-Lh/view",
                            Ingredientes = "1 calabaza mediana/ 2 huevos/ 100 gr queso rallado/ Hierbas secas o frescas a elección/ Orégano/ Romero/ Tomillo/ Albahaca/ Sal/ Aceite de oliva/ 12 tapas de empanadas chicas",
                            Nombre = "Canastitas de calabaza asada con finas hierbas",
                            Precio = 4300,
                            Preparacion = "P1: Asar la calabaza con aceite de oliva.\nP2: Agregar 2 huevos, queso rallado, sal y pimienta.\nP3: Armar canastitas y cocinar por 20 minutos.",
                            TipoMercaderiaId = 2
                        },
                        new
                        {
                            MercaderiaId = 6,
                            Imagen = "https://drive.google.com/file/d/1daQZfHgmK-P_1qd_qn_Odk766IkoI3Al/view",
                            Ingredientes = "1 kilo harina 000 / 1/2 taza aceite / 600 cc agua hirviendo / 10 hojas espinacas bien lavadas / 1 cucharada sal ",
                            Nombre = "Ñoquis soufflé de espinacas",
                            Precio = 3100,
                            Preparacion = "P1: Poner a calentar agua. Revolver la harina con sal en un bowl.\nP2: Mixear el aceite y las hojas de espinaca.\nP3: Mezclar lo mixeado con la harian y sal.\nP4: amasar la harina y la pasta de espinacas con el agua caliente.\n",
                            TipoMercaderiaId = 3
                        },
                        new
                        {
                            MercaderiaId = 7,
                            Imagen = "https://drive.google.com/file/d/1g1yLG9S4vDO5WVKoTGcXjByr21UbUZ4K/view",
                            Ingredientes = "200 g harina 0000 / 80 ml agua / 10 ml aceite de girasol / 7 g levadura seca / 30 ml salsa de tomate / 1 pizca sal, pimienta blanca, pizca orégano / 1 chorrito aceite de oliva / 75 g queso porsalut /1/2 tomate redondo un huevo/ 6 fetas jamón cocido",
                            Nombre = "Pizza de Jamon y morron",
                            Precio = 2100,
                            Preparacion = "P1: Hacer un volcan con la harina,agregar la levadura e integrar.\nP2: Ir agregando el agua con el aceite y amasar.\nP3: Estirar en forma de pizza, agregar la salsa y condimentos.\nP4: Cocinar agregarndo los quesos encima de la masa.",
                            TipoMercaderiaId = 5
                        },
                        new
                        {
                            MercaderiaId = 8,
                            Imagen = "https://drive.google.com/file/d/1wSuSxZfzGAOYLujShTfxaYhWK0R0EPt5/view",
                            Ingredientes = "5 papás / 200 gr panceta / Queso cheddar / Crema de leche",
                            Nombre = "Papas con Cheddar y Panceta",
                            Precio = 1900,
                            Preparacion = "P1: Costamos las papas en bastón\nP2: Luego cortamos la panceta en tiras\nP3: Calentamos la plancha y cocinamos la panceta sin ninguna materia grasa. Una vez que está dorada ya está lista",
                            TipoMercaderiaId = 1
                        },
                        new
                        {
                            MercaderiaId = 9,
                            Imagen = "https://drive.google.com/file/d/1Gzg_rCtYUffWPqRYRuKVTH9MS4zEsayC/view",
                            Ingredientes = "Ron Havana 3 años, Menta, Limón, Almíbar, Soda",
                            Nombre = "MOJITO",
                            Precio = 900,
                            Preparacion = "P1: En un vaso agregar decorar con almibar y limon\nP2: Agregar el ron y Soda\nP3: Decorar con menta",
                            TipoMercaderiaId = 8
                        },
                        new
                        {
                            MercaderiaId = 10,
                            Imagen = "https://drive.google.com/file/d/1PCI5E0wW1ZpTCi8n5gzu93S3op_dXfE0/view",
                            Ingredientes = "Cachaza, Lima, Azúcar",
                            Nombre = "CAIPIRINHA",
                            Precio = 900,
                            Preparacion = "P1: Decorar el borde de un vaso con lima y azucar.\nP2: Agregar Cachaza hasta llenar y agregar jugo de Lima ",
                            TipoMercaderiaId = 8
                        },
                        new
                        {
                            MercaderiaId = 11,
                            Imagen = "https://drive.google.com/file/d/1SmWW3AYClTQjWSrcFtx6igYroIjiGmRa/view",
                            Ingredientes = "Campari, Agua tónica",
                            Nombre = "CAMPARI TONIC",
                            Precio = 900,
                            Preparacion = "P1: En una copa, agregar campari y agua tonica 30/70.",
                            TipoMercaderiaId = 8
                        },
                        new
                        {
                            MercaderiaId = 12,
                            Imagen = "https://drive.google.com/file/d/1X6FHcKRVqgIO9SpY0Wb4-jDdspCLfgyj/view",
                            Ingredientes = "Gin Brighton, Campari, Carpano Rosso",
                            Nombre = "NEGRONI",
                            Precio = 1000,
                            Preparacion = "P1: Agregar en un vaso campari y Gin a gusto.\nP2: Salpicar el trago con Carpano Rosso",
                            TipoMercaderiaId = 8
                        },
                        new
                        {
                            MercaderiaId = 13,
                            Imagen = "https://drive.google.com/file/d/1jjtoaOMDfmhtxlJIgCGtzmTV8Z-mGxCc/view",
                            Ingredientes = "Gancia, Limón, Azúcar",
                            Nombre = "GANCIA BATIDO",
                            Precio = 800,
                            Preparacion = "P1: Agregar Gancia y jugo de limon en un vaso.\nP2: Batir y decorar con azucar.",
                            TipoMercaderiaId = 8
                        },
                        new
                        {
                            MercaderiaId = 14,
                            Imagen = "https://drive.google.com/file/d/1UhYg6vNMURHFWhJnbwevTPEHH8uBXbmE/view",
                            Ingredientes = "Chorizo - Carne de vaca",
                            Nombre = "Chorizo",
                            Precio = 500,
                            Preparacion = "P1: Calentar la parrilla y cocinar el chorizo por 40 minutos a fuego lento.",
                            TipoMercaderiaId = 4
                        },
                        new
                        {
                            MercaderiaId = 15,
                            Imagen = "https://drive.google.com/file/d/1K5Q9JrEa1lRHSH23gDM0ZR2HCFWaBRv6/view",
                            Ingredientes = "Chinchulines de vaca",
                            Nombre = "Chinchulines",
                            Precio = 700,
                            Preparacion = "P1: Lavar los chinchulines y dejar en remojo en agua salada.\nP2: Cortar en rodajas\nP3: Cocinar a fuego lento por 60 minutos.",
                            TipoMercaderiaId = 4
                        },
                        new
                        {
                            MercaderiaId = 16,
                            Imagen = "https://drive.google.com/file/d/1rGKWzKEpi2JInh7v6ht3i8mlTOPh96sl/view",
                            Ingredientes = "Asado de vaca",
                            Nombre = "Tira de Asado",
                            Precio = 800,
                            Preparacion = "P1: Calentar la parrilla por 20 minutos.\nP2: Poner la tira de asado a fuego lento sobre la parrilla para su cocción.\nP3: Cocinar por 90 minutos.",
                            TipoMercaderiaId = 4
                        },
                        new
                        {
                            MercaderiaId = 17,
                            Imagen = "https://drive.google.com/file/d/13TRC10uTERzdzHUzKYXkf-4PKjfTngLK/view",
                            Ingredientes = "Bife Americano de Vaca",
                            Nombre = "Bife Americano",
                            Precio = 1200,
                            Preparacion = "P1: Calentar la parrilla por 20 minutos.\nP2: Poner el bife americano a fuego lento sobre la parrilla para su cocción.\nP3: Cocinar por 75 minutos.",
                            TipoMercaderiaId = 4
                        },
                        new
                        {
                            MercaderiaId = 18,
                            Imagen = "https://drive.google.com/file/d/1nXp9l_8pvU3VGgL7VSZF49n7ym4_0Br5/view",
                            Ingredientes = "Helado de Vainilla / Dulce de leche , Crema dulce, obleas Opera",
                            Nombre = "Helado en copa",
                            Precio = 1800,
                            Preparacion = "P1: En una copa servir  bochas de helado de cada gusto.\nP2: Decorar con crema y una oblea de galleta Opera",
                            TipoMercaderiaId = 10
                        },
                        new
                        {
                            MercaderiaId = 19,
                            Imagen = "https://drive.google.com/file/d/1lD0i_VwhuPpYXEvrNvCxpPVwQTNP1YUe/view",
                            Ingredientes = "80gr de azucar, 700cc de leche, 1 pote de leche condensada, 10 huevos, esencia de vainilla",
                            Nombre = "Flan casero",
                            Precio = 900,
                            Preparacion = "P1: Poner los 10 huevos en un bol y agregar el azucar con el pote de leche condensada y esencia de vainilla.\nP2: Mezclar hasta integrar todo.\nP3: Meter al horno por 90 minutos a baño maria",
                            TipoMercaderiaId = 10
                        },
                        new
                        {
                            MercaderiaId = 20,
                            Imagen = "https://drive.google.com/file/d/1Gzlx8q0NKQLfUEILZKFxsD6xoqDX17gF/view",
                            Ingredientes = "400gr de pan, 1 litro de leche, 425g de azucar, 6 huevos, esencia de vainilla",
                            Nombre = "Budin de Pan",
                            Precio = 850,
                            Preparacion = "P1: Cortar el pan en trozos y dejarlos en remojo con leche.\nP2: Licuar la mezcla y agregar la esencia con el azucar y los huevos.\nP3: Cocinar a fuego lento en el horno a baño maria por 90 minutos.",
                            TipoMercaderiaId = 10
                        });
                });

            modelBuilder.Entity("Dominio.Entidades.TipoMercaderia", b =>
                {
                    b.Property<int>("TipoMercaderiaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoMercaderiaId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TipoMercaderiaId");

                    b.ToTable("TipoMercaderia");

                    b.HasData(
                        new
                        {
                            TipoMercaderiaId = 1,
                            Descripcion = "Entrada"
                        },
                        new
                        {
                            TipoMercaderiaId = 2,
                            Descripcion = "Minutas"
                        },
                        new
                        {
                            TipoMercaderiaId = 3,
                            Descripcion = "Pastas"
                        },
                        new
                        {
                            TipoMercaderiaId = 4,
                            Descripcion = "Parrilla"
                        },
                        new
                        {
                            TipoMercaderiaId = 5,
                            Descripcion = "Pizzas"
                        },
                        new
                        {
                            TipoMercaderiaId = 6,
                            Descripcion = "Sandwich"
                        },
                        new
                        {
                            TipoMercaderiaId = 7,
                            Descripcion = "Ensaladas"
                        },
                        new
                        {
                            TipoMercaderiaId = 8,
                            Descripcion = "Bebidas"
                        },
                        new
                        {
                            TipoMercaderiaId = 9,
                            Descripcion = "Cerveza Artesanal"
                        },
                        new
                        {
                            TipoMercaderiaId = 10,
                            Descripcion = "Postres"
                        });
                });

            modelBuilder.Entity("Dominio.Entidades.Comanda", b =>
                {
                    b.HasOne("Dominio.Entidades.FormaEntrega", "FKFormaEntrega")
                        .WithMany("LsComanda")
                        .HasForeignKey("FormaEntregaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FKFormaEntrega");
                });

            modelBuilder.Entity("Dominio.Entidades.ComandaMercaderia", b =>
                {
                    b.HasOne("Dominio.Entidades.Comanda", "FKComanda")
                        .WithMany("LsComandaMercaderia")
                        .HasForeignKey("ComandaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Mercaderia", "FKMercaderia")
                        .WithMany("LsComandaMercaderia")
                        .HasForeignKey("MercaderiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FKComanda");

                    b.Navigation("FKMercaderia");
                });

            modelBuilder.Entity("Dominio.Entidades.Mercaderia", b =>
                {
                    b.HasOne("Dominio.Entidades.TipoMercaderia", "FKTipoMercaderia")
                        .WithMany("LsMercaderia")
                        .HasForeignKey("TipoMercaderiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FKTipoMercaderia");
                });

            modelBuilder.Entity("Dominio.Entidades.Comanda", b =>
                {
                    b.Navigation("LsComandaMercaderia");
                });

            modelBuilder.Entity("Dominio.Entidades.FormaEntrega", b =>
                {
                    b.Navigation("LsComanda");
                });

            modelBuilder.Entity("Dominio.Entidades.Mercaderia", b =>
                {
                    b.Navigation("LsComandaMercaderia");
                });

            modelBuilder.Entity("Dominio.Entidades.TipoMercaderia", b =>
                {
                    b.Navigation("LsMercaderia");
                });
#pragma warning restore 612, 618
        }
    }
}
