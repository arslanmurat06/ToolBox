using System;
using System.Collections.Generic;
using System.Text;

namespace PrimitiveObsession
{
    public class CelsiusFahrenheitConverter
    {
        public static Fahrenheit Convert(Celsius degree)
        {
            return Fahrenheit.From((degree * 9 / 5) + 32);
        }
    }
}
