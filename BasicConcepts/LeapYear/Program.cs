using Shared;

do
{
    Console.WriteLine("Ingresa un año para determinar si es biciesto o no");
    var year = ConsoleExtension.GetInt("Enter a year: ");
    var num = 4;

    if (year % num == 0)
    {
        Console.WriteLine($"El año {year}, es bisiesto");
    }

    else
    { 
        Console.WriteLine($"El año {year}, no es bisiesto");
    }

} while (true);
Console.WriteLine("Fin del Juego");
