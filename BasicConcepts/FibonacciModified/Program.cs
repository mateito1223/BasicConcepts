using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var n = ConsoleExtension.GetInt("Cuantos terminos quiere: ");
    double a = 0;
    double b = 1;
    double c = 2;

    if (n == 1)
    {
        Console.WriteLine($"{a}");
    }
    else if (n == 2)
    {
        Console.WriteLine($"{a}\t{b}");
    }
    else if (n == 3)
    {
        Console.WriteLine($"{a}\t{b}\t{c}\t");
    }
    else
    {
        Console.Write($"{a}\t{b}\t{c}\t");
        for (int i = 4; i <= n; i++)
        {
            double d = a + b + c;
            Console.Write($"{d}\t");
            a = b;
            b = c;
            c = d;
        }
        Console.WriteLine();
    }

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("Game Over");