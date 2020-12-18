using System;
using Vehicles.Lib.Classes;
using Vehicles.Lib.Enums;
using Vehicles.Lib.Helpers;

namespace Vehicles.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = new Motor(Fuel.gas, new Random().Next(50, 750));
            var c = new Car(m);

            Console.WriteLine(c);
            c.Start();
            c.Motor.TurnOn();
            c.Start();
            c.Accelerate(120);
            c.SlowDown(30);
            c.Stop();

            Console.WriteLine();

            var p = new Plane(m);
            p.Motor.TurnOn();
            p.Start();
            p.Accelerate(30);
            p.TakeOff();
            p.Accelerate(60);
            p.TakeOff();
            p.Accelerate(20);
            p.Stop();
            p.Land();
            p.SlowDown(20);
            p.Stop();
            p.Motor.TurnOff();
            Console.WriteLine();

            var om = new OilMotor(550);
            var s = new Ship(1100, om);
            s.Start();
            s.Motor.TurnOn();
            s.Start();
            s.Accelerate(25);
            s.Stop();
            s.Motor.TurnOff();
            Console.WriteLine();

            var a = new Amphibian(om, 800);
            a.Start();
            a.Motor.TurnOn();
            a.Start();
            a.Accelerate(120);
            a.GetIntoWater();
            a.CheckSpeed();
            a.Stop();
        }
    }
}
