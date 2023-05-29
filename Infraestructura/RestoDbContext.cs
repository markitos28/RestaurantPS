using Microsoft.EntityFrameworkCore;
using Dominio.Entidades;

namespace Infraestructura
{
    public class RestoDbContext: DbContext
    {
        public DbSet<Comanda> Comanda { get; set; }
        public DbSet<ComandaMercaderia> ComandaMercaderia { get; set; }
        public DbSet<FormaEntrega> FormaEntrega { get; set; }
        public DbSet<Mercaderia> Mercaderia { get; set; }
        public DbSet<TipoMercaderia> TipoMercaderia { get; set; }

        public RestoDbContext(DbContextOptions<RestoDbContext> options) : base(options)
        {

        }

        public RestoDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comanda>(entity =>
            {
                entity.HasKey(s => s.ComandaId);
                entity.Property(s => s.ComandaId).ValueGeneratedOnAdd();
                entity.HasOne<FormaEntrega>(o => o.FKFormaEntrega).WithMany(m => m.LsComanda).HasForeignKey(f => f.FormaEntregaId);
                entity.HasMany<ComandaMercaderia>(m => m.LsComandaMercaderia).WithOne(o => o.FKComanda);
                entity.Property(s => s.FormaEntregaId).IsRequired();
                entity.Property(s => s.PrecioTotal).IsRequired();
                entity.Property(s => s.Fecha).IsRequired().HasColumnType("date");
            });

            modelBuilder.Entity<FormaEntrega>(entity => 
            {
                entity.HasKey(k => k.FormaEntregaId);
                entity.HasMany<Comanda>(m => m.LsComanda).WithOne(o => o.FKFormaEntrega);
                entity.Property(s => s.Descripcion).HasMaxLength(50);

                entity.HasData(new FormaEntrega
                {
                    FormaEntregaId = 1,
                    Descripcion= "Salon"

                });

                entity.HasData(new FormaEntrega
                {
                    FormaEntregaId = 2,
                    Descripcion = "Delivery"

                });

                entity.HasData(new FormaEntrega
                {
                    FormaEntregaId = 3,
                    Descripcion = "Pedidos Ya"

                });


            });

            modelBuilder.Entity<ComandaMercaderia>(entity =>
            {
                entity.HasKey(k => k.ComandaMercaderiaId);
                entity.HasOne<Comanda>(o => o.FKComanda).WithMany(m => m.LsComandaMercaderia).HasForeignKey(f => f.ComandaId);
                entity.HasOne<Mercaderia>(o => o.FKMercaderia).WithMany(m => m.LsComandaMercaderia).HasForeignKey(f => f.MercaderiaId);
                entity.Property(s => s.ComandaId).IsRequired();
                entity.Property(s => s.MercaderiaId).IsRequired();
            });

            modelBuilder.Entity<Mercaderia>(entity =>
            {
                entity.HasKey(k => k.MercaderiaId);
                entity.HasMany<ComandaMercaderia>(o => o.LsComandaMercaderia).WithOne(o => o.FKMercaderia);
                entity.HasOne<TipoMercaderia>(o => o.FKTipoMercaderia).WithMany(m => m.LsMercaderia).HasForeignKey(f => f.TipoMercaderiaId);
                entity.Property(s => s.Nombre).IsRequired();
                entity.Property(s => s.Nombre).HasMaxLength(50);
                entity.Property(s => s.TipoMercaderiaId).IsRequired();
                entity.Property(s => s.Precio).IsRequired();
                entity.Property(s => s.Ingredientes).IsRequired();
                entity.Property(s => s.Ingredientes).HasMaxLength(255);
                entity.Property(s => s.Preparacion).IsRequired();
                entity.Property(s => s.Preparacion).HasMaxLength(255);
                entity.Property(s => s.Imagen).IsRequired();
                entity.Property(s => s.Imagen).HasMaxLength(255);

                entity.HasData(new Mercaderia
                {
                    MercaderiaId=1,
                    Nombre= "Hamburguesas de Carne y Cerdo",
                    TipoMercaderiaId= 6,
                    Precio = 2500,
                    Ingredientes = "500gr Bondiola de cerdo / 500gr Carne roast beef / 100gr Panceta salada / Mostaza / Condimentos a elección y sal / Cebolla morada tomates / Queso",
                    Preparacion = "P1: Picar las carnes en pedacitos y la panceta\nP2: Poner a procesar, mezclarlas bien.\nP3: Incorporar la mostaza y los condimentos más la sal, mezclar bien.\nP4: Preparar hamburguesas.\nP5: Cocinar y agregar el queso. A un lado puse las cebollas.",
                    Imagen = "https://drive.google.com/file/d/1xPKcmbPTsvVBwaNx37xEzp6gtbfT1WtJ/view"
                });
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 2,
                    Nombre = "Hamburguesas de soja VEGANAS",
                    TipoMercaderiaId = 6,
                    Precio = 2800,
                    Ingredientes = "2 tazas soja texturizada en crudo / Agua / Puñado perejil / 1 cebolla mediana / 3 dientes ajo / Pedazo morrón rojo  / 6 cucharadas soperas harina integral/ 2 cucharadas soperas avena instantánea/ Harina para rebozar ",
                    Preparacion = "P1: Remojar la soja por 20 minutos.\nP2: Picar ajo y cebolla, y cocinar con aceite de oliva. Añadir morron luego de estar dorados y cocinar 5 minutos mas.\nP3: Vamos a colar y sacar del remojo a la soja texturizada.",
                    Imagen = "https://drive.google.com/file/d/1E91-s9vzk17FGJGSVIyqGVH5kVTeQzb9/view"
                });
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 3,
                    Nombre = "Tacos de Carne",
                    TipoMercaderiaId = 6,
                    Precio = 4200,
                    Ingredientes = "6 rapiditas/ 4 bifes de carne magra / 1 cebolla mediana / 1 cebolla morada mediana / Morrones (rojo, verde y amarillo) / 4dientes ajo / Poquito pimentón dulce/ Queso crema (opcional)",
                    Preparacion = "P1: Saltear verduras en aceite de oliva.\nP2: Quitar la grasa a la carne, cortarla en cubos y saltearla con las verduras.\nP3: Cuando la carne ya esté lista condimentamos con el pimentón dulce y mezclamos muy bien.\nP4: Armar las tortillas.",
                    Imagen = "https://drive.google.com/file/d/1kL9nMYb3wTNWri2N099LhZoYoJp1btXP/view"
                });
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 4,
                    Nombre = "Sandwich de pollo y verduras",
                    TipoMercaderiaId = 6,
                    Precio = 2200,
                    Ingredientes = "Pechugas de pollo/ Mitad cebolla/ Ajo cantidad a gusto/ 1 cuarto morrón rojo/ 1 zanahoria/ 1 puñado Queso mozza rallado/ Sal,Pimienta y perejil a gusto/ Cebolla de verdeo a gusto/ 1 cucharada Mayonesa/ 1 cucharaditaMostaza/ Pan de hamburguesas",
                    Preparacion = "P1: Cocinar pechugas, agregar pimienta, sal y ajo.\nP2: Cortar la pechuga en cubos.\nP3: Agregar verduras y condimentos.\nP4: Armar sandwich.",
                    Imagen = "https://drive.google.com/file/d/1tSMAO2-yZoDM3z3O4QkNzj25FLj-ovqp/view"
                });
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 5,
                    Nombre = "Canastitas de calabaza asada con finas hierbas",
                    TipoMercaderiaId = 2,
                    Precio = 4300,
                    Ingredientes = "1 calabaza mediana/ 2 huevos/ 100 gr queso rallado/ Hierbas secas o frescas a elección/ Orégano/ Romero/ Tomillo/ Albahaca/ Sal/ Aceite de oliva/ 12 tapas de empanadas chicas",
                    Preparacion = "P1: Asar la calabaza con aceite de oliva.\nP2: Agregar 2 huevos, queso rallado, sal y pimienta.\nP3: Armar canastitas y cocinar por 20 minutos.",
                    Imagen = "https://drive.google.com/file/d/1ZsYM1Y84JPPyznF3OmV8km5AJqxIr-Lh/view"
                });
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 6,
                    Nombre = "Ñoquis soufflé de espinacas",
                    TipoMercaderiaId = 3,
                    Precio = 3100,
                    Ingredientes = "1 kilo harina 000 / 1/2 taza aceite / 600 cc agua hirviendo / 10 hojas espinacas bien lavadas / 1 cucharada sal ",
                    Preparacion = "P1: Poner a calentar agua. Revolver la harina con sal en un bowl.\nP2: Mixear el aceite y las hojas de espinaca.\nP3: Mezclar lo mixeado con la harian y sal.\nP4: amasar la harina y la pasta de espinacas con el agua caliente.\n",
                    Imagen = "https://drive.google.com/file/d/1daQZfHgmK-P_1qd_qn_Odk766IkoI3Al/view"
                });
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 7,
                    Nombre = "Pizza de Jamon y morron",
                    TipoMercaderiaId = 5,
                    Precio = 2100,
                    Ingredientes = "200 g harina 0000 / 80 ml agua / 10 ml aceite de girasol / 7 g levadura seca / 30 ml salsa de tomate / 1 pizca sal, pimienta blanca, pizca orégano / 1 chorrito aceite de oliva / 75 g queso porsalut /1/2 tomate redondo un huevo/ 6 fetas jamón cocido",
                    Preparacion = "P1: Hacer un volcan con la harina,agregar la levadura e integrar.\nP2: Ir agregando el agua con el aceite y amasar.\nP3: Estirar en forma de pizza, agregar la salsa y condimentos.\nP4: Cocinar agregarndo los quesos encima de la masa.",
                    Imagen = "https://drive.google.com/file/d/1g1yLG9S4vDO5WVKoTGcXjByr21UbUZ4K/view"
                });
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 8,
                    Nombre = "Papas con Cheddar y Panceta",
                    TipoMercaderiaId = 1,
                    Precio = 1900,
                    Ingredientes = "5 papás / 200 gr panceta / Queso cheddar / Crema de leche",
                    Preparacion = "P1: Costamos las papas en bastón\nP2: Luego cortamos la panceta en tiras\nP3: Calentamos la plancha y cocinamos la panceta sin ninguna materia grasa. Una vez que está dorada ya está lista",
                    Imagen = "https://drive.google.com/file/d/1wSuSxZfzGAOYLujShTfxaYhWK0R0EPt5/view"
                });
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 9,
                    Nombre = "MOJITO",
                    TipoMercaderiaId = 8,
                    Precio = 900 ,
                    Ingredientes = "Ron Havana 3 años, Menta, Limón, Almíbar, Soda",
                    Preparacion = "P1: En un vaso agregar decorar con almibar y limon\nP2: Agregar el ron y Soda\nP3: Decorar con menta",
                    Imagen = "https://drive.google.com/file/d/1Gzg_rCtYUffWPqRYRuKVTH9MS4zEsayC/view"
                });
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 10,
                    Nombre = "CAIPIRINHA",
                    TipoMercaderiaId = 8,
                    Precio = 900,
                    Ingredientes = "Cachaza, Lima, Azúcar",
                    Preparacion = "P1: Decorar el borde de un vaso con lima y azucar.\nP2: Agregar Cachaza hasta llenar y agregar jugo de Lima ",
                    Imagen = "https://drive.google.com/file/d/1PCI5E0wW1ZpTCi8n5gzu93S3op_dXfE0/view"
                });
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 11,
                    Nombre = "CAMPARI TONIC",
                    TipoMercaderiaId = 8,
                    Precio = 900,
                    Ingredientes = "Campari, Agua tónica",
                    Preparacion = "P1: En una copa, agregar campari y agua tonica 30/70.",
                    Imagen = "https://drive.google.com/file/d/1SmWW3AYClTQjWSrcFtx6igYroIjiGmRa/view"
                });
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 12,
                    Nombre = "NEGRONI",
                    TipoMercaderiaId = 8,
                    Precio = 1000,
                    Ingredientes = "Gin Brighton, Campari, Carpano Rosso",
                    Preparacion = "P1: Agregar en un vaso campari y Gin a gusto.\nP2: Salpicar el trago con Carpano Rosso",
                    Imagen = "https://drive.google.com/file/d/1X6FHcKRVqgIO9SpY0Wb4-jDdspCLfgyj/view"
                });
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 13,
                    Nombre = "GANCIA BATIDO",
                    TipoMercaderiaId = 8,
                    Precio = 800 ,
                    Ingredientes = "Gancia, Limón, Azúcar",
                    Preparacion = "P1: Agregar Gancia y jugo de limon en un vaso.\nP2: Batir y decorar con azucar.",
                    Imagen = "https://drive.google.com/file/d/1jjtoaOMDfmhtxlJIgCGtzmTV8Z-mGxCc/view"
                });
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 14,
                    Nombre = "Chorizo",
                    TipoMercaderiaId = 4,
                    Precio = 500,
                    Ingredientes = "Chorizo - Carne de vaca",
                    Preparacion = "P1: Calentar la parrilla y cocinar el chorizo por 40 minutos a fuego lento.",
                    Imagen = "https://drive.google.com/file/d/1UhYg6vNMURHFWhJnbwevTPEHH8uBXbmE/view"
                });
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 15,
                    Nombre = "Chinchulines",
                    TipoMercaderiaId = 4,
                    Precio = 700,
                    Ingredientes = "Chinchulines de vaca",
                    Preparacion = "P1: Lavar los chinchulines y dejar en remojo en agua salada.\nP2: Cortar en rodajas\nP3: Cocinar a fuego lento por 60 minutos.",
                    Imagen = "https://drive.google.com/file/d/1K5Q9JrEa1lRHSH23gDM0ZR2HCFWaBRv6/view"
                });
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 16,
                    Nombre = "Tira de Asado",
                    TipoMercaderiaId = 4,
                    Precio = 800,
                    Ingredientes = "Asado de vaca",
                    Preparacion = "P1: Calentar la parrilla por 20 minutos.\nP2: Poner la tira de asado a fuego lento sobre la parrilla para su cocción.\nP3: Cocinar por 90 minutos.",
                    Imagen = "https://drive.google.com/file/d/1rGKWzKEpi2JInh7v6ht3i8mlTOPh96sl/view"
                });
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 17,
                    Nombre = "Bife Americano",
                    TipoMercaderiaId = 4,
                    Precio = 1200,
                    Ingredientes = "Bife Americano de Vaca",
                    Preparacion = "P1: Calentar la parrilla por 20 minutos.\nP2: Poner el bife americano a fuego lento sobre la parrilla para su cocción.\nP3: Cocinar por 75 minutos.",
                    Imagen = "https://drive.google.com/file/d/13TRC10uTERzdzHUzKYXkf-4PKjfTngLK/view"
                });
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 18,
                    Nombre = "Helado en copa",
                    TipoMercaderiaId = 10,
                    Precio = 1800,
                    Ingredientes = "Helado de Vainilla / Dulce de leche , Crema dulce, obleas Opera",
                    Preparacion = "P1: En una copa servir  bochas de helado de cada gusto.\nP2: Decorar con crema y una oblea de galleta Opera",
                    Imagen = "https://drive.google.com/file/d/1nXp9l_8pvU3VGgL7VSZF49n7ym4_0Br5/view"
                });
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 19,
                    Nombre = "Flan casero",
                    TipoMercaderiaId = 10,
                    Precio = 900,
                    Ingredientes = "80gr de azucar, 700cc de leche, 1 pote de leche condensada, 10 huevos, esencia de vainilla",
                    Preparacion = "P1: Poner los 10 huevos en un bol y agregar el azucar con el pote de leche condensada y esencia de vainilla.\nP2: Mezclar hasta integrar todo.\nP3: Meter al horno por 90 minutos a baño maria",
                    Imagen = "https://drive.google.com/file/d/1lD0i_VwhuPpYXEvrNvCxpPVwQTNP1YUe/view"
                });
                entity.HasData(new Mercaderia
                {
                    MercaderiaId = 20,
                    Nombre = "Budin de Pan",
                    TipoMercaderiaId = 10,
                    Precio = 850,
                    Ingredientes = "400gr de pan, 1 litro de leche, 425g de azucar, 6 huevos, esencia de vainilla",
                    Preparacion = "P1: Cortar el pan en trozos y dejarlos en remojo con leche.\nP2: Licuar la mezcla y agregar la esencia con el azucar y los huevos.\nP3: Cocinar a fuego lento en el horno a baño maria por 90 minutos.",
                    Imagen = "https://drive.google.com/file/d/1Gzlx8q0NKQLfUEILZKFxsD6xoqDX17gF/view"
                });
                
            });

            modelBuilder.Entity<TipoMercaderia>(entity =>
            {
                entity.HasKey(k => k.TipoMercaderiaId);
                entity.HasMany<Mercaderia>(m => m.LsMercaderia).WithOne(o => o.FKTipoMercaderia);
                entity.Property(s => s.Descripcion).IsRequired();
                entity.Property(s => s.Descripcion).HasMaxLength(50);

                /* Se realiza una carga incial con los tipos de entrega */
                entity.HasData(new TipoMercaderia
                {
                    TipoMercaderiaId = 1,
                    Descripcion = "Entrada"
                });
                entity.HasData(new TipoMercaderia
                {
                    TipoMercaderiaId = 2,
                    Descripcion = "Minutas"
                });
                entity.HasData(new TipoMercaderia
                {
                    TipoMercaderiaId = 3,
                    Descripcion = "Pastas"
                });
                entity.HasData(new TipoMercaderia
                {
                    TipoMercaderiaId = 4,
                    Descripcion = "Parrilla"
                });
                entity.HasData(new TipoMercaderia
                {
                    TipoMercaderiaId = 5,
                    Descripcion = "Pizzas"
                });
                entity.HasData(new TipoMercaderia
                {
                    TipoMercaderiaId = 6,
                    Descripcion = "Sandwich"
                });
                entity.HasData(new TipoMercaderia
                {
                    TipoMercaderiaId = 7,
                    Descripcion = "Ensaladas"
                });
                entity.HasData(new TipoMercaderia
                {
                    TipoMercaderiaId = 8,
                    Descripcion = "Bebidas"
                });
                entity.HasData(new TipoMercaderia
                {
                    TipoMercaderiaId = 9,
                    Descripcion = "Cerveza Artesanal"
                });
                entity.HasData(new TipoMercaderia
                {
                    TipoMercaderiaId = 10,
                    Descripcion = "Postres"
                });

            });
        }
    }
}
