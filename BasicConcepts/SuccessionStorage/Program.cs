using Shared;
using System.Runtime.Intrinsics.Arm;

var answer = string.Empty;
var options = new List<string> { "s", "n" };


do
{
    Console.WriteLine("*** DATOS DE ENTRADA ***");
    var CC = ConsoleExtension.GetDecimal("Costo de compra ($): ");
    var TP = ConsoleExtension.GetValidOptions($"Tipo de producto [P]erecedero, [N]o perecedero: ", ["p", "n"])!;
    var TC = ConsoleExtension.GetValidOptions($"Tipo de conservación [F]rio, [A]mbiente: ", ["f", "a"])!;
    var PC = ConsoleExtension.GetInt("Periodo de conservación (días): ");
    var PA = ConsoleExtension.GetInt("Periodo de almacenamiento (días): ");
    var VOL = ConsoleExtension.GetInt("Volumen (litros): ");
    var MA = ConsoleExtension.GetValidOptions("Medio de almacenamiento [N]evera, [C]ongelador, [E]estanteria, [G]uacal: ", ["n", "c", "e", "g"])!;


    var CA = GetCostoalmacenamiento(CC, TP, TC, PC, VOL, PA);
    var PDP = GetPorcentajeDepreciacion(PA);
    var CE = GetCostoExhibicion(TP, TC, MA, CA);
    var VR_P = GetValorProdcuto(CC, CA, CE, PDP);
    var VR_V = GetValorVenta(TP, VR_P);


    Console.WriteLine($"\n*** CALCULOS ***");
    Console.WriteLine($"Costos de almacenamiento: {(CA),3:C2} ");
    Console.WriteLine($"Porcentaja de depreciación: {(PDP),0:C2} ");
    Console.WriteLine($"Costo de exhibición: {(CE),7:C2} ");
    Console.WriteLine($"Valor producto: {(VR_P),8:C2} ");
    Console.WriteLine($"Valor venta: {(VR_V),9:C2} ");


    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Desea Continuar? [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("Game Over");


decimal GetValorProdcuto(decimal CC, decimal CA, decimal CE, decimal PDP)
{
   return (CC + CA + CE) * PDP;
}


decimal GetPorcentajeDepreciacion(int PA)
{
    if (PA < 30)
        return 0.95m;

    if (PA >= 30)
        return 0.85m;

    return 0;
}


decimal GetValorVenta(string? TP, decimal VR_P)
{
    if (TP!.Equals("n", StringComparison.CurrentCultureIgnoreCase))
    {
        return VR_P * 1.20m;
    }

    if (TP!.Equals("p", StringComparison.CurrentCultureIgnoreCase))
    {
        return VR_P * 1.40m;
    }
    
    return 0;
}


decimal GetCostoExhibicion(string? TP, string TC, string MA, decimal CA)
{
    if (TP!.Equals("p", StringComparison.CurrentCultureIgnoreCase))
    {
        if (TC!.Equals("f", StringComparison.CurrentCultureIgnoreCase) && MA.ToLower().Equals("n", StringComparison.CurrentCultureIgnoreCase))
        {
            return CA * 2;
        }

        if (TC!.Equals("f", StringComparison.CurrentCultureIgnoreCase) && MA.ToLower().Equals("c", StringComparison.CurrentCultureIgnoreCase))
        { 
            return CA;
        }

    }

    if (TP!.Equals("n", StringComparison.CurrentCultureIgnoreCase))
    {
        if (MA == "e")
        {
            return CA * 0.05m;
        }

        if (MA == "g")
        {
            return CA * 0.07m;
        }
        
    }

    return 0;
}


decimal GetCostoalmacenamiento(decimal CC, string? TP, string? TC, int PC, int VOL, int PA)
{
    if (TP!.Equals("p", StringComparison.CurrentCultureIgnoreCase))
    {
        if (TC!.ToLower().Equals("f", StringComparison.CurrentCultureIgnoreCase) && PC < 10)
        {
            return CC * 0.05m;
        }

        if (TC.ToLower().Equals("f", StringComparison.CurrentCultureIgnoreCase) && PC >= 10)
        {
            return CC * 0.10m;
        }

        if (TC.ToLower().Equals("a", StringComparison.CurrentCultureIgnoreCase) && PA < 20)
        {
            return CC * 0.03m;
        }

        if (TC.ToLower().Equals("a", StringComparison.CurrentCultureIgnoreCase) && PA > 20)
        {
            return CC * 0.10m;
        }

        if (TC.ToLower().Equals("a", StringComparison.CurrentCultureIgnoreCase) && PA == 20)
        {
            return CC * 0.05m;
        }
    }

    if (TP!.ToLower().Equals("n", StringComparison.CurrentCultureIgnoreCase))
    {
        if (VOL >= 50)
        {
            return CC * 0.10m;
        }

        if (VOL < 50)
        {
            return CC * 0.20m;
        }
    }

    return 0;
}