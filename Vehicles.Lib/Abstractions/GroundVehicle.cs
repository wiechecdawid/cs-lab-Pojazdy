using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Lib.Abstractions
{
    public abstract class GroundVehicle : VehicleBase
    {
        protected int _wheels;

        protected GroundVehicle()
        {
            _environment = Enums.MovementEnvironment.ground;
            _unit = Enums.VelocityUnit.kmph;
        }

        public override void OnStateChange()
        {
            if(State == Enums.VehicleState.hold)
            {
                MinSpeed = 0;
                MaxSpeed = 0;

                Console.WriteLine($"The {GetType().Name} stopped.");
            }
            else
            {
                MinSpeed = 1;
                MaxSpeed = 350;

                Console.WriteLine($"The {GetType().Name} started.");
            }
        }

        public override void Stop()
        {
            if(State == Enums.VehicleState.movement)
            {
                while (_speedometer > MinSpeed)
                    SlowDown(10);

                State = Enums.VehicleState.hold;

                Console.WriteLine($"The {GetType().Name} stopped");
            }
        }
    }
}
