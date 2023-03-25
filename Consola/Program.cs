bool salir = false;
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
            tomarPedido();
            break;
        case "2":
            listarPedido();
            break;
        default:
            Console.WriteLine("Opcion incorrecta, vuelva a intentarlo . . .");
            break;
    }

}

void tomarPedido()
{
    Console.Clear();
    Console.WriteLine("------------------------------------------------------");
    Console.WriteLine("--- Bienvenido al Sistema de Gestion de Restorant ----");
    Console.WriteLine("------- Tomaremos su pedido para prepararlo ----------");
    Console.WriteLine("------------------------------------------------------");


}

void listarPedido()
{
    Console.Clear();
    Console.WriteLine("-------------------------------------------------------");
    Console.WriteLine("---- Bienvenido al Sistema de Gestion de Restorant ----");
    Console.WriteLine("----------------- Lista de comandas -------------------");
    Console.WriteLine("-------------------------------------------------------");
}