using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var a = ConsoleExtension.GetDouble("Ingrese el valor de a: ");
    var b = ConsoleExtension.GetDouble("Ingrese el valor de b: ");
    var c = ConsoleExtension.GetDouble("Ingrese el valor de c: ");
    var solution = QuadraticEcuation(a, b, c);

    Console.WriteLine($"X1: {solution.X1:N5}");
    Console.WriteLine($"X2: {solution.X2:N5}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("Game Over");

QuadraticEcuationsSolution QuadraticEcuation(double a, double b, double c)
{
    return new QuadraticEcuationsSolution
    {
        X1 = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a),
        X2 = (-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a)
    };
}

public class QuadraticEcuationsSolution
{
    public double X1
    { 
        get; 
        set; 
    }

    public double X2
    { 
        get; 
        set; 
    }   
}
