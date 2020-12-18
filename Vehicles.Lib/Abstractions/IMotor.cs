using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Lib.Abstractions
{
    public interface IMotor
    {
        Enums.MotorState State { get; set; }
        void TurnOn()
        {
            State = Enums.MotorState.on;
            Console.WriteLine("The engine is running...");
        }
        void TurnOff()
        {
            State = Enums.MotorState.off;
        }
    }
}
