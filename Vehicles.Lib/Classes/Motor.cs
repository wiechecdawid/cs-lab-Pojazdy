using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Lib.Abstractions;
using Vehicles.Lib.Enums;

namespace Vehicles.Lib.Classes
{
    public class Motor : IMotor
    {
        public Motor(Fuel fuel, int hp)
        {
            (Fuel, HorsePower) = (fuel, hp);
        }
        public Fuel Fuel { get; protected set; }
        public int HorsePower { get; protected set; }
        public MotorState State { get; set; } = MotorState.off;
    }
}
