using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    int weight = ConsoleExtension.GetInt("Ingrese el peso: ");
    var Value = ConsoleExtension.GetDecimal("Ingrese el valor de la mercancia: ");
    String monday;


    do
    {
        monday = ConsoleExtension.GetValidOptions("¿Es lunes? [S]i, [N]o: ", options)!;
    } while (!options.Any(x => x.Equals(monday, StringComparison.CurrentCultureIgnoreCase)));


    var paymentType = new List<string> { "e", "t" };
    string payMethod;
    do
    {
        payMethod = ConsoleExtension.GetValidOptions("Tipo de pago [E]fectivo [T]arjeta: ", paymentType)!;
    } while (!paymentType.Any(x => x.Equals(payMethod, StringComparison.CurrentCultureIgnoreCase)));


    var fare = CalculateFare(weight);

    decimal promotion = CalculatePromotion(fare, monday, payMethod, Value);
    decimal Discount = 0;

    if (promotion == 0)
    {
        Discount = CalculateDiscount(fare, Value);
    }

    Console.WriteLine($"Tarifa: {(fare),51:C2}");
    Console.WriteLine($"Descuento: {(Discount),48:C2}");
    Console.WriteLine($"Promocion: {(promotion),48:C2}");
    Console.WriteLine($"El valor total a pagar es de: {(fare - Discount - promotion),29:C2}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Desea Continuar? [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("Game Over");


decimal CalculatePromotion(decimal fare, string monday, string payMethod, decimal Value)
{
    if (monday.ToLower() == "s" && payMethod.ToLower() == "t")
    {
        return fare * 0.50m;
    }

    if (payMethod.ToLower() == "e" && Value > 1000000m)       
    { 
      return fare * 0.40m;
    }

    return 0;
}


decimal CalculateDiscount(decimal fare, decimal Value)
{
    if (Value >= 300000m && Value <= 600000m)
    {
        return fare * 0.10m;
    }
    if (Value > 600000m && Value <= 1000000m)
    {
        return fare * 0.20m;
    }
    if (Value > 1000000m)
    {
        return fare * 0.30m;
    }
    return 0;
}


decimal CalculateFare(int weight)
{
    if (weight < 100)
    {
        return 20000m;
    }
    if (weight >= 100 && weight <= 150)
    {
        return 25000m;
    }
    if (weight > 150 && weight <= 200)
    {
        return 30000m;
    }
    if (weight > 200)
    {
        return 35000m + ((weight - 200) / 10) * 2000m;
    }
    return 0;
}



