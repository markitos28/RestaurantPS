using Aplicacion.Ayudantes;
using Dominio.Entidades;
using Infraestructura;
using Infraestructura.Comandos;
using Infraestructura.Querys;
using Aplicacion.Interfaces.Querys;
using Aplicacion.Interfaces.Comandos;
using Aplicacion.CasosDeUso.Modulo;
using Dominio.DTOs;

bool salir = false;
RestoDbContext restoDbContext = new RestoDbContext();

while (!salir)
{
    Console.Clear();
    Console.WriteLine("-------------------------------------------------------");
    Console.WriteLine("---- Bienvenido al Sistema de Gestion de Restorant ----");
    Console.WriteLine("-------------------------------------------------------");
    Console.WriteLine();
    Console.WriteLine("Seleccione una opcion para operar: ");
    Console.WriteLine("1) Tomar pedido al cliente.");
    Console.WriteLine("2) Listar las comandas.");
    Console.WriteLine("0) Salir.");
    Console.WriteLine("Opcion --> ");
    string opcion= Console.ReadLine();

    switch (opcion)
    {
        case "0":
            salir = true;
            break;
        case "1":
            Console.WriteLine("Aguarde . . .");
            tomarPedido(restoDbContext);
            break;
        case "2":
            Console.WriteLine("Aguarde . . .");
            listarPedido(restoDbContext);
            break;
        default:
            Console.WriteLine("Opcion incorrecta, vuelva a intentarlo . . .");
            break;
    }

}

async void tomarPedido(RestoDbContext dbConnection)
{
    IComandaCommand comandaCommand = new ComandaCommand(dbConnection);
    IComandaQuery comandaQuery = new ComandaQuery(dbConnection);
    IComandaMercaderiaCommand comandaMercaderiaCommand = new ComandaMercaderiaCommand(dbConnection);
    IMercaderiaQuery mercaderiaQuery = new MercaderiaQuery(dbConnection);
    IFormaEntregaQuery formaEntregaQuery = new FormaEntregaQuery(dbConnection);
    ComandaModule comandaModule = new ComandaModule(comandaCommand, comandaQuery);
    FormaEntregaModule feModule = new FormaEntregaModule(formaEntregaQuery);
    MercaderiaModule mercaderiaModule = new MercaderiaModule(mercaderiaQuery);
    ComandaMercaderiaModule cmModule = new ComandaMercaderiaModule(comandaMercaderiaCommand);

    var lsFormaEntrega = feModule.ListarFormaEntrega();
    var lsMercaderia = mercaderiaModule.ListarMercaderia();
    List<Mercaderia> pedido = new List<Mercaderia>();
    ComandaDTO comanda;
    var newComandaId =  new GenerarIdentificador(comandaQuery).GenerarIdComanda();
    await newComandaId;
    ComandaMercaderiaDTO comandaMercaderia;
    bool flagFin = false;
    int precioTotal=0;
    string opcion;
    Console.Clear();
    Console.WriteLine("------------------------------------------------------");
    Console.WriteLine("--- Bienvenido al Sistema de Gestion de Restorant ----");
    Console.WriteLine("------- Tomaremos su pedido para prepararlo ----------");
    Console.WriteLine("------------------------------------------------------");
    Console.WriteLine();
    Console.WriteLine("Por favor, seleccione mediante los numeros los pedidos que desea realizar . . .");
    Console.WriteLine("Si desea eliminar un pedido, anteponga el signo '-' delante del numero.");
    Console.WriteLine("La cartilla es:");

    for(int i=0; i<lsMercaderia.Count; i++)
    {
        Console.WriteLine("{0}) {1}\t\tPrecio: {2}", i+1, lsMercaderia[i].Nombre, lsMercaderia[i].Precio);
    }
    Console.WriteLine("Presione 0 para finalizar el pedido.");

    while (!flagFin)
    {

        Console.WriteLine("Pedido: ");
        foreach(Mercaderia mercaderia in pedido)
        { 
            Console.WriteLine("\t\t" + mercaderia.Nombre + " | "); 
        }
        Console.WriteLine("Ingrese una opcion: ");
        opcion = Console.ReadLine();
        var validar = new Validador(opcion).OpcionValida();
        if (validar.esValido & validar.valor <= lsMercaderia.Count & validar.valor >= (lsMercaderia.Count * -1))
        {
            if(validar.valor > 0)
            {
                pedido.Add(lsMercaderia[validar.valor - 1]);
                precioTotal += lsMercaderia[validar.valor - 1].Precio;
                Console.WriteLine("Añadido!");
            }
            else if(validar.valor < 0)
            {
                Mercaderia objEliminar = lsMercaderia[(validar.valor * -1) - 1];
                if (pedido.Exists(x => x.MercaderiaId == objEliminar.MercaderiaId))
                {
                    pedido.Remove(lsMercaderia[(validar.valor * -1) - 1]);
                    precioTotal -= lsMercaderia[(validar.valor * -1) - 1].Precio;
                    Console.WriteLine("Eliminado!");
                }
                else
                {
                    Console.WriteLine("El pedido que desea eliminar no fue agregado a su comanda.");
                }
                
            }
            else
            {
                flagFin = true;
            }
            
        }
        else
        {
            
            Console.WriteLine("Ha ingresado una opcion incorrecta. Vuelva a intentar . . ."); 
        }
    }
    if(pedido.Count >0)
    {
        flagFin = false;
        Console.WriteLine("Elija la forma de entrega: ");
        for (int i = 0; i < lsFormaEntrega.Count; i++)
        {
            Console.WriteLine("{0}) {1}", i + 1, lsFormaEntrega[i].Descripcion);
        }

        while (!flagFin)
        {

            Console.WriteLine("Ingrese una opcion: ");
            opcion = Console.ReadLine();
            var validar = new Validador(opcion).OpcionValida();
            if (validar.esValido & validar.valor < lsFormaEntrega.Count & validar.valor >= 1)
            {

                comanda = new ComandaDTO
                {
                    ComandaId = newComandaId.Result,
                    FormaEntregaId = lsFormaEntrega[validar.valor - 1].FormaEntregaId,
                    PrecioTotal = precioTotal,
                    Fecha = DateTime.Now
                };
                await comandaModule.InsertarComanda(comanda);

                for(int i=0; i < pedido.Count; i++)
                {
                    comandaMercaderia = new ComandaMercaderiaDTO
                    {
                        ComandaId = newComandaId.Result,
                        MercaderiaId = pedido[i].MercaderiaId
                    };
                    await cmModule.InsertarComandaMercaderia(comandaMercaderia);
                }
                Console.Clear();
                Console.WriteLine("Su pedido fue registrado y se despachara a la brevedad . . .");
                Thread.Sleep(4000);
                flagFin = true;
            }
            else
            {
                Console.WriteLine("Opcion incorrecta. Por favor vuelva a intentar . . .");
            }

        }
    }
    

}

void listarPedido(RestoDbContext dbConnection)
{

    IComandaQuery comandaQuery = new ComandaQuery(dbConnection);
    IComandaMercaderiaQuery comandaMercaderiaQuery = new ComandaMercaderiaQuery(dbConnection);
    IMercaderiaQuery mercaderiaQuery = new MercaderiaQuery(dbConnection);
    IFormaEntregaQuery formaEntregaQuery = new FormaEntregaQuery(dbConnection);
    PedidoModule pedidoModule = new PedidoModule(comandaQuery, comandaMercaderiaQuery, mercaderiaQuery, formaEntregaQuery);
    var lsPedido = pedidoModule.ListarPedidos();
    Console.Clear();
    Console.WriteLine("-------------------------------------------------------");
    Console.WriteLine("---- Bienvenido al Sistema de Gestion de Restorant ----");
    Console.WriteLine("----------------- Lista de comandas -------------------");
    Console.WriteLine("-------------------------------------------------------");

    foreach(PedidoDTO pedido in lsPedido)
    {
        Console.WriteLine("Nro Comanda: {0} | Fecha: {1} | Forma de Entrega: {2} | Mercaderia: {3} | Precio: {4}", pedido.ComandaId, pedido.FechaComanda, pedido.DescripcionEntrega, pedido.NombreMercaderia, pedido.PrecioMercaderia);
        Console.WriteLine("Ingredientes: {0}", pedido.IngredientesMercaderia);
    }
    Console.WriteLine("Presione Enter para finalizar . . .");
    Console.ReadKey();

}