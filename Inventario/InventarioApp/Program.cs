// ============================================================
// SISTEMA DE INVENTARIO - Clase 1.1
// Estado: Mensaje de bienvenida
// ============================================================

using System.Reflection;

var assembly = Assembly.GetExecutingAssembly();
var version = assembly.GetName().Version;

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

int cantidadProductos = 0;
decimal valorTotalDelInventario = 0.00m;
bool sistemaActivo = true;
string nombreSistema = "Sistema de gestion de invenatario";
decimal precio = 19.99m;

Console.WriteLine("Estado del sistema");
Console.WriteLine($"Nombre: {nombreSistema}");
Console.WriteLine($" Productos registrados: {cantidadProductos}");
Console.WriteLine($" Valor total del inventario: {valorTotalDelInventario:N2}");
Console.WriteLine($"Estado del sistema: {(sistemaActivo ? "Si" : "No")}"); // ? es el operador ternario que es como un if/else compacto

Console.Write("Ingrese una cantidad: ");
string? entradaCantidad = Console.ReadLine();

//Conversion segura TryParse
if (int.TryParse(entradaCantidad, out int cantidad))
{
    Console.WriteLine($"Cantidad valida: {cantidad}\n");
    cantidadProductos = cantidad;
}
else
{
    Console.WriteLine("Error: debe ingresar un numero entero");
}

Console.Write("ingrese un precio: ");
string? entradaPrecio = Console.ReadLine();

if (decimal.TryParse(entradaPrecio, out decimal precio2))
{
    Console.WriteLine($"Precio validado: {precio2:N2}\n");
    valorTotalDelInventario = cantidadProductos * precio2;
    Console.WriteLine($"Valor total del inventario actualizado: ${valorTotalDelInventario:N2}");
}
else
{
    Console.WriteLine("Error: debe ingresar un numero decimal");
}

//MostrarBanner();

// Modo Interactivo sin argumentos
Console.WriteLine("Ingrese un comando (o 'Salir' para terminar): ");
string? entrada = Console.ReadLine(); //entrada de usuario STDIN

if (string.IsNullOrEmpty(entrada) || entrada == "Salir")
{
    Console.WriteLine("Hasta luego"); //STDOUT
    Environment.Exit(0);
}

/*Console.WriteLine();
Console.WriteLine("Estructura del proyecto:");
Console.WriteLine(" InventarioApp/");
Console.WriteLine(" |-- Program.cs");
Console.WriteLine(" |-- InventarioApp.cs");
Console.WriteLine(" |-- gitignore");
Console.WriteLine(" |-- Readme.md");
Console.WriteLine("     |--src/");
Console.WriteLine("        | --Models/");
Console.WriteLine("Configuracion .csproj");
Console.WriteLine("Carpeta src/ creada");
Console.WriteLine("Metadatos Configurados");
Console.WriteLine();
Console.WriteLine("Proximo pas: Checkpoint");*/

// ============== FUNCIONES ==============
void MostrarBanner()
{
    Console.WriteLine("╔══════════════════════════════════════╗");
    Console.WriteLine("║   SISTEMA DE GESTIÓN DE INVENTARIO   ║");
    Console.WriteLine("╚══════════════════════════════════════╝");
    Console.WriteLine();
    Console.WriteLine($"Versión: {version}");
    Console.WriteLine($".NET: {Environment.Version}");
    Console.WriteLine($"Sistema: {Environment.OSVersion.Platform}");
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