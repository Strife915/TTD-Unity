namespace Unity.TDD.Abstracts.Combats
{
    public interface IHealth
    {
        int CurrentHealth { get; }
        bool Isdead { get; }
        event System.Action OnTookDamage;
        event System.Action OnDead;
        void TakeDamage(IAttacker attacker);
    }
}