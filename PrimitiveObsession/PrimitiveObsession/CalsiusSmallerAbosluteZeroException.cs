using System;
using System.Collections.Generic;
using System.Text;

namespace PrimitiveObsession
{
    public class CalsiusSmallerAbosluteZeroException: Exception
    {
        public CalsiusSmallerAbosluteZeroException(double degree)
            :base($"{degree} cannot be smaller than absoulte zero"){}
    }
}
