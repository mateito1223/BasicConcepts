using Shared;

var options = new List<string> { "s", "n" };
var answer = string.Empty;

do
{
    // Data input
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.Clear();
    Console.WriteLine("*** PARES E IMPARES EN UNA ARREGLO ***");
    var n = ConsoleExtension.GetInt("Cuantas posiciones quieres en el arreglo: ");
    var arr = new int[n];

    // Do process
    FillArray(arr);
    var sumatory = GetSumEven(arr);
    var prod = GetProductory(arr);
    // Show results
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Yellow;

    ShowArray(arr);
    Console.WriteLine();
    Console.WriteLine($"La suma de los pares es: {sumatory:N0}");
    Console.WriteLine($"La productoria del arreglo es: {prod:N0}");

    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar (s/n)?", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
}
while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

double GetProductory(int[] arr)
{
    double prod = 1;
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] % 2 != 0)
        {
            prod *= arr[i];
        }
    }
    return prod;
}

int GetSumEven(int[] arr)
{
    int sum = 0;
    foreach (var number in arr)
    {
        if (number % 2 == 0)
        {
            sum += number;
        }
              
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