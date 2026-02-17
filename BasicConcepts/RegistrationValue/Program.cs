using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{

    var credits = ConsoleExtension.GetInt("Ingrese el numero de creditos: ");
    var CreditValue = ConsoleExtension.GetDecimal("Ingrese el valor del credito: ");
    var stratum = ConsoleExtension.GetInt("Estrato del estudiante: ");

    var RegistrationValue = CalculateRegistrationValue(credits, CreditValue, stratum);
    var subsidy = CalculateSubsidy(stratum);

    Console.WriteLine($"El valor a pagar por la matricula es: {(RegistrationValue),20:C2}");
    Console.WriteLine($"El subsidio otorgado es: {(subsidy),20:C2}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Desea Continuar? [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("Game Over");

decimal CalculateSubsidy(int stratum)
{
    if (stratum == 1)
    {
        return 200000m;
    }

    if (stratum == 2)
    {
        return 100000m;
    }

    return 0;
}


decimal CalculateRegistrationValue(int credits, decimal CreditValue, int stratum)
{
    decimal value;
    if (credits <= 20)
    {
        value = credits * CreditValue;
    }

    else
    {
        value = 20 * CreditValue + (credits - 20) * CreditValue * 2;
    }

    if (stratum == 1)
    {
        return value * 0.20m;
    }

    if (stratum == 2)
    {
        return value * 0.50m;
    }

    if (stratum == 3)
    {
        return value * 0.70m;
    }

    return value;
}