namespace Shared;

public static class ConsoleExtension
{
    public static int GetInt(string message)
    {
        Console.Write(message);
        var numberString = Console.ReadLine();
        if (int.TryParse(numberString, out int numberInt))
        {
            return numberInt;
        }

        return 0;
    }


    public static float GetFloat(string message)
    {
        Console.Write(message);
        var numberString = Console.ReadLine();
        float numberFloat;
        if (float.TryParse(numberString, out numberFloat))
        {
            return numberFloat;
        }
         return 0;

    }

    public static Decimal GetDecimal(string message)
    {
        Console.Write(message);
        var numberString = Console.ReadLine();
        if (decimal.TryParse(numberString, out decimal numberDecimal))
        {
            return numberDecimal;
        }
        return 0;

    }


    public static string? GetString(string message)
    {
        Console.Write(message);
        var text = Console.ReadLine();
        
            return text;
    }


    public static string? GetValidOptions(string message, List<string> options)
    {
        Console.Write(message);
        var answer = Console.ReadLine();
        if (options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)))
        {
            return answer;
        }
        return null;


    }
}


