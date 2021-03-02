using System;
using System.Collections.Generic;
using System.Text;
using ValueOf;

namespace PrimitiveObsession
{
    public class Celsius:ValueOf<double,Celsius>
    {
        protected override void Validate()
        {
            if (this.Value < -276)
                throw new CalsiusSmallerAbosluteZeroException(this.Value);
        }
    }
}
