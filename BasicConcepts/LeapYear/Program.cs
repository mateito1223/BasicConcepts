using Shared;

do
{
    Console.WriteLine("Ingresa un año para determinar si es biciesto o no");
    var year = ConsoleExtension.GetInt("Ingrese el año: ");

    if (year % 4 == 0)

        if (year % 100 == 0)

            if (year % 400 == 0)
            {
                Console.WriteLine($"El año {year}, si es bisiesto");
            }
            else
            {
                Console.WriteLine($"El año {year}, no es bisiesto");
            }
        else
        {
            Console.WriteLine($"El año {year}, si es bisiesto");
        }
    else
    {
        Console.WriteLine($"El año {year}, no es bisiesto");
    }

} while (true);
Console.WriteLine("Fin del Juego");
