using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Shared
{
    public class MyMath
    {
        public static double Factorial(int n)
        {
        double factorial = 1;
        for (int i = 2; i <= n; i++)
         {
            factorial *= i;
         }
        return factorial;
        }
    }   
}

