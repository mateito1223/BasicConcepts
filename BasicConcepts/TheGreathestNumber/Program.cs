using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    Console.WriteLine("Ingrese tres numeros enteros diferentes para comparar cual es el mayor");
    var a = ConsoleExtension.GetInt("Ingrese el primer numero: ");
    var b = ConsoleExtension.GetInt("Ingrese el segundo numero: ");
    var c = ConsoleExtension.GetInt("Ingrese el tercer numero: ");

    if (a > b && a > c)
    {
        Console.WriteLine($"El numero mayor es: {a}");
    }


    else if (b > a && b > c)
        {
            Console.WriteLine($"El numero mayor es: {b}");
        }

    else
    {
        Console.WriteLine($"El numero mayor es: {c}");
    }

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("Game Over");

