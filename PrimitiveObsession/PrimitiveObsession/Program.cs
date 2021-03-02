using System;

namespace PrimitiveObsession
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter Celsius degree to convert Fahreinheit:");
            var celsiusDegree = double.Parse(Console.ReadLine());

            Console.WriteLine($"Fahreinheit value: {CelsiusFahrenheitConverter.Convert(Celsius.From(celsiusDegree))} F");
        }
    }
}
