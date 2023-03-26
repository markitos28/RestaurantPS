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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comanda>(entity =>
            {
                entity.HasKey(s => s.ComandaId);
                entity.HasOne<FormaEntrega>(o => o.FKFormaEntrega).WithMany(m => m.LsComanda).HasForeignKey(f => f.FormaEntregaId);
                entity.HasMany<ComandaMercaderia>(m => m.LsComandaMercaderia).WithOne(o => o.FKComanda);
                entity.Property(s => s.FormaEntregaId).IsRequired();
                entity.Property(s => s.PrecioTotal).IsRequired();
                entity.Property(s => s.Fecha).IsRequired();
            });

            modelBuilder.Entity<FormaEntrega>(entity => 
            {
                entity.HasKey(k => k.FormaEntregaId);
                entity.HasMany<Comanda>(m => m.LsComanda).WithOne(o => o.FKFormaEntrega);
                entity.Property(s => s.Descripcion).HasMaxLength(50);
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
                    Nombre= "Hamburguesas de Carne y Cerdo",
                    TipoMercaderiaId= 6,
                    Precio = 2500,
                    Ingredientes = "500gr Bondiola de cerdo / 500gr Carne roast beef / 100gr Panceta salada / Mostaza / Condimentos a elección y sal / Cebolla morada tomates / Queso",
                    Preparacion = "P1: Picar las carnes en pedacitos y la panceta\nP2: Poner a procesar, mezclarlas bien.\nP3: Incorporar la mostaza y los condimentos más la sal, mezclar bien.\nP4: Preparar hamburguesas.\nP5: Cocinar y agregar el queso. A un lado puse las cebollas.",
                    Imagen = ""
                });
                entity.HasData(new Mercaderia
                {
                    Nombre = "Hamburguesas de soja VEGANAS",
                    TipoMercaderiaId = 6,
                    Precio = 2800,
                    Ingredientes = "2 tazas soja texturizada en crudo / Agua / Puñado perejil / 1 cebolla mediana / 3 dientes ajo / Pedazo morrón rojo  / 6 cucharadas soperas harina integral/ 2 cucharadas soperas avena instantánea/ Harina para rebozar ",
                    Preparacion = "P1: Remojar la soja por 20 minutos.\nP2: Picar ajo y cebolla, y cocinar con aceite de oliva. Añadir morron luego de estar dorados y cocinar 5 minutos mas.\nP3: Vamos a colar y sacar del remojo a la soja texturizada.",
                    Imagen = ""
                });
                entity.HasData(new Mercaderia
                {
                    Nombre = "Tacos de Carne",
                    TipoMercaderiaId = 6,
                    Precio = 4200,
                    Ingredientes = "6 rapiditas/ 4 bifes de carne magra / 1 cebolla mediana / 1 cebolla morada mediana / Morrones (rojo, verde y amarillo) / 4dientes ajo / Poquito pimentón dulce/ Queso crema (opcional)",
                    Preparacion = "P1: Saltear verduras en aceite de oliva.\nP2: Quitar la grasa a la carne, cortarla en cubos y saltearla con las verduras.\nP3: Cuando la carne ya esté lista condimentamos con el pimentón dulce y mezclamos muy bien.\nP4: Armar las tortillas.",
                    Imagen = ""
                });
                entity.HasData(new Mercaderia
                {
                    Nombre = "Sandwich de pollo y verduras",
                    TipoMercaderiaId = 6,
                    Precio = 2200,
                    Ingredientes = "Pechugas de pollo/ Mitad cebolla/ Ajo cantidad a gusto/ 1 cuarto morrón rojo/ 1 zanahoria/ 1 puñado Queso mozza rallado/ Sal,Pimienta y perejil a gusto/ Cebolla de verdeo a gusto/ 1 cucharada Mayonesa/ 1 cucharaditaMostaza/ Pan de hamburguesas",
                    Preparacion = "P1: Cocinar pechugas, agregar pimienta, sal y ajo.\nP2: Cortar la pechuga en cubos.\nP3: Agregar verduras y condimentos.\nP4: Armar sandwich.",
                    Imagen = ""
                });
                entity.HasData(new Mercaderia
                {
                    Nombre = "Canastitas de calabaza asada con finas hierbas",
                    TipoMercaderiaId = 2,
                    Precio = 4300,
                    Ingredientes = "1 calabaza mediana/ 2 huevos/ 100 gr queso rallado/ Hierbas secas o frescas a elección/ Orégano/ Romero/ Tomillo/ Albahaca/ Sal/ Aceite de oliva/ 12 tapas de empanadas chicas",
                    Preparacion = "P1: Asar la calabaza con aceite de oliva.\nP2: Agregar 2 huevos, queso rallado, sal y pimienta.\nP3: Armar canastitas y cocinar por 20 minutos.",
                    Imagen = ""
                });
                entity.HasData(new Mercaderia
                {
                    Nombre = "Ñoquis soufflé de espinacas",
                    TipoMercaderiaId = 3,
                    Precio = 3100,
                    Ingredientes = "1 kilo harina 000 / 1/2 taza aceite / 600 cc agua hirviendo / 10 hojas espinacas bien lavadas / 1 cucharada sal ",
                    Preparacion = "P1: Poner a calentar agua. Revolver la harina con sal en un bowl.\nP2: Mixear el aceite y las hojas de espinaca.\nP3: Mezclar lo mixeado con la harian y sal.\nP4: amasar la harina y la pasta de espinacas con el agua caliente.\n",
                    Imagen = ""
                });
                entity.HasData(new Mercaderia
                {
                    Nombre = "Pizza de Jamon y morron",
                    TipoMercaderiaId = 5,
                    Precio = 2100,
                    Ingredientes = "200 g harina 0000 / 80 ml agua / 10 ml aceite de girasol / 7 g levadura seca / 30 ml salsa de tomate / 1 pizca sal, pimienta blanca, pizca orégano / 1 chorrito aceite de oliva / 75 g queso porsalut /1/2 tomate redondo un huevo/ 6 fetas jamón cocido",
                    Preparacion = "",
                    Imagen = ""
                });
                entity.HasData(new Mercaderia
                {
                    Nombre = "Papas con Cheddar y Panceta",
                    TipoMercaderiaId = 1,
                    Precio = 1900,
                    Ingredientes = "5 papás / 200 gr panceta / Queso cheddar / Crema de leche",
                    Preparacion = "P1: Costamos las papas en bastón\nP2: Luego cortamos la panceta en tiras\nP3: Calentamos la plancha y cocinamos la panceta sin ninguna materia grasa. Una vez que está dorada ya está lista",
                    Imagen = ""
                });
                /*
                entity.HasData(new Mercaderia
                {
                    Nombre = "",
                    TipoMercaderiaId = 1,
                    Precio = ,
                    Ingredientes = "",
                    Preparacion = "",
                    Imagen = ""
                });
                entity.HasData(new Mercaderia
                {
                    Nombre = "",
                    TipoMercaderiaId = 1,
                    Precio = ,
                    Ingredientes = "",
                    Preparacion = "",
                    Imagen = ""
                });
                entity.HasData(new Mercaderia
                {
                    Nombre = "",
                    TipoMercaderiaId = 1,
                    Precio = ,
                    Ingredientes = "",
                    Preparacion = "",
                    Imagen = ""
                });
                entity.HasData(new Mercaderia
                {
                    Nombre = "",
                    TipoMercaderiaId = 1,
                    Precio = ,
                    Ingredientes = "",
                    Preparacion = "",
                    Imagen = ""
                });
                entity.HasData(new Mercaderia
                {
                    Nombre = "",
                    TipoMercaderiaId = 1,
                    Precio = ,
                    Ingredientes = "",
                    Preparacion = "",
                    Imagen = ""
                });
                entity.HasData(new Mercaderia
                {
                    Nombre = "",
                    TipoMercaderiaId = 1,
                    Precio = ,
                    Ingredientes = "",
                    Preparacion = "",
                    Imagen = ""
                });
                entity.HasData(new Mercaderia
                {
                    Nombre = "",
                    TipoMercaderiaId = 1,
                    Precio = ,
                    Ingredientes = "",
                    Preparacion = "",
                    Imagen = ""
                });
                entity.HasData(new Mercaderia
                {
                    Nombre = "",
                    TipoMercaderiaId = 1,
                    Precio = ,
                    Ingredientes = "",
                    Preparacion = "",
                    Imagen = ""
                });
                entity.HasData(new Mercaderia
                {
                    Nombre = "",
                    TipoMercaderiaId = 1,
                    Precio = ,
                    Ingredientes = "",
                    Preparacion = "",
                    Imagen = ""
                });
                entity.HasData(new Mercaderia
                {
                    Nombre = "",
                    TipoMercaderiaId = 1,
                    Precio = ,
                    Ingredientes = "",
                    Preparacion = "",
                    Imagen = ""
                });
                entity.HasData(new Mercaderia
                {
                    Nombre = "",
                    TipoMercaderiaId = 1,
                    Precio = ,
                    Ingredientes = "",
                    Preparacion = "",
                    Imagen = ""
                });
                entity.HasData(new Mercaderia
                {
                    Nombre = "",
                    TipoMercaderiaId = 1,
                    Precio = ,
                    Ingredientes = "",
                    Preparacion = "",
                    Imagen = ""
                });
                */
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
