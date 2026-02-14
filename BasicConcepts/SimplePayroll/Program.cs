using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var name = ConsoleExtension.GetString("Ingrese el nombre del empleado: ");
    var hours = ConsoleExtension.GetFloat("Ingrese el numero de horas trabajadas en el mes: ");
    var valuehour = ConsoleExtension.GetDecimal("Ingrese el valor pagado por hora: ");
    var smlv = ConsoleExtension.GetDecimal("Ingrese el salario minimo: ");

    var salary = (decimal)hours * valuehour;

    if (salary < smlv)
    {
        Console.WriteLine($"Nombre: {name}");
    }
    else
    {
        Console.WriteLine($"Nombre: {name}");
        Console.WriteLine($"Salario: {salary:C2}");
    }

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Desea Continuar? [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("Game Over");

