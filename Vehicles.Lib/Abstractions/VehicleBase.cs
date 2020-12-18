using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Lib.Abstractions
{
    public abstract class VehicleBase : IStartable, IStoppable, IAccelerable
    {
        protected Enums.MovementEnvironment _environment;
        protected Enums.VehicleState _state;
        protected Enums.VelocityUnit _unit;

        protected double _speedometer = 0;

        protected VehicleBase()
        {
            State = Enums.VehicleState.hold;
        }

        public virtual double MinSpeed { get; set; }
        public virtual double MaxSpeed { get; set; }
        public virtual Enums.VehicleState State 
        { 
            get => _state; 
            set
            {
                _state = value;
                OnStateChange();
            }
        }

        public Enums.VelocityUnit GetUnit() => _unit;

        public virtual void Start()
        {
            if(State == Enums.VehicleState.hold)
            {
               State = Enums.VehicleState.movement;
                
                Console.WriteLine($"The {GetType().Name} has started.");

                Accelerate((int)MinSpeed);
            }
            else
                Console.WriteLine($"The {GetType().Name} is already moving");
        }

        public abstract void Stop();

        public virtual void Accelerate(int acceleration)
        {
            if(State == Enums.VehicleState.movement)
            {
                double speed = acceleration + _speedometer;
                if (speed >= MinSpeed && speed <= MaxSpeed)
                    _speedometer = speed;
                else
                    _speedometer = speed < MinSpeed ? MinSpeed : MaxSpeed;
            }
            CheckSpeed();
        }

        public virtual void SlowDown(int slack)
        {
            if (_speedometer - slack > MinSpeed)
                _speedometer -= slack;
            else _speedometer = MinSpeed;

            CheckSpeed();
        }

        public virtual void CheckSpeed()
        {
            Console.WriteLine($"The {GetType().Name} is moving with the speed of {_speedometer} {_unit}");
        }

        public abstract void OnStateChange();

        public override string ToString()
        {
            return ToStringImpl();
        }

        public virtual string ToStringImpl()
        {
            var sb = new StringBuilder($"Vehicle Type: {GetType().Name}");
            sb.AppendLine($"The vehicle is moving on {_environment}");

            string state = State == Enums.VehicleState.movement ? "moving" : "standing still";
            sb.AppendLine($"The vehicle is {state}");
            sb.AppendLine($"The speed range is between {MinSpeed} and {MaxSpeed} {_unit}");

            if (State == Enums.VehicleState.movement)
                sb.AppendLine($"The vehicle moves with the speed of {_speedometer}.");

            return sb.ToString();
        }
    }
}
