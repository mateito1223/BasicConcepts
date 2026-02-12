using Shared;
using System.ComponentModel.Design;

do
{
    Console.WriteLine("Ingrese tres numeros enteros diferentes para ordenarlos de mayor a menor");
    var a = ConsoleExtension.GetInt("Ingrese el primer numero: ");
    var b = ConsoleExtension.GetInt("Ingrese el segundo numero: ");

    if (a == b)
    {
        Console.WriteLine("Los numeros deben ser diferentes, intente nuevamente");
        continue;
    }

    var c = ConsoleExtension.GetInt("Ingrese el tercer numero: ");
    if (b == c || a == c)
    {
        Console.WriteLine("Los numeros deben ser diferentes, intente nuevamente");
        continue;
    }

    if (a > b && a > c)
    {
        if (b > c)
            Console.WriteLine($"El mayor es {a}, el del medio es {b}, y el menor es {c}");

        else
            Console.WriteLine($"El mayor es {a}, el del medio es {c}, y el menor es {b}");
    }


    else if (b > a && b > c)
    {
        if (a > c)
            Console.WriteLine($"El mayor es {b}, el del medio es {a}, y el menor es {b}");

        else
            Console.WriteLine($"El mayor es {b}, el del medio es {c}, y el menor es {a}");
    }

    else
    {
        if (a > b)
    
            Console.WriteLine($"El mayor es {c}, el del medio es {a}, y el menor es {b}");

        else
            Console.WriteLine($"El mayor es {c}, el del medio es {b}, y el menor es {a}");
    }

} while (true);
Console.WriteLine("Game Over");