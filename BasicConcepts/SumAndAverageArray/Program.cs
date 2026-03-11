using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    // Data input
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.Clear();
    Console.WriteLine("*** SUMATORIA Y PROMEDIO DE UN ARREGLO ***");
    var n = ConsoleExtension.GetInt("De que tamaño quieres tu arreglo: ");
    var arr = new int[n];

    // Do process
    FillArray(arr);
    var sum = GetSum(arr);
    var prom = GetProm(arr);
    // Show results
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Yellow;

    ShowArray(arr);
    Console.WriteLine();
    Console.WriteLine($"La sumatoria del arreglo es: {sum:N0}"); // tambien hay unas palabras reservadas llamadas Sum y Average con las que podria hacer todo
    Console.WriteLine($"El promedio del arreglo es: {prom:N2}"); // el proceso mas facilmente sin necesidad de crear 2 metodos para cada uno 
    Console.BackgroundColor = ConsoleColor.Blue;                 // arr.Sum(),10:N0   arr.Average(),10:N2

    Console.ForegroundColor = ConsoleColor.White;
    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

decimal GetProm(int[] arr)
{
    decimal prom = 0;
    foreach (int number in arr)
    {
        prom += number;
    }
    return prom / arr.Length;
}

int GetSum(int[] arr)
{
    int sum = 0;
    foreach (int number in arr)
    {
        sum += number;
    }
    return sum;
}

void ShowArray(int[] arr)
{
    foreach (var number in arr)
    {
        Console.Write($"{number,10:N0}");
    }
    Console.WriteLine();
}

void FillArray(int[] arr)
{
    var random = new Random();
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = random.Next(0, 100);
    }
}

