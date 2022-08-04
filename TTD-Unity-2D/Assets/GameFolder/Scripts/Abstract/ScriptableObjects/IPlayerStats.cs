namespace Unity.TDD.Abstracts.ScriptableObjects
{
    public interface IPlayerStats : IStats
    {
        float JumpForce { get; }
    }

    public interface IEnemyStats : IStats
    {
    }

    public interface IStats
    {
        float MoveSpeed { get; }
        int MaxHealth { get; }
        int Damage { get; }
    }
}