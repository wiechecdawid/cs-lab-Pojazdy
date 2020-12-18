using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Lib.Abstractions
{
    public interface IMotorVehicle
    {
        IMotor Motor { get; set; }

        void TurnOn()
        {
            Motor.TurnOn();
        }

        void TurnOff()
        {
            Motor.TurnOff();
        }

        string ToString()
        {
            return "Motor vehicle";
        }
    }
}
