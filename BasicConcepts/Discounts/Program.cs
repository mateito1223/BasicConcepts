using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do 
{
    
var Desks = ConsoleExtension.GetInt("Ingrese el numero de escritorios que desea comprar: ");
var priceDesk = 650000m;

decimal total = Desks * priceDesk;
decimal discount = 0;

if (Desks < 5)
{
    discount = total * 0.10m;
}
else if (Desks >= 5 && Desks < 10)
{
    discount = total * 0.20m;
}
else
{
    discount = total * 0.40m;
}

decimal finalPrice = total - discount;

Console.WriteLine($"El valor a pagar por {Desks} escritorios es: {finalPrice:C2}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Desea Continuar? [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("Game Over");