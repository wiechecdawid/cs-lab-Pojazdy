using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Lib.Abstractions;
using Vehicles.Lib.Helpers;

namespace Vehicles.Lib.Classes
{
    public class Plane : VehicleBase, IMotorVehicle
    {
        protected PlaneOnGround _onGround = new PlaneOnGround();
        protected PlaneOnAir _onAir = new PlaneOnAir();

        public Plane(IMotor motor) : base()
        {
            _environment = Enums.MovementEnvironment.ground;
            _unit = Enums.VelocityUnit.kmph;

            Motor = motor;
        }

        public IMotor Motor { get; set; }

        public override void OnStateChange()
        {
            if (State == Enums.VehicleState.hold)
            {
                MinSpeed = 0;
                MaxSpeed = 0;
            }
            else
            {
                if (_environment == Enums.MovementEnvironment.ground)
                {
                    MinSpeed = 1;
                    MaxSpeed = 350;
                }
                else if (_environment == Enums.MovementEnvironment.air)
                {
                    MinSpeed = 20;
                    MaxSpeed = 200;
                }
            }
            _unit = _environment == Enums.MovementEnvironment.air ? Enums.VelocityUnit.mps : Enums.VelocityUnit.kmph;
        }

        public void TakeOff()
        {
            if(_environment == Enums.MovementEnvironment.ground && State == Enums.VehicleState.movement)
            {
                if(VelocityUnitConverter.KmphToMps(_speedometer) < 20)
                    Console.WriteLine("The speed is too low to take off. Please accelerate...");
                else
                {
                    _onAir.TakeOff();
                    _environment = Enums.MovementEnvironment.air;
                    _speedometer = VelocityUnitConverter.KmphToMps(_speedometer);
                    _unit = _onAir.GetUnit();
                }
            }
        }

        public void Land()
        {
            if(_environment == Enums.MovementEnvironment.air)
            {
                _onAir.Land();
                _environment = Enums.MovementEnvironment.ground;

                _speedometer = VelocityUnitConverter.MpsToKnots(_speedometer);
                _unit = _onGround.GetUnit();
            }
        }

        public override void Start()
        {
            if(Motor.State == Enums.MotorState.off)
                Console.WriteLine("Cannot start the plane. Please turn the engine on first...");
            else if(_environment == Enums.MovementEnvironment.ground && _onGround.State == Enums.VehicleState.hold)
            {
                _onGround.Start();
                State = _onGround.State;
            }
            else
                Console.WriteLine("The plane is already running...");
        }

        public override void Stop()
        {
            if (_environment == Enums.MovementEnvironment.air)
                _onAir.Stop();
            else if (State == Enums.VehicleState.hold)
                Console.WriteLine("The plane has already been stopped");
            else
            {
                _onGround.Stop();
                State = _onGround.State;
            }
        }


        protected class PlaneOnGround : GroundVehicle
        {
            public PlaneOnGround() : base()
            {
                _wheels = 2;
            }
        }
        protected class PlaneOnAir : AirVehicle { }
    }
}
