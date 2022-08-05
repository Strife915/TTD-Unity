using System.Collections;
using NSubstitute;
using NUnit.Framework;
using Unity.TDD.Abstracts.ScriptableObjects;
using Unity.TDD.Controllers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace TDDBeginner.Combats
{
    public class player_attack : MonoBehaviour
    {
        [UnityTest]
        public IEnumerator player_attack_enemy_one_time()
        {
            //Arrange
            yield return SceneManager.LoadSceneAsync("PlayerCombatTest");
            var enemy = GameObject.FindObjectOfType<EnemyController>();
            var player = GameObject.FindObjectOfType<PlayerController>();
            IStats playerStats = Substitute.For<IStats>();
            playerStats.Damage.Returns(5);
            int initialHealth = enemy.Health.CurrentHealth;

            //Act
            Vector3 enemyUpPosition = enemy.transform.position + (Vector3.up / 2);
            player.transform.position = enemyUpPosition;

            //Assert
            yield return new WaitForSeconds(1f);
            Assert.AreNotEqual(initialHealth, enemy.Health.CurrentHealth);
        }
    }
}