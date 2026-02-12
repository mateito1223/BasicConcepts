using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var number = ConsoleExtension.GetInt("Ingrese número entero o Ctrl + c para salir: ");
        if (number % 2 == 0)
        {
            Console.WriteLine($"El numero: {number} es par"); // 12
        }
        else
        {
            Console.WriteLine($"El numero: {number} es impar"); // 13
        }
    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("Game Over");









