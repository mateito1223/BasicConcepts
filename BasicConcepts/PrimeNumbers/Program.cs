using Shared;
using System.IO.Pipelines;

var options = new List<string> {"s", "n"};
var answer = string.Empty;

do
{
	var n = ConsoleExtension.GetInt("¿Cuantos numeros deseas?: ");
	var primes = GetPrimes(n);
	foreach (var prime in primes)
	{
		Console.Write($"{prime,10:N0}");
	}
	Console.WriteLine();
    Console.WriteLine($"La sumatoria es: {primes.Sum(),5:N0}");
    Console.WriteLine($"El promedio  es: {primes.Average(),5:N0}");
    Console.WriteLine();

    do
	{
		answer = ConsoleExtension.GetValidOptions("Desea continuar (s/n)", options);
		Console.WriteLine();
	} while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

List<int> GetPrimes(int n)
{
	var primes = new List<int>();
	var num = 2;
	while (primes.Count < n)
	{
		if (MyMath.IsPrime(num))
		{
			primes.Add(num);
		}
		num++;
	}
	return primes;
}