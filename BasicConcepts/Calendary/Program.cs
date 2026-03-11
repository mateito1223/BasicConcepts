using Microsoft.VisualBasic;
using Shared;

var options = new List<string> { "s", "n" };
var answer = string.Empty;

do
{
    // Data input
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.Clear();
    Console.WriteLine("*** CALENDARIO ***");
    var year = ConsoleExtension.GetInt("Digite el año: ");

    // Show results
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Clear();

    ShowCalendar(year);

    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar (s/n)?", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
}
while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("Game Over");
void ShowCalendar(int year)
{
    Console.WriteLine($"*** Año: {year} ***");
    Console.WriteLine();
    List<String> months = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"];
    int i = 0;
    foreach(var month in months)
    { 
        Console.WriteLine($"{month}");
        Console.WriteLine($"Dom\tLun\tMar\tMie\tJue\tVie\tSab");
        var DaysPerMonth = GetDaysPerMonth(year, i);
        var zeller = Zeller(year, i + 1);
        var DaysCounter = 0;
        for (int j = 0; j < zeller; j++)
        {
            Console.Write("\t");
            DaysCounter++;
        }



        for (int day = 1; day <= DaysPerMonth; day++) 
        {
            Console.Write($"{day}\t");
            DaysCounter++;
            if (DaysCounter == 7)
            {
                DaysCounter = 0;
                Console.WriteLine();
            }
           
        }
        Console.WriteLine();
        Console.WriteLine();
        i++;
    }
}

int GetDaysPerMonth(int year, int month)
{
    if (month == 1 && DateUtilities.IsLeapYear(year))
    {
        return 29;
    }

    List<int> daysPermonth = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
    return daysPermonth.ElementAt(month);
}

// Devuelve
// 0 = Domingo, 1 = Lunes, 2 = Martes, 3 = Miercoles,
// 4 = Jueves, 5 = Viernes, 6 = Sábado
int Zeller(int ano, int mes)
{
    int a = (14 - mes) / 12;
    int y = ano - a;
    int m = mes + 12 * a - 2;
    int dia = 1, d;
    d = (dia + y + y / 4 - y / 100 + y / 400 + (31 * m) / 12) % 7;
    return (d);
}
