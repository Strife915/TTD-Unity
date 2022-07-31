using System;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace TDDBeginner.Combats
{
    public class health
    {
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(10)]
        public void take_damage_not_equal_max_health(int damageValue)
        {
            //Arrange
            int _maxHealth = 1;
            IHealth health = new Health(_maxHealth);
            IAttacker attacker = Substitute.For<IAttacker>();

            //Act
            attacker.Damage.Returns(damageValue);
            health.TakeDamage(attacker);

            //Assert
            Assert.AreNotEqual(_maxHealth, health.CurrentHealth);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(10)]
        public void take_damage_current_health_not_less_than_zero(int damageValue)
        {
            //Arrange
            int _maxHealth = 1;
            IHealth health = new Health(_maxHealth);
            IAttacker attacker = Substitute.For<IAttacker>();

            //Act
            attacker.Damage.Returns(damageValue);
            health.TakeDamage(attacker);

            //Assert
            Assert.GreaterOrEqual(health.CurrentHealth, 0);
        }

        [Test]
        public void take_damage_on_took_damage_event_triggered()
        {
            IHealth health = new Health(5);
            IAttacker attacker = Substitute.For<IAttacker>();

            attacker.Damage.Returns(1);

            string message = string.Empty;
            health.OnTookDamage += () => message = "On Took Damage Event Triggered";
            health.TakeDamage(attacker);

            Assert.AreNotEqual(string.Empty, message);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(10)]
        public void take_several_damage_on_took_damage_event_trigered_5_time(int value)
        {
            IHealth health = new Health(100);
            IAttacker attacker = Substitute.For<IAttacker>();
            int damageLoop = value;

            attacker.Damage.Returns(1);

            int damageCounter = value;
            string message = string.Empty;
            health.OnTookDamage += () => damageCounter++;
            for (int i = 0; i < damageLoop; i++)
            {
                health.TakeDamage(attacker);
            }

            Assert.AreEqual(damageCounter, damageCounter);
        }

        [Test]
        public void take_fatal_damage()
        {
            int maxHealth = 100;
            IHealth health = new Health(maxHealth);
            IAttacker attacker = Substitute.For<IAttacker>();

            attacker.Damage.Returns(maxHealth + 1);
            string message = string.Empty;
            health.OnDead += () => message = "On Dead Event Triggered";
            health.TakeDamage(attacker);

            Assert.AreNotEqual(string.Empty, message);
        }

        [Test]
        public void take_normal_damage_on_dead_not_triggered()
        {
            int maxHealth = 100;
            IHealth health = new Health(maxHealth);
            IAttacker attacker = Substitute.For<IAttacker>();

            attacker.Damage.Returns(maxHealth / 2);

            string expectedResult = string.Empty;
            string message = expectedResult;
            health.OnDead += () => message = "On Dead event triggered";
            health.TakeDamage(attacker);

            Assert.AreEqual(expectedResult, message);
        }

        [Test]
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(10)]
        public void take_fatal_damage_many_time_on_took_damage_trigger_once(int value)
        {
            int maxHealth = 100;
            IHealth health = new Health(maxHealth);
            IAttacker attacker = Substitute.For<IAttacker>();
            int damageLoop = value;

            attacker.Damage.Returns(maxHealth + 1);
            int damageCounter = 0;
            health.OnTookDamage += () => damageCounter++;

            for (int i = 0; i < damageLoop; i++)
            {
                health.TakeDamage(attacker);
            }

            Assert.AreEqual(1, damageCounter);
        }
    }


    public class Health : IHealth
    {
        int _currentHealth = 0;

        public int CurrentHealth => _currentHealth;
        public bool Isdead => _currentHealth <= 0;
        public event Action OnTookDamage;
        public event Action OnDead;

        public Health(int maxHealth)
        {
            _currentHealth = maxHealth;
        }


        public void TakeDamage(IAttacker attacker)
        {
            if (Isdead) return;
            _currentHealth -= attacker.Damage;
            _currentHealth = Mathf.Max(_currentHealth, 0);
            OnTookDamage?.Invoke();

            if (Isdead)
            {
                OnDead?.Invoke();
            }
        }
    }

    public interface IHealth
    {
        int CurrentHealth { get; }
        bool Isdead { get; }
        event System.Action OnTookDamage;
        event System.Action OnDead;
        void TakeDamage(IAttacker attacker);
    }

    public class Attacker : IAttacker
    {
        public int Damage { get; }
    }

    public interface IAttacker
    {
        int Damage { get; }
    }
}