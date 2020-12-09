namespace Vehicles.Lib.Abstractions
{
    public interface IAccelerable
    {
        void Accelerate(int acceleration);
        void SlowDown(int slack);
        void CheckSpeed();
    }
}
