using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Lib.Abstractions
{
    public abstract class GroundVehicle : VehicleBase
    {
        protected int _wheels;

        protected GroundVehicle() : base()
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
            }
            else
            {
                MinSpeed = 1;
                MaxSpeed = 350;
            }
        }

        public override void Stop()
        {
            if(State == Enums.VehicleState.movement)
            {
                while (_speedometer > MinSpeed)
                    SlowDown(10);

                _speedometer = 0;
                State = Enums.VehicleState.hold;

                Console.WriteLine($"The {GetType().Name} stopped");
            }
        }

        public override string ToString()
        {
            return String.Format("Ground Vehicle\nNumber of Wheels: {0}\n{1}",_wheels,base.ToString());
        }
    }
}
