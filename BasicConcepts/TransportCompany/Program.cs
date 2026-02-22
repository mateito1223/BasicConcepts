using Shared;
using System.Runtime.Intrinsics.Arm;

var answer = string.Empty;
var options = new List<string> { "s", "n" };


do
{
    var RouteOptions = new List<string> { "1", "2", "3", "4" };
    var Route = string.Empty;
    Console.WriteLine("*** DATOS DE ENTRADA ***");
    do
    {
        Route = ConsoleExtension.GetValidOptions("Ruta [1][2][3][4]: ", RouteOptions)!;
    } while (!RouteOptions.Any(x => x == Route));
    var Trips = ConsoleExtension.GetInt($"Número de viajes: ");
    var Passengers = ConsoleExtension.GetInt($"Número de pasajeros total: ");
    var Packages1 = ConsoleExtension.GetInt("Número de encomiendas de menos de 10Kg: ");
    var Packages2 = ConsoleExtension.GetInt("Número de encomiendas entre 10Kg y menos de 20Kg: ");
    var Packages3 = ConsoleExtension.GetInt("Número de encomiendas de más de 20Kg: ");
    // Calculations

    var IncomePassengers = GetincomePassengers(Route, Passengers, Trips);
    var IncomePackages = GetIncomePackages(Route, Packages1, Packages2, Packages3);
    var Incomes = IncomePassengers + IncomePackages;
    var ValueHelper = GetValueHelper(Incomes);
    var ValueSecure = GetValueSecure(Incomes);
    var FuelValue = GetFuelValue(Route, Passengers, Trips, Packages1, Packages2, Packages3);
    var Deductions = ValueHelper + ValueSecure + FuelValue;
    var TotalToPay = Incomes - Deductions;

    // Output Data
    Console.WriteLine("\n*** CALCULOS ***");
    Console.WriteLine($"Ingresos por Pasajeros: {IncomePassengers,20:C2}");
    Console.WriteLine($"Ingresos por Encomiendas: {IncomePackages,20:C2}");
    Console.WriteLine($"Total Ingresos: {Incomes,20:C2}");
    Console.WriteLine($"Pago Ayudante: {ValueHelper,20:C2}");
    Console.WriteLine($"Pago Seguro: {ValueSecure,20:C2}");
    Console.WriteLine($"Pago Combustible: {FuelValue,20:C2}");
    Console.WriteLine($"Total Deducciones: {Deductions,20:C2}");
    Console.WriteLine($"Total a Liquidar: {TotalToPay,20:C2}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Desea Continuar? [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

decimal GetFuelValue(string? Route, int Passengers, int Trips, int Packages1, int Packages2, int Packages3)
{
    float kms;

    switch (Route)
    {
        case "1":
            kms = 150 * Trips;
            break;

        case "2":
            kms = 167 * Trips;
            break;

        case "3":
            kms = 184 * Trips;
            break;

        default:
            kms = 203 * Trips;
            break;
    }

    var gallons = kms / 39;
    var value = (decimal)gallons * 8860m;
    var weight = Passengers * 60 + Packages1 * 10 + Packages2 * 15 + Packages3 * 25;
    if (weight < 5000)
        return value;
    if (weight <= 10000) 
        return value * 1.10m;
    return value * 1.25m;
}


    decimal GetValueSecure(decimal Incomes)
{
    if (Incomes < 1000000) return Incomes * 0.03m;
    if (Incomes < 2000000) return Incomes * 0.04m;
    if (Incomes < 4000000) return Incomes * 0.06m;
    return Incomes * 0.09m;

}


decimal GetValueHelper(decimal Incomes)
{
    if (Incomes < 1000000) return Incomes * 0.05m;
    if (Incomes < 2000000) return Incomes * 0.08m;
    if (Incomes < 4000000) return Incomes * 0.10m;
    return Incomes * 0.13m;
}



decimal GetIncomePackages(string? Route, int Packages1, int Packages2, int Packages3)
{
    decimal value = 0;
    switch (Route)
    {
        case "1":
        case "2":
            if (Packages1 <= 50) value += Packages1 * 100m;
            else if (Packages1 <= 100) value += Packages1 * 120m;
            else if (Packages1 <= 130) value += Packages1 * 150m;
            else value += Packages1 * 160m;

            var PackagesGreather10 = Packages1 + Packages2;
            if (PackagesGreather10 <= 50) value += PackagesGreather10 * 120m;
            else if (PackagesGreather10 <= 100) value += PackagesGreather10 * 140m;
            else if (PackagesGreather10 <= 130) value += PackagesGreather10 * 160m;
            else value += PackagesGreather10 * 180m;

            return value;
        default:
            if (Packages2 <= 50) value += Packages2 * 130m;
            else if (Packages2 <= 100) value += Packages2 * 160m;
            else if (Packages2 <= 130) value += Packages2 * 175m;
            else value += Packages2 * 200m;

            if (Packages2 <= 50) value += Packages2 * 140m;
            else if (Packages2 <= 100) value += Packages2 * 180m;
            else if (Packages2 <= 130) value += Packages2 * 200m;
            else value += Packages2 * 250m;

            if (Packages3 <= 50) value += Packages3 * 170m;
            else if (Packages3 <= 100) value += Packages3 * 210m;
            else if (Packages3 <= 130) value += Packages3 * 250m;
            else value += Packages3 * 300m;

            return value;
    }
}


decimal GetincomePassengers(string? Route, int Passengers, int Trips)
{
    decimal value = 0;
    switch (Route)
    {
        case "1":
            value = 500000m * Trips;
            if (Passengers <= 50) return value;
            if (Passengers > 50 && Passengers <= 100) return value * 1.05m;
            if (Passengers > 100 && Passengers <= 150) return value * 1.06m;
            if (Passengers > 150 && Passengers <= 200) return value * 1.07m;
            return value * 1.07m + (Passengers - 200) * 50m;


        case "2":
            value = 600000m * Trips;
            if (Passengers <= 50) return value;
            if (Passengers > 50 && Passengers <= 100) return value * 1.07m;
            if (Passengers > 100 && Passengers <= 150) return value * 1.08m;
            if (Passengers > 150 && Passengers <= 200) return value * 1.09m;
            return value * 1.09m + (Passengers - 200) * 60m;


        case "3":
            value = 800000m * Trips;
            if (Passengers <= 50) return value;
            if (Passengers > 50 && Passengers <= 100) return value * 1.10m;
            if (Passengers > 100 && Passengers <= 150) return value * 1.13m;
            if (Passengers > 150 && Passengers <= 200) return value * 1.15m;
            return value * 1.15m + (Passengers - 200) * 100m;


        default:
            value = 1000000m * Trips;
            if (Passengers <= 50) return value;
            if (Passengers > 50 && Passengers <= 100) return value * 1.125m;
            if (Passengers > 100 && Passengers <= 150) return value * 1.15m;
            if (Passengers > 150 && Passengers <= 200) return value * 1.17m;
            return value * 1.17m + (Passengers - 200) * 150m;
     };
}




