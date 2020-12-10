using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Lib.Abstractions
{
    public class AirVehicle : VehicleBase
    {
        protected AirVehicle()
        {
            _environment = Enums.MovementEnvironment.air;
            _unit = Enums.VelocityUnit.mps;
            MinSpeed = 20;
            MaxSpeed = 200;
        }

        public override Enums.VehicleState State
        {
            get => _state;
            set
            {
                _state = Enums.VehicleState.movement;
            }
        }

        public virtual void TakeOff()
        {
            Console.WriteLine("The flight has started...");
        }

        public virtual void Land()
        {
            Console.WriteLine("Landing...");
        }


        public override void OnStateChange()
        {
            Stop();
        }

        public override void Stop()
        {
            Console.WriteLine("You cannot stop the vehicle in air. Please land first");
        }
    }
}
