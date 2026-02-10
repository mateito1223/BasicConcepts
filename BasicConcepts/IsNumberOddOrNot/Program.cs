var numberString = string.Empty;

do
{
    Console.Write("Ingrese in numero entero o presione ´Salir´ para salir: ");
    numberString = Console.ReadLine();
    if (numberString!.ToLower() == "salir")
    {
        continue;
    }
    var numberInt = 0;
    if (int.TryParse(numberString, out numberInt))
    {
        if (numberInt % 2 == 0)
        {
            Console.WriteLine($"El numero: {numberInt} es par");
        }
        else
        {
            Console.WriteLine($"El numero: {numberInt} es impar");
        }
    }
    else
    {
        Console.WriteLine("El valor ingresado no es un numero valido");
    }

 } while (numberString.ToLower() != "salir");
Console.WriteLine("Game Over");









