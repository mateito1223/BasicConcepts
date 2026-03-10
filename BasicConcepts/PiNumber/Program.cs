using Shared;

var options = new List<string> { "s", "n" };
var answer = string.Empty;

do
{
    // Data input
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.Clear();
    Console.WriteLine("CALCULO DEL NUMERO Pi");
    var n = ConsoleExtension.GetInt("Cuantos terminos de precision quieres: ");

    // Do process
    var pi = CalculatePi(n);
    // Show results
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Yellow;

    Console.WriteLine($"El valor de Pi con {n} terminos de precision es: {pi}");

    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;

    do
	{
		answer = ConsoleExtension.GetValidOptions("¿Deseas continuar (s/n)?", options);
	} while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
}
while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

double CalculatePi(int n)
{
    double sum = 0;
    double den = 1;
    int sig = 1;
    for (int i = 0; i < n; i++)
    {
        double ter = 1 / den * sig;
        sum += ter;
        den += 2;
        sig *= -1;
    }
    return sum * 4;
}

Console.WriteLine("Game Over");