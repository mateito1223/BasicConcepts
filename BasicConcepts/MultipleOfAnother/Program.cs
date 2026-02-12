using Shared;
using System.ComponentModel.Design;

do
{
    Console.WriteLine("Ingrese dos numeros enteros para verificar si el primero es multiplo del segundo");
    var a = ConsoleExtension.GetInt("Ingrese el primer numero: ");
    var b = ConsoleExtension.GetInt("Ingrese el segundo numero: ");

    if (a % b == 0)
    {
        Console.WriteLine($"El numero {b}, es multiplo de {a}");
    }

    else
    {
        Console.WriteLine($"El numero {b}, no es multiplo de {a}");
    }

} while (true);
Console.WriteLine("Fin del Juego");