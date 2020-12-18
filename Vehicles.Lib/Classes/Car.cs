using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Lib.Abstractions;

namespace Vehicles.Lib.Classes
{
    public class Car : Abstractions.GroundVehicle, Abstractions.IMotorVehicle
    {
        public Car(IMotor motor) : base()
        {
            Motor = motor;
            _wheels = 4;
        }
        public IMotor Motor { get; set; }

        public override void Start()
        {
            if(Motor.State == Enums.MotorState.on)
                base.Start();
            else
                Console.WriteLine("The engine is not running. You cannot start the car");
        }
    }
}
