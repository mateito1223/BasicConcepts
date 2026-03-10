using Shared;

var options = new List<string> { "s", "n" };
var answer = string.Empty;

do
{
    // Data input
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.Clear();
    Console.WriteLine("CALCULO DEL NUMERO E");
    var n = ConsoleExtension.GetInt("Cuantos terminos deseas procesar: ");

    // Do process
    var e = CalculateE(n);
    // Show results
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Yellow;

    Console.WriteLine($"El valor de E con {n} terminos de precision es: {e}");

    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;



    do
    {
        answer = ConsoleExtension.GetValidOptions("Desea continuar (s/n)", options);
        Console.WriteLine();
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

double CalculateE(int n)
{
    double sum = 0;
    for (int i = 0; i < n; i++)
    { 
    sum += 1 / MyMath.Factorial(i);
    }
    return sum;
}