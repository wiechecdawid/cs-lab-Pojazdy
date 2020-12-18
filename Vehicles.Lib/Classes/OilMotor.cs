using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Lib.Classes
{
    public class OilMotor : Motor
    {
        public OilMotor(int hp) : base(Enums.Fuel.oil, hp)
        {
        }
    }
}
