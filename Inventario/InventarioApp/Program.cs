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

MostrarBanner();

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