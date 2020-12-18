using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Lib.Abstractions;

namespace Vehicles.Lib.Classes
{
    public class Amphibian : VehicleBase, IMotorVehicle
    {
        private AmphibianOnGround _onGround = new AmphibianOnGround();
        private AmphibianOnWater _onWater;

        public Amphibian(OilMotor motor, int displacement)
        {
            Motor = motor;
            _onWater = new AmphibianOnWater(displacement);            
        }

        public IMotor Motor { get; set; }

        public override void OnStateChange()
        {
            if(State == Enums.VehicleState.hold)
            {
                MinSpeed = 0;
                MaxSpeed = 0;
            }
            else
            {
                if(_environment == Enums.MovementEnvironment.ground)
                {
                    MinSpeed = 1;
                    MaxSpeed = 350;
                }
                else if ( _environment == Enums.MovementEnvironment.water)
                {
                    MinSpeed = 1;
                    MaxSpeed = 40;
                }
            }
            _unit = _environment == Enums.MovementEnvironment.water ? Enums.VelocityUnit.knots : Enums.VelocityUnit.kmph;
        }

        public override void Start()
        {
            if(Motor.State == Enums.MotorState.on)
            {
                if (_environment == Enums.MovementEnvironment.ground)
                    _onGround.Start();
                else
                    _onWater.Start();

                State = Enums.VehicleState.movement;
            }
            else
                Console.WriteLine("Please start engine first");
        }

        public override void Stop()
        {
            State = Enums.VehicleState.hold;
            _speedometer = 0;

            Console.WriteLine($"The amphibian stopped on {_environment}");
        }

        public void GetIntoWater()
        {
            _environment = Enums.MovementEnvironment.water;
            _onGround.State = Enums.VehicleState.hold;
            _onWater.State = Enums.VehicleState.movement;

            State = _onWater.State;

            _speedometer = Helpers.VelocityUnitConverter.KmphToKnots(_speedometer) > MaxSpeed ? 40 : Helpers.VelocityUnitConverter.KmphToKnots(_speedometer);

            Console.WriteLine("The vehicle is on water now");
        }

        public void GetOnGround()
        {
            _environment = Enums.MovementEnvironment.ground;
            _onWater.State = Enums.VehicleState.hold;
            _onGround.State = Enums.VehicleState.movement;

            _speedometer = Helpers.VelocityUnitConverter.KnotsToKmph(_speedometer);

            State = _onGround.State;

            Console.WriteLine("The vehicle is on ground now");
        }

        private class AmphibianOnGround : GroundVehicle
        {
            public AmphibianOnGround() : base()
            {
                _wheels = 4;
            }
        }

        private class AmphibianOnWater : WaterVehicle
        {
            public AmphibianOnWater(int displacement) : base(displacement) {}
        }
    }
}
