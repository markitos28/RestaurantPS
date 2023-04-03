using Dominio.Ayudantes;
using Infraestructura;
using Infraestructura.Comandos;
using Infraestructura.Querys;

bool salir = false;
RestoDbContext restoDbContext = new RestoDbContext();

while (salir)
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
            tomarPedido(restoDbContext);
            break;
        case "2":
            listarPedido(restoDbContext);
            break;
        default:
            Console.WriteLine("Opcion incorrecta, vuelva a intentarlo . . .");
            break;
    }

}

void tomarPedido(RestoDbContext dbConection)
{
    ComandaCommand comandaCommand = new ComandaCommand(restoDbContext);
    ComandaMercaderiaCommand comandaMercaderiaCommand = new ComandaMercaderiaCommand(restoDbContext);
    MercaderiaQuery mercaderiaQuery = new MercaderiaQuery(restoDbContext);
    FormaEntregaQuery formaEntregaQuery = new FormaEntregaQuery(restoDbContext);
    var lsFormaEntrega = formaEntregaQuery.SelectFormaEntrega();
    var lsMercaderia = mercaderiaQuery.SelectMercaderia();
    bool flagFin = false;
    int precioTotal;
    string opcion;
    Console.Clear();
    Console.WriteLine("------------------------------------------------------");
    Console.WriteLine("--- Bienvenido al Sistema de Gestion de Restorant ----");
    Console.WriteLine("------- Tomaremos su pedido para prepararlo ----------");
    Console.WriteLine("------------------------------------------------------");
    Console.WriteLine();
    Console.WriteLine("Por favor, seleccione mediante los numeros los pedidos que desea realizar . . .");
    Console.WriteLine("La cartilla es:");

    for(int i=0; i<lsMercaderia.Count; i++)
    {
        Console.WriteLine("{0}) {1}\t\tPrecio: {2}\n\tIngredientes: {3}", i+1, lsMercaderia[i].Nombre, lsMercaderia[i].Precio, lsMercaderia[i].Ingredientes);
    }
    Console.WriteLine("Presione 0 para finalizar el pedido.");
    
    while(!flagFin)
    {
        /* averiguar donde van los validadores de datos*/
        Console.WriteLine("Ingrese una opcion: ");
        opcion = Console.ReadLine();
        Validador validar = new Validador(opcion);
        if (validar.OpcionValida().esValido)
        {

        }
        else
        {
            Console.WriteLine("Ha ingresado una opcion incorrecta. Vuelva a intentar . . .");
        }
    }
    flagFin = false;
    Console.WriteLine("Elija la forma de entrega: ");
    for (int i = 0; i < lsFormaEntrega.Count; i++)
    {
        Console.WriteLine("{0}) {1}", i + 1, lsFormaEntrega[i].Descripcion);
    }
    while (!flagFin)
    {

    }
    

    


}

void listarPedido(RestoDbContext dbConection)
{
    Console.Clear();
    Console.WriteLine("-------------------------------------------------------");
    Console.WriteLine("---- Bienvenido al Sistema de Gestion de Restorant ----");
    Console.WriteLine("----------------- Lista de comandas -------------------");
    Console.WriteLine("-------------------------------------------------------");
}