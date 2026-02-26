using Shared;
using System.Diagnostics.CodeAnalysis;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
   var n = ConsoleExtension.GetInt("Ingrese la cantidad de numeros deseada: ");
   var sum = 0;

    for (int i = 1; i <= n; i++)
    {
        Console.Write($"{i}\t");
        sum += i;
    }
    Console.WriteLine($"\n");
    Console.WriteLine($"La suma es....: {sum,20:N0}");
    Console.WriteLine($"El promedio es: {sum / n,20:N0}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("Game Over");