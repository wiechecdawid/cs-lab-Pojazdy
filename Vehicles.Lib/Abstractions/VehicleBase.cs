using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Lib.Abstractions
{
    public abstract class VehicleBase : IStartable, IStoppable, IAccelerable
    {
        protected Enums.MovementEnvironment _environment;
        protected Enums.VehicleState _state = Enums.VehicleState.stand;
        protected Enums.VelocityUnit _unit;

        protected int _speedometer = 0;

        public virtual int MinSpeed { get; set; }
        public virtual int MaxSpeed { get; set; }
        public virtual Enums.VehicleState State 
        { 
            get => _state; 
            protected set
            {
                _state = value;
                OnStateChange();
            }
        }

        public virtual void Start()
        {
            if(State == Enums.VehicleState.stand)
            {
               State = Enums.VehicleState.movement;
                
                Console.WriteLine($"The {GetType().Name} has started.");

                Accelerate(MinSpeed);
                CheckSpeed();
            }
            else
                Console.WriteLine($"The {GetType().Name} is already moving");
        }

        public abstract void Stop();

        public virtual void Accelerate(int acceleration)
        {
            if(State == Enums.VehicleState.movement)
            {
                int speed = acceleration + _speedometer;
                if (speed >= MinSpeed && speed <= MaxSpeed)
                    _speedometer = acceleration;
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
    }
}
