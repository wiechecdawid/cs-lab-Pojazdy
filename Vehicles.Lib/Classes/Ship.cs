using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Lib.Abstractions;

namespace Vehicles.Lib.Classes
{
    public class Ship : WaterVehicle, IMotorVehicle
    {
        public Ship(int displacement, OilMotor motor) : base(displacement)
        {
            Motor = motor;
        }
        public IMotor Motor { get; set; }

        public override void Start()
        {
            if (Motor.State == Enums.MotorState.on)
                base.Start();
            else
                Console.WriteLine("Please start the engine first.");
        }
    }
}
