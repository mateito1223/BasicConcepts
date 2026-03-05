using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    
    var n = ConsoleExtension.GetInt("Ingrese un numero: ");
    var isPrime = MyMath.IsPrime(n);
    Console.WriteLine(isPrime ? $"{n} es primo" : $"{n} no es primo");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
        Console.WriteLine();
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("Game Over");


