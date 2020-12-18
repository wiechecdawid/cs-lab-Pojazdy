using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Lib.Abstractions
{
    public class WaterVehicle : VehicleBase
    {
        public WaterVehicle(int displacement) : base()
        {
            _environment = Enums.MovementEnvironment.water;
            _unit = Enums.VelocityUnit.knots;
            Displacement = displacement;
        }
        int Displacement { get; }
        public override void OnStateChange()
        {
            if(State == Enums.VehicleState.movement)
            {
                MinSpeed = 1;
                MaxSpeed = 40;
            }
            else
            {
                MinSpeed = 0;
                MaxSpeed = 0;
            }
        }

        public override void Stop()
        {
            if (State == Enums.VehicleState.movement)
            {
                while (_speedometer > MinSpeed)
                    SlowDown(5);

                _speedometer = 0;
                State = Enums.VehicleState.hold;

                Console.WriteLine($"The {GetType().Name} stopped");
            }
        }

        public override string ToString()
        {
            return String.Format("Ground Vehicle\n{0}\n{1}", Displacement, base.ToString());
        }
    }
}
