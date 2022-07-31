using System.Collections;
using NUnit.Framework;
using Unity.TDD.Controllers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace TDDBeginner.Combats
{
    public class player_health : MonoBehaviour
    {
        [UnityTest]
        public IEnumerator player_take_one_damage()
        {
            yield return SceneManager.LoadSceneAsync("PlayerCombatTest");

            var player = GameObject.FindObjectOfType<PlayerController>();
            var enemy = GameObject.FindObjectOfType<EnemyController>();

            int maxHealth = player.Health.CurrentHealth;
            Vector3 playerPosition = player.transform.position;
            enemy.transform.position = playerPosition;

            yield return new WaitForSeconds(1f);

            Assert.AreEqual(maxHealth - 1, player.Health.CurrentHealth);
        }
    }
}