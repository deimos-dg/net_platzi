// ============================================================
// SISTEMA DE INVENTARIO - Clase 1.1
// Estado: Mensaje de bienvenida
// ============================================================

using System.Reflection;

var assembly = Assembly.GetExecutingAssembly();
var version = assembly.GetName().Version;

MostrarBanner();


if (args.Length > 0)
{
    switch(args[0].ToLower())
    {
        case "--help":
            MostrarAyuda();
            Environment.Exit(0); // 0, significa exito todo salio bien y el 1 es error general
            break;
        
        case "--version":
            Console.WriteLine($"InventarioApp: v[{version}]");
            Environment.Exit(0);
            break;
        
        default:
            Console.WriteLine("Error: comando desconocido '{args[0]}'");
            Console.WriteLine("use --help para ver los comandos disponibles");
            Environment.Exit(2); // 2, uso incorrecto
            break;
    }
}


//Variables

int cantidadProductos = 0;
//decimal valorTotalDelInventario = 0.00m;
bool sistemaActivo = true;
//string nombreSistema = "Sistema de gestion de inventario";
//decimal precio = 19.99m;



Console.WriteLine("Estado del sistema");
//Console.WriteLine($"Nombre: {nombreSistema}");
Console.WriteLine($" Productos registrados: {cantidadProductos}");
//Console.WriteLine($" Valor total del inventario: {valorTotalDelInventario:N2}");
Console.WriteLine($"Estado del sistema: {(sistemaActivo ? "Si" : "No")}"); // ? es el operador ternario que es como un if/else compacto

//Console.Write("Ingrese una cantidad: ");
//string? entradaCantidad = Console.ReadLine();

// Loop de nullabilidad

Console.WriteLine("Comandos: listar, agregar, buscar, salir");
Console.WriteLine();

while (sistemaActivo)
{
    Console.Write("Ingrese un comando: ");
    string? entrada = Console.ReadLine();
    
    //Aplicamos el manejo seguro
    string comando = string.IsNullOrEmpty(entrada) ? "salir" : entrada.Trim().ToLower();
    switch (comando)
    {
        case "salir":
            sistemaActivo = false;
            Console.WriteLine("Saliendo");
            break;
        
        case "listar":
            Console.WriteLine($"Productos de inventario: {cantidadProductos}");
            break;
        
        case "":
            break;
        
        default:
            Console.WriteLine($"Comando '{comando}' no reconocido.");
            Console.WriteLine("Comandos: listar, agregar, buscar, salir");
            break;
    }
}


// ============== FUNCIONES ==============
void MostrarBanner()
{
    Console.WriteLine("╔══════════════════════════════════════╗");
    Console.WriteLine("║   SISTEMA DE GESTIÓN DE INVENTARIO   ║");
    Console.WriteLine("╚══════════════════════════════════════╝");
    Console.WriteLine();
    Console.WriteLine($"Versión: {version}");
    Console.WriteLine($".NET: {Environment.Version}");
    Console.WriteLine();
}

void MostrarAyuda()
{
    Console.WriteLine("USO: InventarioApp [comando] [opciones]");
    Console.WriteLine();
    Console.WriteLine("COMANDOS:");
    Console.WriteLine("  --help, -h      Muestra esta ayuda");
    Console.WriteLine("  --version, -v   Muestra la version del programa");
    Console.WriteLine();
    Console.WriteLine("EJEMPLOS:");
    Console.WriteLine(" dotnet run -- --help");
    Console.WriteLine(" dotnet run -- --version");
}