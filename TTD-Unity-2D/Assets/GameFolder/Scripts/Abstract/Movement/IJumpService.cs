namespace Unity.TDD.Movements
{
    public interface IJumpService
    {
        void Tick();
        void FixedTick();
        void ResetCounter();
    }
}