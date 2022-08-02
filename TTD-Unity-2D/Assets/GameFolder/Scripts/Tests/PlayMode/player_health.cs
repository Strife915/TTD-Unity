using System.Collections;
using JetBrains.Annotations;
using NSubstitute;
using NUnit.Framework;
using Unity.TDD.Abstracts.Controller;
using Unity.TDD.Abstracts.ScriptableObjects;
using Unity.TDD.Controllers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace TDDBeginner.Combats
{
    public class player_health : MonoBehaviour
    {
        IEnemyController _enemy;
        IPlayerController _player;
        IStats _enemyStats;

        [UnitySetUp]
        public IEnumerator SetUpAsyn()
        {
            yield return SceneManager.LoadSceneAsync("PlayerCombatTest");

            _player = GameObject.FindObjectOfType<PlayerController>();
            _enemy = GameObject.FindObjectOfType<EnemyController>();
            _enemyStats = Substitute.For<IStats>();
        }

        [UnityTest]
        [TestCase(1, ExpectedResult = (IEnumerator)null)]
        [TestCase(2, ExpectedResult = (IEnumerator)null)]
        [TestCase(5, ExpectedResult = (IEnumerator)null)]
        [TestCase(10, ExpectedResult = (IEnumerator)null)]
        [CanBeNull]
        public IEnumerator player_take_damage_in_one_time_different_damage_value(int damageValue)
        {
            _enemy.Attacker = new Attacker(_enemyStats);
            _enemyStats.CalculateDamage.Returns(damageValue);
            int maxHealth = _player.Health.CurrentHealth;
            Vector3 playerPosition = _player.transform.position;
            _enemy.transform.position = playerPosition;

            yield return new WaitForSeconds(1f);

            Assert.AreEqual(maxHealth - damageValue, _player.Health.CurrentHealth);
        }

        [UnityTest]
        [TestCase(0,1f,5, ExpectedResult = (IEnumerator)null)]
        [TestCase(-1f,0f,5, ExpectedResult = (IEnumerator)null)]
        [TestCase(1f,0f,5, ExpectedResult = (IEnumerator)null)]
        public IEnumerator player_take_one_damage_from_right_up_left_side(float x,float y,int damageValue)
        {
            Vector3 attackPosition = new Vector3(x, y, 0f);
            int maxHealth = _player.Health.CurrentHealth;
            _enemy.Attacker = new Attacker(_enemyStats);
            _enemyStats.CalculateDamage.Returns(damageValue);
            Vector3 playerNearestPosition = _player.transform.position + (attackPosition/2);
            _enemy.transform.position = playerNearestPosition;

            yield return new WaitForSeconds(1f);
            Assert.AreEqual(maxHealth - damageValue,_player.Health.CurrentHealth);
        }
    }
}