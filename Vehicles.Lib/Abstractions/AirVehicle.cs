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
            State = Enums.VehicleState.movement;
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
            Console.WriteLine("The plane is taking off...");
        }

        public virtual void Land()
        {
            Console.WriteLine("Landing...");
        }


        public override void OnStateChange()
        {
            if (State == Enums.VehicleState.movement)
            {
                MinSpeed = 20;
                MaxSpeed = 200;
            }                
        }

        public override void Stop()
        {
            Console.WriteLine("You cannot stop the vehicle in air. Please land first");
        }

        public override string ToString()
        {
            return String.Format("Air Vehicle\n{0}", base.ToString());
        }
    }
}
